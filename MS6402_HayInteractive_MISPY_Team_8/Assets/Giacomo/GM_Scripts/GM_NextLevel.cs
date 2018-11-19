using UnityEngine;
using UnityEngine.SceneManagement;

public class GM_NextLevel : MonoBehaviour
{
    public string st_nextLevel;
	
    public void GoToNextLevel()
    {
        //GM_GameManager.bl_EndLevel = false;
        SceneManager.LoadScene(st_nextLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}