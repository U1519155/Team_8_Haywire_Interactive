using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{

    public string st_SceneName;

    public void StartScene()
    {
        SceneManager.LoadScene(st_SceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}