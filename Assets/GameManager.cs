using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _prefabs;
    private List<AsyncOperation> _loadOperations = new List<AsyncOperation>();
    private List<GameObject> _prefabInstantiate = new List<GameObject>();
    private static GameManager _instance;
    private static string _currentLevelName;
    // Start is called before the first frame update
    void Start()
    {
        getInstance();
        DontDestroyOnLoad(this);
    }
    
    public void loadScene(string name)

    {
        var loadSceneAsync = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);

        if (loadSceneAsync == null)
        {
            print("error loading scene : " + name);
            return;
        }

        _currentLevelName = name;
        _loadOperations.Add(loadSceneAsync);
        
        //loadSceneAsync.completed += onLoadSceneCompleted;
    }
    
    private void getInstance()
    {
        if (_instance == null)
        {
            _instance = this;
            Instantiate(_instance).name = "GameManager";
        }
    }
}
