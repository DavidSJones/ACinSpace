using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    private float goodLod;
    private float goodNew;
    private float goodOpt;
    private float goodChg;
    private float goodExt;

    private int selected;

    private float tempY;

    private void OnEnable()
    {
       
    }

    private void Start()
    {
        tempY = 0;
        selected = 1;
    }

    private void Update()
    {
        
    }

    private void ChangeSelected()
    {
        
    }

    private void NavigateMenu(int controller, float level)
    {
        int move = selected;

        if (controller == 1 && tempY == 0)
        {
            if (level < 0) { move -= 1; tempY = 1; }
            else if (level > 0) { move += 1; tempY = 1; }
        }
        
        if (move < 1) { move = 4; }
        else if (move > 4) { move = 1; }

        tempY = level;
    }
}
