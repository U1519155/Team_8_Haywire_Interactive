using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTeleportToPoint : MonoBehaviour
{
    Transform player;
    public Transform restartpoint;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Guard>().spotlight.color == Color.red)
        {
            player.position = restartpoint.position;
        }
    }
}