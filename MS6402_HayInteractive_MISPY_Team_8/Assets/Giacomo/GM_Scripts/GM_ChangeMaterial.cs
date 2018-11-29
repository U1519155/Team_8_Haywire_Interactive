using UnityEngine;

public class GM_ChangeMaterial : MonoBehaviour
{
    // Variables
    public Material mt_InitialMaterial;
    public Material mt_ChangingMaterial;
    public float fl_MaximumTimer = 1.5f;
    private float fl_RandomValues;

    // Use this for initialization
    void Start ()
    {
        gameObject.GetComponent<Renderer>().material = mt_InitialMaterial;
	}
	
	// If the static bool is activated by entering in the trigger carried by the guard, the guard will start talking.
	void Update ()
    {
		if (GM_Suspicion.bl_GuardTalk == true)
        {
            if (fl_RandomValues >= fl_MaximumTimer)
            {
                SetTimer();
                fl_RandomValues = 0f;
                gameObject.GetComponent<Renderer>().material = mt_ChangingMaterial;
            }

            if (fl_RandomValues >= 0.5f)
            {
                gameObject.GetComponent<Renderer>().material = mt_InitialMaterial;
            }

            fl_RandomValues += (Time.deltaTime);

        }

        else if (GM_Suspicion.bl_GuardTalk == false)
        {
            fl_RandomValues = 0;
            gameObject.GetComponent<Renderer>().material = mt_InitialMaterial;
        }
	}

    // This void sets the timer in a random array.
    void SetTimer()
    {
        fl_MaximumTimer = Random.Range(0f, 1.5f);
    }
}