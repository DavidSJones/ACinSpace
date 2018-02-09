using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{
    private string[] users = new string[6];

	void Start ()
    {
        PlayerPrefs.GetInt("UsedProfiles", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
