using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class WriteJSON : MonoBehaviour
{
    public ShipParts test = new ShipParts("Body", "default", 0 ,0);
    JsonData writeTest;

    private void Start()
    {
        writeTest = JsonMapper.ToJson(test);
        File.WriteAllText(Application.dataPath + "/Jsons/fileName.json", writeTest.ToString());
    }
}

public class ShipParts
{
    public string type;
    public string name;
    public int value;
    public float mass;

    public ShipParts(string type, string name, int value, float mass)
    {
        this.type = type;
        this.name = name;
        this.value = value;
        this.mass = mass;
    }
}
