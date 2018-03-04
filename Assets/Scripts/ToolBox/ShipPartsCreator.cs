using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShipPart;

public class ShipPartsCreator : MonoBehaviour
{
    private bool _external;
    private string _type;
    private string _name;
    private float _mass;
    private float _stealth;    //Used to modifiy signature (Range from -25% to +25%)
    private float _armor;      //0 for internal parts
    private float _defense;    //0 for most internal parts
    private float _manuvering;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
