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

        [Header("--Transform--")]
        public Transform player;
        public Transform escapePoint;
        public Transform ballRoomTeleport;
        public Transform kickedOutPoint;
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
                case 0: //player has not been caught
                    switch (escapeCounter)
                    {

                        case 0: //player did not already escape
                            if (metToni == true) //toni met with player before he escaped
                            {
                                player.position = ballRoomTeleport.position;
                                caughtCounter++;
                            }

                            if (hasEscaped == true)
                            {
                                player.position = escapePoint.position;
                                escapeCounter++;   
                            }

                            break;

                        case 1: // player has already escaped
                            if (metToni == false)
                            {
                                metToni = true;
                                player.position = ballRoomTeleport.position;
                                caughtCounter++;  
                            }
                            break;

                    }
                    break;

                case 1: //player has been caught
                    player.position = kickedOutPoint.position;
                    break;

                case 2: //player loses game
                    break;

            }
        }
    }
}
