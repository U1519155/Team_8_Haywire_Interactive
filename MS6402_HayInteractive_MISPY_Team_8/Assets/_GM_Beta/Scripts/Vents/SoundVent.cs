using UnityEngine;

public class SoundVent : MonoBehaviour
{
    //Variables
    public AudioSource as_Source;
    public AudioClip ac_Clip;
    public GameObject[] go_Camera_Systems;

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject i in go_Camera_Systems)
        {
            if (i.activeInHierarchy == true)
            {
                as_Source.clip = ac_Clip;

                if (as_Source.isPlaying == false)
                {
                    as_Source.PlayOneShot(ac_Clip);
                }
            }

            else if (i.activeInHierarchy == false)
            {
                as_Source.Stop();
            }
        }
    }
}