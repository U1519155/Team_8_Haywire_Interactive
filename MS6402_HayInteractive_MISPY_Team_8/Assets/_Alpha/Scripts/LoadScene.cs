using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{

    public string st_SceneName;

    void StartScene()
    {
        SceneManager.LoadScene(st_SceneName);
    }

    void QuitGame()
    {

    }
}