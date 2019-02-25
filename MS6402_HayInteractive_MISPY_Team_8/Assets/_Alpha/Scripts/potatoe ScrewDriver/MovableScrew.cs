using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableScrew : MonoBehaviour
{
    [SerializeField]
     Vector3 startPos;
    [SerializeField]
     Vector3 endPos;
    [SerializeField]
     Vector3 goalPos;

    public Transform TargetVector;
    public float screwSpeed = 0.3f ;

   // public float maxMovement = 0;

     void Start()
    {
       // startPos = gameObject.transform.position;
       // goalPos = startPos + transform.forward; // Vector3.forward; //* maxMovement;
    }

    // Update is called once per frame
    void Update()
    {
        //endPos = gameObject.transform.position;
        
    }

    public void Rotate()
    {
        // Do your thing.
        //if (endPos == goalPos)
        //{
        //    Debug.Log("YOU HAVE REACHED YOUR DESTINY");
        //    gameObject.SetActive(false);

        //}
        transform.Rotate(0, 0, 20);
      //transform.position += transform.forward * Time.deltaTime;
        transform.position = Vector3.MoveTowards(gameObject.transform.position, TargetVector.position, screwSpeed * Time.deltaTime);

        if (Vector3.Distance(gameObject.transform.position, TargetVector.position) < 0.01)
        {
            Debug.Log("YOU HAVE REACHED YOUR DESTINY");
            gameObject.SetActive(false);
        }
        
        
       
        
    }
}
