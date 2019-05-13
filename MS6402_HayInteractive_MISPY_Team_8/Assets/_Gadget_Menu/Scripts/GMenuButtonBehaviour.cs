using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GMenuButtonBehaviour : MonoBehaviour
{
    public int gadgetCounter = 0;

    [Header("--Bools--")]
    public bool selectedCigar = false, selectedWatch = false, selectedBowtie = false;
    [Header("--Texts--")]
    public Text cigar, watch, bowtie, loading;
    [Header("--Images--")]
    public Image tick_cigar, tick_watch, tick_bowtie;
    [Header("--Button--")]
    public GameObject startMission;
    // Start is called before the first frame update
    void Start()
    {
        //set txt color to white
        cigar.color = Color.white;
        watch.color = Color.white;
        bowtie.color = Color.white;
        loading.color = new Color(0, 0, 0, 0);

        //turn image alpha to 0
        tick_cigar.color = new Color(0, 0, 0, 0);
        tick_watch.color = new Color(0, 0, 0, 0);
        tick_bowtie.color = new Color(0, 0, 0, 0);

        startMission.SetActive(false);

    }

    void Update()
    {
        if (gadgetCounter == 2)
        {
            startMission.SetActive(true);
        }
        else
        {
            startMission.SetActive(false);
        }
    }



    public void Cigar_Button()
    {
        if(selectedCigar == false && gadgetCounter < 2)
        {
            selectedCigar = true;
            cigar.color = Color.green;
            tick_cigar.color = Color.green;
            gadgetCounter++;
        }
        else if(selectedCigar == true)
        {
            tick_cigar.color = new Color(0, 0, 0, 0);
            cigar.color = Color.white;
            selectedCigar = false;
            gadgetCounter--;
        }
    }

    public void EMPWatch_Button()
    {
        if (selectedWatch == false && gadgetCounter < 2)
        {
            selectedWatch = true;
            watch.color = Color.green;
            tick_watch.color = Color.green;
            gadgetCounter++;
        }
        else if (selectedWatch == true)
        {
            tick_watch.color = new Color(0, 0, 0, 0);
            watch.color = Color.white;
            selectedWatch = false;
            gadgetCounter--;
        }
    }

    public void BowTieScrewdriver_Button()
    {
        if (selectedBowtie == false && gadgetCounter < 2)
        {
            selectedBowtie = true;
            bowtie.color = Color.green;
            tick_bowtie.color = Color.green;
            gadgetCounter++;
        }
        else if (selectedBowtie == true)
        {
            tick_bowtie.color = new Color(0, 0, 0, 0);
            bowtie.color = Color.white;
            selectedBowtie = false;
            gadgetCounter--;
        }
    }

    public void StartingMission()
    {
        StartCoroutine(LoadingNextScene());
    }

    IEnumerator LoadingNextScene()
    {
        loading.color = Color.white;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Beta_LightsOn");
    }
}
