using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMonster : MonoBehaviour {

    public GameObject monsterPrefab;
    private GameObject monster;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private bool CanPlaceMonster()
    {
        return monster == null;
    }


    private void OnMouseUp()
    {
        if (CanPlaceMonster())
        {
            monster = Instantiate(monsterPrefab, transform.position, Quaternion.identity);
        }
    }

}
