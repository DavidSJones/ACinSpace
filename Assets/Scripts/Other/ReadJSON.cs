using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class ReadJSON : MonoBehaviour
{
    private string JSONstring;
    private JsonData testing;

    void Start()
    {
        JSONstring = File.ReadAllText(Application.dataPath + "/Jsons/fileName.json");
        testing = JsonMapper.ToObject(JSONstring); //acts like dictionary

        Debug.Log(testing["type"]);
        //Debug.Log(GetItem("Body", "default")["mass"]);
        
	}
	
	private JsonData GetItem(string name, string type)
    {
        for (int i = 0; i < testing[type].Count; ++i)
        {
            if (testing[type][i]["name"].ToString() == name)
            {
                return testing[type][i];
            }
        }
        return null;
    }
}
