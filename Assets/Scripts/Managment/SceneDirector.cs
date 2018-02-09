using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    public static SceneDirector director;

    private void Awake()
    {
        if (director == null) { director = this; }
        else { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(float scene)
    {
        if (scene == 0) { SceneManager.LoadScene("Title"); }
    }
}
