using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class ReadJSON : MonoBehaviour
{
    private string JSONstring;
    private JsonData testing;

	void Start ()
    {
        JSONstring = File.ReadAllText(Application.dataPath + "/Jsons/Change.json");


	}
	
	
}
