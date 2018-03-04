using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipPart
{
    public class ShipPart
    {
        #region Input varibles common to all parts
        public bool     partExternal;
        public string   partType;
        public string   partName;
        public float    partMass;
        public float    partStealth;    //Used to modifiy signature (Range from -25% to +25%)
        public float    partArmor;      //0 for internal parts
        public float    partDefense;    //0 for most internal parts
        public float    partManuvering; 
        #endregion
        #region Calculated varibles common to all parts
        public float partPowerRequired; //Formula based on type
        public float partSignature;
        public float partDurability;    //usually 0 for internal parts
        #endregion
        #region Input varibles specific to part type
        public float partCapacity; //Main Body
        #endregion

        //Constructor mainly collects data to pass and process in subfuctions
        public ShipPart
            (bool external, string type, string name,
            float mass, float stealth, float armor, float defense, float manuvering,
            float cap)
        {
            this.partExternal = external;
            this.partType = type;
            this.partName = name;
            this.partMass = mass;
            this.partStealth = stealth;
            this.partArmor = armor;
            this.partDefense = defense;
            this.partManuvering = manuvering;

            if (partExternal) { ExternalPart(this.partType, this.partMass, cap); }
        }

        private void ExternalPart(string type, float mass, float cap)
        {
            this.partCapacity = (this.partType == "Main Body") ? cap : 0;
            if (type == "MainBody") { /*Body*/; }
        }

        private void Body(float cap)
        {
            this.partCapacity = cap;
            this.partPowerRequired = this.partMass + (this.partCapacity * 2) + 50;
        }
    }
}