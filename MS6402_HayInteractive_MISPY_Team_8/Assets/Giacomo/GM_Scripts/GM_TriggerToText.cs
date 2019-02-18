using UnityEngine;

public class GM_TriggerToText : MonoBehaviour
{
    public GameObject go_TextHolder;

    private void Start()
    {
        go_TextHolder.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            go_TextHolder.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            go_TextHolder.SetActive(false);
        }
    }
}