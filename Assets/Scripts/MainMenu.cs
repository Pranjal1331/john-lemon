using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    public Text m_Text;
    public void PlayGame(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        operation.allowSceneActivation = false;
        while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                progressText.text = "Loading " + (operation.progress * 100) + "%";
                if (operation.progress >= 0.9f)
                {
                    m_Text.text = "Press the space bar to continue";
                    if (Input.GetKeyDown(KeyCode.Space))
                        operation.allowSceneActivation = true;
                }
            yield return null;
        }   

            
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
