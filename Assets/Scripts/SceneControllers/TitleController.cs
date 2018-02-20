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
        profile = false;
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
    public void LoadNextScene()
    {
        if (!player)
        {
            SceneDirector.director.LoadScene(01.00f);
        }
        if (player)
        {
            if (profile)
            {
                SceneDirector.director.LoadScene(01.10f);
            }
            else { SceneDirector.director.LoadScene(01.00f); }
        }

    }
}
