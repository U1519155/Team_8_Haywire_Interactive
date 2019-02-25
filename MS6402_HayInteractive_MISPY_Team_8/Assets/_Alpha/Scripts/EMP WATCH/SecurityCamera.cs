using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public GameObject Patricle;
    Guard setlight;
   
    
    // Start is called before the first frame update
    void Start()
    {
        Patricle.SetActive(false);
        setlight = GetComponent<Guard>();


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
        setlight.enabled = false;

        if (Patricle == true)
        {
            yield return new WaitForSeconds(10);
            Patricle.SetActive(false);
            setlight.enabled = true;
        }
    }
}
