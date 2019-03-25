using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CaughtCounter;

    public class Prison_toni_Trigger : MonoBehaviour
    {
        

        public int int_TriggerType;
        public Text Prison_Text;
        
        public GameObject Potatoe;
        
        // Start is called before the first frame update
        void Start()
        {
            Prison_Text.text = "";
        }

        // Update is called once per frame
        void Update()
        {
            Potatoe = GameObject.Find("Prison_GameManager");
            
        
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<HH_prison_toniMove>())
            {
                switch (int_TriggerType)
                {
                    case 1:
                        Prison_Text.text = "I have to <color=#e60000>ESCAPE!</color>";
                        return;
                    case 2:
                        Prison_Text.text = "He is almost here";
                        return;
                    case 3:
                        Prison_Text.text = "He is here";
                        return;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<HH_prison_toniMove>())
            {
                Prison_Text.text = "";
            }
        }

    }


