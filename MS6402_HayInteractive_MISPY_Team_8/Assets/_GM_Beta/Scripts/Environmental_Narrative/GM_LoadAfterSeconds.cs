using UnityEngine;
using UnityEngine.SceneManagement;

public class GM_LoadAfterSeconds : MonoBehaviour
{
    //Variables
    public string st_NameScene;
    public float fl_SecondsToElapse = 40;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadMeSeconds", fl_SecondsToElapse);
    }

    void LoadMeSeconds()
    {
        SceneManager.LoadScene(st_NameScene);
    }
}