using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*singleton*/ public static GameManager manager;

    private int profileLastLoaded;
    private int profileRemaining;

    private float currentScene;
    private float lastScene;

    private void Awake()
    {
        if (manager == null) { manager = this; }
        else { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //Scene Tracking
        lastScene = 0;
        currentScene = 0;
        
    }

    private void Update()
    {
        Debug.Log(lastScene + "/" + currentScene);
    }

    public void ChangeScene(float num)
    {
        lastScene = currentScene;
        currentScene = num;
        SceneDirector.director.LoadScene(num);
    }


    //Error Code List
    public static void ErrorDetected(int code)
    {
        if (code == 0001) { /*Controller Not Recognized*/ }
    }
}
