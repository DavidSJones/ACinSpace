using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{
    public static ProfileManager profiler;

    private int maxProfiles;

    public delegate void ProfileCount(int profiles);
    public static event ProfileCount profileCount;

    private void Awake()
    {
        if (profiler == null) { profiler = this; }
    }

    private void Start()
    {
        maxProfiles = 5;
    }
    public void CreateNew()
    {

    }
}
