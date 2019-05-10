using UnityEngine;
using UnityEngine.SceneManagement;

public class GC_Change_Level : MonoBehaviour
{
    public GameObject go_PressE;
    private bool bl_ReadyToExit = false;
    public string st_levelname;
    public GameObject go_player;


    void Start()
    {
        go_player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == go_player)
        {
            Debug.Log("Its this");
            go_PressE.SetActive(true);
            bl_ReadyToExit = true;
        }
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