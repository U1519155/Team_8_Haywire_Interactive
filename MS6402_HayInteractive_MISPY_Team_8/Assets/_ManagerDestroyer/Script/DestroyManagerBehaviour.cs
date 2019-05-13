using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManagerBehaviour : MonoBehaviour
{
    public GameObject SelectedGadgetManager;
    public GameObject GM_GameManager;
    // Start is called before the first frame update
    void Start()
    {
        SelectedGadgetManager = GameObject.Find("SelectedGadgetManager");
        GM_GameManager = GameObject.Find("GM_GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        DestroyImmediate(SelectedGadgetManager);
        DestroyImmediate(GM_GameManager);
    }
}
