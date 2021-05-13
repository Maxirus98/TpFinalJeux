using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [System.Serializable] public class EventGameState : UnityEvent<GameState, GameState> {}
    public enum GameState
    {
        Running,
        EncounterTutorial
    }
    public EventGameState gameStateHandler;
    
    private List<AsyncOperation> _loadOperations = new List<AsyncOperation>();
    
    [SerializeField] private GameObject[] systemPrefabs;
    private List<GameObject> instanceSystemPrefabsKept = new List<GameObject>();
    private GameState _currentGameState = GameState.Running;
    
    private string _currentLevelName = string.Empty;
    
    void Start()
    {
        DontDestroyOnLoad(this);
        KeepSystemPrefabs();
    }

    void KeepSystemPrefabs()
    {
        foreach (var go in systemPrefabs)
        {
            var clonePrefab = Instantiate(go);
            instanceSystemPrefabsKept.Add(clonePrefab);
            DontDestroyOnLoad(clonePrefab);
        }
        instanceSystemPrefabsKept[0].gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        
    }
    
    public void TogglePause()
    {
        UpdateGameState(CurrentGameState == GameState.Running ? GameState.EncounterTutorial : GameState.Running);
    }

    void UpdateGameState(GameState newGameState)
    {
        var previousGameState = CurrentGameState;
        CurrentGameState = newGameState;
        switch (_currentGameState)
        {
            case GameState.Running:
                Time.timeScale = 1;
                if(instanceSystemPrefabsKept.Count > 0)instanceSystemPrefabsKept[0].gameObject.SetActive(false);
                break;
            case GameState.EncounterTutorial:
                Time.timeScale = 0;
                if(instanceSystemPrefabsKept.Count > 0)instanceSystemPrefabsKept[0].gameObject.SetActive(true);
                break;
            default:
                break;
        }
        
       gameStateHandler.Invoke(CurrentGameState, previousGameState);
    }
    
    public void ChoisirSpell(String spellName)
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var hud = GameObject.Find("HUD");
        if (player && hud)
        {
            var spellFill = hud.transform.GetChild(1).GetChild(0).gameObject;
            var spells = player.GetComponents<Spell>();
            foreach (var spell in spells)
            {
                spell.enabled = false;
                if (spell.go.name.Equals(spellName))
                {
                    spell.enabled = true;
                    spellFill.GetComponent<Image>().sprite = spell.sprite;
                }
            }
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (instanceSystemPrefabsKept == null) return;
        foreach (var prefabInstance in instanceSystemPrefabsKept)
        {
            if (!(prefabInstance is null)) Destroy(prefabInstance);
        }
        instanceSystemPrefabsKept.Clear();
    }
    public void LoadLevel(string levelName)
    {
        CurrentLevelName = levelName;
        
        AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
        if (loadSceneAsync == null)  // La scene existe dans le build setting
        {
            print("error loading scene : " + levelName);
            return;
        }
        loadSceneAsync.completed += OnLoadSceneComplete;
        _loadOperations.Add(loadSceneAsync);
    }
    
    private void OnLoadSceneComplete(AsyncOperation ao)
    {
        if (_loadOperations.Contains(ao))
        {
            _loadOperations.Remove(ao);
            // Ici on peut aviser les composantes qui ont besoin de savoir que le level est loadé
            if (_loadOperations.Count == 0)
            {
                UpdateGameState(GameState.Running);
            }
        }
        print("load completed" + CurrentLevelName);
    }

    public void UnloadLevel(string levelName)
    {
        AsyncOperation unloadSceneAsync = SceneManager.UnloadSceneAsync(levelName);
        if (unloadSceneAsync == null)
        {
            print("error unloading scene : " + levelName);
            return;
        }
        unloadSceneAsync.completed += OnUnloadSceneComplete;
    }
    private void OnUnloadSceneComplete(AsyncOperation obj)
    {
        print("unload completed");
    }

    /**
     * TODO: Vérifier que le jeu n'est pas en train de sauvegarder avant de fermer
     */
    public void QuitGame()
    {
        Application.Quit();
    }

    public GameState CurrentGameState
    {
        get { return _currentGameState; }
        set { _currentGameState = value; }
    }
    
    public string CurrentLevelName
    {
        get { return _currentLevelName; }
        set { _currentLevelName = value; }
    }
    
}
