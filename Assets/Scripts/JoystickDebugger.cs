using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickDebugger : MonoBehaviour
{
    public Text report;

    private void OnEnable()
    {
        InputManager.Main_X += MainX;
    }

    private void MainX(int controller, float level)
    {
        if (controller == 2)
        {
            report.text = "Joystick: " + controller + " at " + level;
        }
    }
}
