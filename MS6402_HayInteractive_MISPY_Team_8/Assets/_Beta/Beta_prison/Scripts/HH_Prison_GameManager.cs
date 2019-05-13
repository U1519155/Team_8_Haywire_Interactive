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
        public bool stopSpamming = true;
        public bool stopSpammingAgin = true;
        public bool pleaseWork = true;

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
        public GameObject[] escapepoints;


        IEnumerator ToniIsComming01;
        IEnumerator ToniIsComming02;

        IEnumerator MeetToni001;
        IEnumerator MeetToni002;

        void Start()
        {
            ToniIsComming01 = ToniIsComming();
            ToniIsComming02 = ToniIsComming();

            MeetToni001 = MeetToni();
            MeetToni002 = MeetToni();
        }

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
                    if (gotCaught == true && escapeCounter == 1)
                    {
                        player.transform.position = playerJailPoint.transform.position;
                        gotCaught = false;
                    }

                    switch (escapeCounter)
                    {
                        case 1: //player did not already escape                

                            if (stopSpamming == true)
                            {
                                StartCoroutine(ToniIsComming01);
                                stopSpamming = false;
                            }

                            //if (metToni == true) //toni met with player before he escaped
                            //{
                            //    player.transform.position = ballRoomTeleport.transform.position;
                            //   // caughtCounter++;
                            //}

                            if (hasEscaped == true) //player escaped 
                            {
                                
                                foreach (GameObject escapeBox in escapepoints)
                                {
                                    Destroy(escapeBox);
                                }
                                
                                escapeCounter++;
                            }

                            break;

                        case 2: //player has already escaped
                            if (pleaseWork == true)
                            {
                                StopCoroutine(MeetToni001);
                                StopCoroutine(ToniIsComming01);
                                escapeCounter++;
                                pleaseWork = false;
                                
                            }

                            break;
                        case 3:
                            if (gotCaught == true)
                            {
                                //"play cutscene"
                                player.transform.position = playerJailPoint.transform.position;
                                if (stopSpammingAgin == true)
                                {

                                    StartCoroutine(MeetToni002);

                                    stopSpammingAgin = false;
                                }
                                gotCaught = false;
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
                    SceneManager.LoadScene("Level_failure");
                        break;
            }
        }



        IEnumerator ToniIsComming()
        { 
            yield return new WaitForSeconds(20);
                StartCoroutine(MeetToni());
            Debug.Log("TONI IS COMMING");
            yield break;
        }

        IEnumerator MeetToni()
        {
            //transform player infront of Toni
            //StopCoroutine(ToniIsComming());
            Debug.Log("Mistic YOU FUCKING DID IT");
            prisonToni.transform.position = player.transform.position + Vector3.forward;
            yield return new WaitForSeconds(10); // timer for dialog
            prisonToni.gameObject.SetActive(false);
            player.transform.position = ballRoomTeleport.transform.position;
            Debug.Log("TONI IS hHERE");
            caughtCounter++;
            metToni = true;
            yield break;

        }


    }
}
