using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StaringGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadScene(string nameScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Loading");
        Time.timeScale = 1;
        StartCoroutine(LoadAsynchronously(nameScene));
    }

    public void TimeReturn()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }
    void Update()
    {
        
    }

    IEnumerator LoadAsynchronously (string sceneName) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            Debug.Log(operation.progress);

            yield return null;
        }
        //SceneManager.LoadSceneAsync(nameScene);
    }
}
