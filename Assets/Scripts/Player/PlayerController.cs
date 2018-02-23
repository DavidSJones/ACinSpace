using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public  int playerNumber;
    private static int joystickNumb;
    private Rigidbody body;
	
	void Start ()
    {
        body = GetComponent<Rigidbody>();
        joystickNumb = PlayerPrefs.GetInt("Player" + playerNumber + "Joystick", playerNumber);

        if (playerNumber == 1) { gameObject.layer = 8; }
        else if (playerNumber == 2) { gameObject.layer = 9; }
	}

    public static int MyNumber() { return joystickNumb; }
}
