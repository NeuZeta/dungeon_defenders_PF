using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotStatus : MonoBehaviour {

    public GameObject Snake, Horns;

    [HideInInspector]
    public GameObject monster;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool CanPlaceMonster()
    {
        return monster == null;
    }


}
