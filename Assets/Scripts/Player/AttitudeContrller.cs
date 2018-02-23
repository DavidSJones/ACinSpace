using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttitudeContrller : MonoBehaviour
{
    private Rigidbody body;
    private float maxManeuvering;

    private void OnEnable()
    {
        InputManager.Scnd_X += Yaw;
        InputManager.Scnd_Y += Pitch;
        InputManager.LfBump += RollLeft;
        InputManager.RtBump += RollRite;
        InputManager.UpperB += AutoLevel;
    }

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        maxManeuvering = 10;
    }
    
    private void Yaw(int player, float level)
    {
        if (player == PlayerController.MyNumber())
        {
            float newLevel;

            if (level < -0.5) { newLevel = -0.5f; }
            else if (level > 0.5) { newLevel = 0.5f; }
            else { newLevel = level; }

            body.transform.Rotate(Vector3.up, (newLevel * 2) * maxManeuvering);
        }
    }

    private void Pitch(int player, float level)
    {
        if (player == PlayerController.MyNumber())
        {
            float newLevel;

            if (level < -0.5) { newLevel = -0.5f; }
            else if (level > 0.5) { newLevel = 0.5f; }
            else { newLevel = level; }

            body.transform.Rotate(Vector3.left, (newLevel * 2) * maxManeuvering);
        }
    }

    private void RollLeft(int player, int level)
    {
        if (player == PlayerController.MyNumber())
        {
            if (level > 0)
            {
                body.transform.Rotate(Vector3.back, (maxManeuvering / 2) * -1);
            }
        }
    }

    private void RollRite(int player, int level)
    {
        if (player == PlayerController.MyNumber())
        {
            if (level > 0)
            {
                body.transform.Rotate(Vector3.back, maxManeuvering / 2);
            }
        }
    }
    
    private void AutoLevel(int player, int level)
    {
        if (player == PlayerController.MyNumber() && level == 1)
        {
            float y = body.transform.eulerAngles.y;
            body.transform.eulerAngles = new Vector3(0, y, 0);

        }
    }
}