using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyLevels : MonoBehaviour {

    public GameObject[] MonsterPrefabs;
    public int currentLevel;


	// Use this for initialization
	void Start () {
        currentLevel = 0;
	}

    public void SetCorrectMonster()
    {

        foreach (GameObject monster in MonsterPrefabs)
        {
            monster.SetActive(false);
        }
        MonsterPrefabs[currentLevel].SetActive(true);

    }

}
