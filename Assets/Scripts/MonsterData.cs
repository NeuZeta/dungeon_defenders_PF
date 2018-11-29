using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterData : MonoBehaviour {

    public List<MonsterType> types;

    [System.Serializable]
    public class MonsterType
    {
        public int cost;
        //public int sellPrice;
        public GameObject visualization;
        //public int damage;
    }

}
