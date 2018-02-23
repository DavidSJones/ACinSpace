using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterControl : MonoBehaviour
{
    private Rigidbody body;
    private float maxThrust;

    private void OnEnable()
    {
        InputManager.Main_X += Latteral;
        InputManager.Main_Y += ForeAft;
        InputManager.LfClik += LiftOff;
        InputManager.RtClik += Landing;
        InputManager.OuterB += AllStop;
    }

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        maxThrust = 15;
    }

    private void Latteral(int player, float level)
    {
       if (player == PlayerController.MyNumber())
        {
            body.AddForce(body.transform.right * (maxThrust * level));
        }
    }

    private void ForeAft(int player, float level)
    {
        if (player == PlayerController.MyNumber())
        {
            body.AddForce(body.transform.forward * (-1 *(maxThrust * level)));
        }
    }

    private void LiftOff(int player, int level) { if (player == PlayerController.MyNumber() && level > 0) { VTAL(1); } }
    private void Landing(int player, int level) { if (player == PlayerController.MyNumber() && level > 0) { VTAL(-1); } }
    private void VTAL (int direction)
    {
        if      (direction == 1) { body.AddForce(body.transform.up * ((maxThrust*0.5f) * direction)); }
        else if (direction == -1) { body.AddForce(body.transform.up * ((maxThrust * 0.5f) * direction)); }
    }

    private void AllStop(int player, int level)
    {
        if (player == PlayerController.MyNumber() && level > 0) { body.velocity = Vector3.zero; }
    }
}
