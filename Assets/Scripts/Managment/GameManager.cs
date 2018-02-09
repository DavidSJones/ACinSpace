using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*singleton*/ public static GameManager manager;

    //EVENTS AND DELEGATES
   

    //Scene Managment Section
    public static void ChangeScene (int num)
    {
        if          (num == 00) { SceneManager.LoadScene("Title"); }
        else if     (num == 01) { SceneManager.LoadScene("MainMenu"); }
    }
    //Error Code List
    public static void ErrorDetected(int code)
    {
        if (code == 0001) { /*Controller Not Recognized*/ }
    }
}
