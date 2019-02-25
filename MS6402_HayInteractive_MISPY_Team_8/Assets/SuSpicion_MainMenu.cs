using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuSpicion_MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GM_Suspicion.in_Suspicion = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GM_Suspicion.in_Suspicion >= 2)
        {
            SceneManager.LoadScene("Start_Menu");
        }
    }
}