using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    public List<string> scenesNames;

    void Start()
    {
        this.StartCoroutine(LoadSceneAsync(scenesNames[0]));
    }

    public void ChangeToScene(string sceneName)
    {
        Debug.Log("Change to scene " + sceneName);
        StartCoroutine(ChangeToSceneAsync(sceneName));
    }

    private IEnumerator ChangeToSceneAsync(string sceneName)
    {
        foreach (string s in scenesNames)
        {
            if ((s != null) && (s != sceneName))
            {
                yield return UnloadSceneAsync(s);
            }
        }
        yield return LoadSceneAsync(sceneName);
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        Scene s = SceneManager.GetSceneByName(sceneName);
        if (s.IsValid() == false)
        {
            AsyncOperation LoadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            yield return LoadOperation;
        }
    }

    private IEnumerator UnloadSceneAsync(string sceneName)
    {
        Scene s = SceneManager.GetSceneByName(sceneName);
        if (s.IsValid())
        {
            AsyncOperation UnloadOperation = SceneManager.UnloadSceneAsync(s);
            yield return UnloadOperation;
        }
    }
}
