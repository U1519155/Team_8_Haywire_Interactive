using UnityEngine;

public class GM_StartAnim : MonoBehaviour {

    //Variables
    public GameObject go_Girl1;
    public GameObject go_Girl; 
    private float fl_FixedCooldown;
    public float fl_Timer = 3;


    void Update()
    {
        fl_FixedCooldown += (Time.deltaTime);

        if (fl_FixedCooldown >= fl_Timer)
        {
            SetRange();
            go_Girl.SetActive(true);
            go_Girl1.SetActive(false);
            fl_FixedCooldown = 0;
        }

        if (fl_FixedCooldown >= 0.5f)
        {
            go_Girl.SetActive(false);
            go_Girl1.SetActive(true);
        }
    }

    void SetRange()
    {
        fl_Timer = Random.Range(0.0f, 3.0f);
    }
}
