﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_TabIdentity : MonoBehaviour
{
    public GameObject go_PressTab;
    private bool bl_TabPressed = false;
    private bool bl_HPressed = true;
    private bool bl_FuckingFuck = false;
    public GameObject Identity_K;
    public GameObject Identity_Kevin;
    public GameObject Identity_Richard;
    public GameObject go_NoQR_K;
    public GameObject go_NoQR_Kevin;
    public GameObject go_NoQR_Richard;
    public GM_TriggerChoose ClassChoose;

    private void Start()
    {
        go_PressTab.SetActive(true);
        go_NoQR_K.SetActive(false);
        go_NoQR_Kevin.SetActive(false);
        go_NoQR_Richard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (bl_HPressed == true)
            {
                go_PressTab.SetActive(false);
                bl_HPressed = false;
            }

            else if (bl_HPressed == false)
            {
                go_PressTab.SetActive(true);
                bl_HPressed = true;
            }
        }

        if (bl_FuckingFuck == true)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (ClassChoose.bl_Kevin == true)
                {
                    go_NoQR_Kevin.SetActive(true);
                }

                if (ClassChoose.bl_Richard == true)
                {
                    go_NoQR_Richard.SetActive(true);
                }

                if (ClassChoose.bl_Kayode == true)
                {
                    go_NoQR_K.SetActive(true);
                }

                Identity_K.SetActive(false);
                Identity_Kevin.SetActive(false);
                Identity_Richard.SetActive(false);
                bl_FuckingFuck = false;
            }
        }

        if (bl_FuckingFuck == false)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                go_NoQR_K.SetActive(false);
                go_NoQR_Kevin.SetActive(false);
                go_NoQR_Richard.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (bl_TabPressed == false)
            {
                if (ClassChoose.bl_Kevin == true)
                {
                    Identity_Kevin.SetActive(true);
                    bl_TabPressed = true;
                    bl_FuckingFuck = true;
                }

                if (ClassChoose.bl_Richard == true)
                {
                    Identity_Richard.SetActive(true);
                    bl_TabPressed = true;
                    bl_FuckingFuck = true;
                }

                if (ClassChoose.bl_Kayode == true)
                {
                    Identity_K.SetActive(true);
                    bl_TabPressed = true;
                    bl_FuckingFuck = true;
                }
            }

            else if (bl_TabPressed == true)
            {
                if (ClassChoose.bl_Kevin == true)
                {
                    Identity_Kevin.SetActive(false);
                    bl_TabPressed = false;
                }

                if (ClassChoose.bl_Richard == true)
                {
                    Identity_Richard.SetActive(false);
                    bl_TabPressed = false;
                }

                if (ClassChoose.bl_Kayode == true)
                {
                    Identity_K.SetActive(false);
                    bl_TabPressed = false;
                }
            }
        }
    }
}