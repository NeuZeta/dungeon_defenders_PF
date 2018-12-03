using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyLevels : MonoBehaviour {

    public GameObject[] MonsterPrefabs;
    public int currentLevel;
    public int familyIndex;


	// Use this for initialization
	void Start () {
        currentLevel = 0;

        if (gameObject.tag == "Horns")
        {
            familyIndex = 0;
        }
        else if (gameObject.tag == "Snake")
        {
            familyIndex = 1;
        }
	}

    public void SetCorrectMonster()
    {
        Debug.Log("Se está comprobando el nivel?");

        foreach (GameObject monster in MonsterPrefabs)
        {
            monster.SetActive(false);
        }
        MonsterPrefabs[currentLevel].SetActive(true);

    }

    public void UpgradeLevel()
    {
        currentLevel++;

        foreach (GameObject monster in MonsterPrefabs)
        {
            monster.SetActive(false);
        }
        MonsterPrefabs[currentLevel].SetActive(true);
    }


}
