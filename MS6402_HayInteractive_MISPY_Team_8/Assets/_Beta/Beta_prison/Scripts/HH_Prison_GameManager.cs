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
        public bool hasEscaped;
        public bool gotCaught;
       

        [Header("--Ints--")]
        public int caughtCounter;
        public int escapeCounter;

        [Header("--GameObjects--")]
        [Tooltip("GameObject Must Be Named: Player")]
        public GameObject player;
        [Tooltip("GameObject Must Be Named: Prison_Jail_Point")]
        public GameObject playerJailPoint;
        [Tooltip("GameObject Must Be Named: Escape_Point")]
        public GameObject escapePoint;
        [Tooltip("GameObject Must Be Named: Ball_Room_Teleport")]
        public GameObject ballRoomTeleport;
        [Tooltip("GameObject Must Be Named: Kicked_Out_Point")]
        public GameObject kickedOutPoint;
        // Start is called before the first frame update
        void Awake()
        {



        }

        // Update is called once per frame
        void Update()
        {
            player = GameObject.Find("Player");
            playerJailPoint = GameObject.Find("Prison_Jail_Point");
            escapePoint = GameObject.Find("Escape_Point");
            ballRoomTeleport = GameObject.Find("Ball_Room_Teleport");
            kickedOutPoint = GameObject.Find("Kicked_Out_Point");
           
            CaughtCounterChecker();
            //print("LOL i escape? = " + hasEscaped);
        }

        public void CaughtCounterChecker()
        {
            switch (caughtCounter)
            {
                case 0: 
                    
                    break;

                case 1: //player has been caught
                    

                    switch (escapeCounter)
                    {

                        case 0: //player did not already escape
                            if (gotCaught == true)
                            {
                                player.transform.position = playerJailPoint.transform.position;
                                gotCaught = false;
                            }
                            if (metToni == true) //toni met with player before he escaped
                            {
                                player.transform.position = ballRoomTeleport.transform.position;
                                caughtCounter++;
                            }

                            if (hasEscaped == true)
                            { 
                                player.transform.position = escapePoint.transform.position;
                                escapeCounter++;
                            }

                            break;

                        case 1: // player has already escaped

                            if (gotCaught == true)
                            {
                                player.transform.position = playerJailPoint.transform.position;
                                if (metToni == false)
                                {
                                    //"play cutscene"
                                    StartCoroutine(EscapedAndMeetToni());

                                }
                                gotCaught = false;

                            }

                            break;
                    }
                    break;

                case 2:
                    if (gotCaught == true)
                    {
                        player.transform.position = ballRoomTeleport.transform.position;   
                        caughtCounter++;
                        gotCaught = false;
                    }

                    break;
                case 3:
                    if (gotCaught == true)
                    {
                        player.transform.position = kickedOutPoint.transform.position;                   
                        caughtCounter++;
                        gotCaught = false;
                    }
                    break;

            }
        }

        IEnumerator EscapedAndMeetToni()
        {
            yield return new WaitForSeconds(5);
            player.transform.position = ballRoomTeleport.transform.position;
            caughtCounter++;
            metToni = true;
        }
    }
}
