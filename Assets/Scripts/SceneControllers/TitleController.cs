using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{

    public Animator anim;

    private bool player;
    private bool profile;

    private IEnumerator Start()
    {
        player = false;

        int last = PlayerPrefs.GetInt("lastProfile", 0);
        if (last == 0) { profile = false; }
        else { profile = true; }

        yield return new WaitForSecondsRealtime(15);
        TransOut();
    }

    private void Update()
    {
        if (Input.anyKeyDown) { Interupt(); }
    }

    private void TransOut()
    {
        anim.Play("TitleFadeOut");
        
    }
    private void Interupt()
    {
        player = true;
        anim.Play("TitleInterupt");
    }
    private void LoadNextScene()
    {
        if (!player)
        {
            GameManager.manager.ChangeScene(01.00f);
        }
        if (player)
        {
            if (profile)
            {
                GameManager.manager.ChangeScene(01.10f);
            }
            else { GameManager.manager.ChangeScene(01.00f); }
        }

    }
}
