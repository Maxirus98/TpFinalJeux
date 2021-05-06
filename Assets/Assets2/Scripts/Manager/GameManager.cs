using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [System.Serializable] public class EventGameState : UnityEvent<GameState, GameState> {}
    public enum GameState
    {
        MainMenu,
        Running,
        EncounterTutorial,
        Death,
        Pause
    }
    public EventGameState gameStateHandler;
    
    private List<AsyncOperation> _loadOperations = new List<AsyncOperation>();
    
    [SerializeField] private GameObject[] systemPrefabs;
    private List<GameObject> instanceSystemPrefabsKept = new List<GameObject>();
    private GameState _currentGameState = GameState.MainMenu;
    
    private string _currentLevelName = string.Empty;
    
    void Start()
    {
        DontDestroyOnLoad(this);
        //KeepSystemPrefabs();
    }

    void KeepSystemPrefabs()
    {
        foreach (var go in systemPrefabs)
        {
            instanceSystemPrefabsKept.Add(Instantiate(go));
        }
    }
    
    void Update()
    {
        if (/*_currentGameState != GameState.MainMenu &&*/ Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    
    public void TogglePause()
    {
        UpdateGameState(CurrentGameState == GameState.MainMenu ? GameState.EncounterTutorial : GameState.MainMenu);
    }

    void UpdateGameState(GameState newGameState)
    {
        var previousGameState = CurrentGameState;
        CurrentGameState = newGameState;
        switch (_currentGameState)
        {
            case GameState.MainMenu:
                Time.timeScale = 1;
                break;
            case GameState.Running:
                Time.timeScale = 1;
                break;
            case GameState.EncounterTutorial:
                Time.timeScale = 0;
                break;
            default:
                break;
        }
        
       gameStateHandler.Invoke(CurrentGameState, previousGameState);
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
    
    //Attaché au bouton "Jouer"
    public void StartGame()
    {
        LoadLevel("Niveau1");
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
    
    public void RestartGame()
    {
        UpdateGameState(GameState.MainMenu);
        UnloadLevel(CurrentLevelName);
    }

    /**
     * TODO: Vérifier que le jeu n'est pas en train de sauvegarder avant de fermer
     */
    public void QuitGame()
    {
        print("Quitting game...");
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
