using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{

    public Animator anim;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(30);
        TransOut();
    }

    private void Update()
    {
        if (Input.anyKeyDown) { TransOut(); }
    }

    private void TransOut()
    {
        anim.Play("TransOut");
        
    }
    public void LoadNextScene ()
    { 
        GameManager.ChangeScene(01); 		
	}
}
