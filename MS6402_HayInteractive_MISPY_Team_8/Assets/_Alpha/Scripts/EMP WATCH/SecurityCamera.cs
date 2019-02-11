using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
     public GameObject Patricle;
    // Start is called before the first frame update
    void Start()
    {
        Patricle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartCameraCooldown()
    { 
        StartCoroutine(CameraCooldown());
    }
     IEnumerator CameraCooldown()
    {

        Patricle.SetActive(true);

        if (Patricle == true)
        {
            yield return new WaitForSeconds(10);
            Patricle.SetActive(false);
        }
    }
}
