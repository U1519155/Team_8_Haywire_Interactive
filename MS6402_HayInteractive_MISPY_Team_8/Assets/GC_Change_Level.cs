using UnityEngine;
using UnityEngine.SceneManagement;

public class GC_Change_Level : MonoBehaviour
{
    public GameObject go_PressE;
    private bool bl_ReadyToExit = false;
    public string st_levelname;
    private void OnTriggerEnter(Collider other)
    {
        go_PressE.SetActive(true);
        bl_ReadyToExit = true;
    }

    private void OnTriggerExit(Collider other)
    {
        go_PressE.SetActive(false);
        bl_ReadyToExit = false;
    }

    private void Update()
    {
        if (bl_ReadyToExit == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(st_levelname);
            }
        }
    }
}