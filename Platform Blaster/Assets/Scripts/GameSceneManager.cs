using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance;
    private AsyncOperation asyncOperation;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadNewScene(sceneName));
    }

    private IEnumerator LoadNewScene(string sceneName)
    {
        yield return null;
        Time.timeScale = 0f;

        asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        while(!asyncOperation.isDone)
        {
            yield return null; //Waits a frame
        }
        Time.timeScale = 1f;
    }
}
