using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickDetection : MonoBehaviour
{
    JoystickDetection instance;

    public Animator anim;
    public Text data;
    public Text searching;
    public Text report;
    public Text caution;

    private int joyCount;
    private bool multiplayer;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    private void Start()
    {
        anim.Play("OnStart");
    }

    public void Begin()
    {
        anim.Play("Data1");
    }
    public void DataText()
    {
        data.text = "Checking for input devices";
        StartCoroutine("StartSearch");
    }
    private IEnumerator StartSearch()
    {
        yield return new WaitForSeconds(1);
        Search();
    }


    private void Search()
    {
        anim.Play("StartSearch");
    }

    public void SearchInitiated()
    {
        joyCount = Input.GetJoystickNames().Length;
        StartCoroutine("Searching");
    }
    private IEnumerator Searching()
    {
        int x = 0;
        while (x < 3)
        {
            for (int i = 0; i < 6; ++i)
            {
                if (i == 0) { searching.text = "Searching"; }
                else if (i == 1 || i == 5) { searching.text = "<Searching>"; }
                else if (i == 2 || i == 4) { searching.text = "< Searching >"; }
                else if (i == 3) { searching.text = "<  Searching  >"; }
                else { searching.text = " "; }
                yield return new WaitForSeconds(0.25f);
            }
            ++x;
        }

        StartCoroutine("Detected");
    }

    private IEnumerator Detected()
    {
        searching.text = "><";
        yield return new WaitForSeconds(0.25f);
        searching.text = ">Scan Complete<";
        yield return new WaitForSeconds(3);
        SearchEnded();
    }

    private void SearchEnded()
    { 
        anim.Play("EndSearch");
    }
    public void ScanComplete()
    {
        if (joyCount == 0) { data.text = "No Devices Found!"; }
        else if (joyCount == 1) { data.text = "1 Device Found"; }
        else { data.text = joyCount + " Devices Found"; }
        anim.Play("PrepReport");
    }
    public void PrepReport()
    {
        if      (joyCount == 0) { anim.Play("OpenReport0"); }
        else if (joyCount == 1) { anim.Play("OpenReport1"); }
        else { anim.Play("OpenReport2"); }

       
    }

    private void GetReport(int num)
    {
        
    }
}
