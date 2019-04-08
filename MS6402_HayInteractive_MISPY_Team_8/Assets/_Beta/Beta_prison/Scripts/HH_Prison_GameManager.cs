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
        public bool hasEscaped = false;
        public bool gotCaught;

        [Header("--Ints--")]
        public int caughtCounter;
        public int escapeCounter;

        [Header("--GameObjects--")]
        [Tooltip("GameObject Must Be Named: Player")]
        public GameObject player;
        [Tooltip("GameObject Must Be Named: Prison_Jail_Point")]
        public GameObject playerJailPoint;
        //[Tooltip("GameObject Must Be Named: Escape_Point")]
        //public GameObject escapePoint;
        [Tooltip("GameObject Must Be Named: Ball_Room_Teleport")]
        public GameObject ballRoomTeleport;
        [Tooltip("GameObject Must Be Named: Kicked_Out_Point")]
        public GameObject kickedOutPoint;
        [Tooltip("GameObject Must Be Named: Prison_Toni")]
        public GameObject prisonToni;

        [Header("--Escape boxes GameObjects--")]
        GameObject[] escapepoints;


        // Start is called before the first frame update

        // Update is called once per frame
        void Update()
        {
            if (player == null)
            {
                player = GameObject.Find("Player");
            }

            if (playerJailPoint == null)
            {
                playerJailPoint = GameObject.Find("Prison_Jail_Point");
            }
            //if (escapePoint == null)
            //{
            //    escapePoint = GameObject.Find("Escape_Point");
            //}
            if (ballRoomTeleport == null)
            {
                ballRoomTeleport = GameObject.Find("Ball_Room_Teleport");
            }
            if (player == null)
            {
                player = GameObject.Find("Player");
            }
            if (kickedOutPoint == null)
            {
                kickedOutPoint = GameObject.Find("Kicked_Out_Point");
            }

            if(prisonToni == null)
            {
                prisonToni = GameObject.Find("Prison_Toni");
            }
           // playerJailPoint = GameObject.Find("Prison_Jail_Point");
           // escapePoint = GameObject.Find("Escape_Point");
           // ballRoomTeleport = GameObject.Find("Ball_Room_Teleport");
           // kickedOutPoint = GameObject.Find("Kicked_Out_Point");
           
            CaughtCounterChecker();
            //print("LOL i escape? = " + hasEscaped);
        }

        public void CaughtCounterChecker()
        {
            switch (caughtCounter)
            {
                case 0: //player has been caught
                    if (gotCaught == true && escapeCounter == 0)
                    {
                        player.transform.position = playerJailPoint.transform.position;
                        gotCaught = false;
                        escapeCounter++;
                    }
                    if (gotCaught == true && escapeCounter >= 1)
                    {
                        player.transform.position = playerJailPoint.transform.position;
                        gotCaught = false;
                    }
                    switch (escapeCounter)
                    {
                        case 1: //player did not already escape
                            
                            StartCoroutine(ToniIsComming());

                            //if (metToni == true) //toni met with player before he escaped
                            //{
                            //    player.transform.position = ballRoomTeleport.transform.position;
                            //   // caughtCounter++;
                            //}

                            if (hasEscaped == true) //player escaped 
                            {
                                StopAllCoroutines();
                                //player.transform.position = escapePoint.transform.position;
                                foreach (GameObject escapeBox in escapepoints)
                                {
                                    Destroy(escapeBox);
                                }
                                
                                escapeCounter++;
                            }

                            break;

                        case 2: //player has already escaped
                            
                                if (metToni == false)
                                {
                                    //"play cutscene"
                                    StartCoroutine(MeetToni());
                                }

                            break;
                    }
                    break;

                case 1:
                    if (gotCaught == true)
                    {
                        player.transform.position = ballRoomTeleport.transform.position;   
                        caughtCounter++;
                        gotCaught = false;
                    }
                    break;

                case 2:
                    if (gotCaught == true)
                    {
                        player.transform.position = kickedOutPoint.transform.position;                   
                        caughtCounter++;
                        gotCaught = false;
                    }
                    break;
                case 3:
                    Debug.Log("game over");
                        break;
            }
        }

        IEnumerator ToniIsComming()
        { 
            yield return new WaitForSeconds(10);
            if (hasEscaped == false)
            {
                StartCoroutine(MeetToni());
            }
        }

        IEnumerator MeetToni()
        {
            //transform player infront of Toni
            prisonToni.transform.position = player.transform.position + Vector3.forward;

            yield return new WaitForSeconds(10); // timer for dialog
            prisonToni.gameObject.SetActive(false);
            player.transform.position = ballRoomTeleport.transform.position;
            caughtCounter++;
            metToni = true;
        }


    }
}
