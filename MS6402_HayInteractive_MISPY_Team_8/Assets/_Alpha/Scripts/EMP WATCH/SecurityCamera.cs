using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public GameObject Patricle;
    
    public  GameObject highlightedParticle;
    
    // Start is called before the first frame update
    void Start()
    {
        Patricle.SetActive(false);
        Highlighted(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartCameraCooldown()
    { 
        StartCoroutine(CameraCooldown());
    }

    public void StartHighlightTimer()
    {
        StartCoroutine(TimerHighlight());
    }
    public void StopHighlightTimer()
    {
        StopCoroutine(TimerHighlight());
    }



    IEnumerator TimerHighlight()
    {
        highlightedParticle.SetActive(true);
        if(highlightedParticle == true)
        {
            yield return new WaitForSeconds(1);
            Patricle.SetActive(false);
        }
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
