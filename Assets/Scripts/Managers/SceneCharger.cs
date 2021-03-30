using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneCharger : MonoBehaviour
{
    
    public void ChargeLevel()
    {
        StartCoroutine(LoadScene("GameScene1"));
    }
    public void ChargeLevel(string SceneName)
    {
        StartCoroutine(LoadScene(SceneName));
    }
    public void CloseGame()
    {
        Application.Quit();
    }
    IEnumerator LoadScene(string SceneName)
    {
        yield return null;
        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneName);
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            //m_Text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";
            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {               
                    asyncOperation.allowSceneActivation = true;
            }          
            yield return null;
        }
    }
}
