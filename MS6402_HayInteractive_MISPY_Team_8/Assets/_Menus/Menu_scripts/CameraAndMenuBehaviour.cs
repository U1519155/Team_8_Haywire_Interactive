using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CameraAndMenuBehaviour : MonoBehaviour
{

    public float transistionSpeed = 3.0f;
    public Transform startScreen;
    public Transform mainMenu;
    public Transform optionsMenu;
    public Transform quitOptionScreen;

    Transform currentView;
    //public Transform Options;

    private void Start()
    {
        currentView = transform;
    }


    void LateUpdate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, currentView.rotation, Time.deltaTime * transistionSpeed);
    }

    public void ClickToStart()
    {
        currentView = mainMenu;
    }

    public void ClickedStartGame()
    {
        SceneManager.LoadScene("Tutorial_Scene");
    }

    public void ClickOptions()
    {
        currentView = optionsMenu;
    }
    public void ClickQuit()
    {
        currentView = quitOptionScreen;
    }
    public void ClickedBack()
    {
        currentView = mainMenu;
    }

    public void QuitYes()
    {
        Application.Quit();
    }

    public void QuitNo()
    {
        currentView = mainMenu;
    }
}
