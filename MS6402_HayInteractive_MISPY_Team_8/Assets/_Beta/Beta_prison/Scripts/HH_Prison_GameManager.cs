using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CaughtCounter
{
    public class HH_Prison_GameManager : MonoBehaviour
    {


        [Header("--Bools--")]
        public bool metToni = false;
        public static bool hasEscaped;

        [Header("--Ints--")]
        public int caughtCounter;
        public int escapeCounter;


        // Start is called before the first frame update
        void Awake()
        {



        }

        // Update is called once per frame
        void Update()
        {
            CaughtCounterChecker();
            print("LOL i escape? = " + hasEscaped);
        }

        public void CaughtCounterChecker()
        {
            switch (caughtCounter)
            {
                case 0:
                    switch (escapeCounter)
                    {
                        case 0:
                            if (metToni == true)
                            {
                                caughtCounter++;
                                SceneManager.LoadScene("Beta_LevelMap");
                            }

                            if (hasEscaped == true)
                            {
                                escapeCounter++;
                                SceneManager.LoadScene("Beta_LevelMap");
                            }

                            break;

                        case 1:
                            if (metToni == false)
                            {
                                metToni = true;
                                caughtCounter++;
                            }
                            break;
                    }
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;


            }
        }
    }
}
