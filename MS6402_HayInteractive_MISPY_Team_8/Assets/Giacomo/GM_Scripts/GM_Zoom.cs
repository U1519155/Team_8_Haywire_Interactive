using UnityEngine;

public class GM_Zoom : MonoBehaviour
{
    public float fl_Zoom = 30f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (Camera.main.fieldOfView <= 125)
                Camera.main.fieldOfView -= fl_Zoom * Time.deltaTime;
            if (Camera.main.fieldOfView < 30) Camera.main.fieldOfView = 30;
        }

        if (!Input.GetKey(KeyCode.Mouse1))
        {
            if (Camera.main.fieldOfView > 2)
                Camera.main.fieldOfView += fl_Zoom * Time.deltaTime;
            if (Camera.main.fieldOfView > 60) Camera.main.fieldOfView = 60;
        }
    }
}