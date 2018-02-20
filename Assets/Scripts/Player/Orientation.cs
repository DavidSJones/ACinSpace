using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientation : MonoBehaviour
{
    private Rigidbody body;
    private float maxManeuvering;

    private int leftRoll;
    private int riteRoll;

    private void OnEnable()
    {
        InputManager.Scnd_X += Yaw;
        InputManager.Scnd_Y += Pitch;
        InputManager.LfBump += RollLeft;
        InputManager.RtBump += RollRite;
    }

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        maxManeuvering = 10;
    }

    private void Update()
    {
        Debug.Log(leftRoll + "/" + riteRoll);
        CheckRoll();
    }

    private void Yaw(int player, float level)
    {
        float newLevel;

        if (level < -0.5) { newLevel = -0.5f; }
        else if (level > 0.5) { newLevel = 0.5f; }
        else { newLevel = level; }

        body.transform.Rotate(Vector3.up, (newLevel * 2) * maxManeuvering);
    }

    private void Pitch(int player, float level)
    {
        float newLevel;

        if (level < -0.5) { newLevel = -0.5f; }
        else if (level > 0.5) { newLevel = 0.5f; }
        else { newLevel = level; }

        body.transform.Rotate(Vector3.left, (newLevel * 2) * maxManeuvering);
    }

    private void RollLeft(int player, int level)
    {
        if (level > 0)
        {
            leftRoll = 1; Debug.Log("Left");
            body.transform.Rotate(Vector3.back, (maxManeuvering / 2) * -1);
            
        }
        //else if (level == 0) { leftRoll = 0; }
    }

    private void RollRite(int player, int level)
    {
        if (level > 0)
        {
            body.transform.Rotate(Vector3.back, maxManeuvering / 2);
            riteRoll = 1;
        }
        //else { riteRoll = 0; }
    }

    private void CheckRoll()
    {
        if (leftRoll == 1 && riteRoll ==1) { Debug.Log("Both"); }
    }
}
