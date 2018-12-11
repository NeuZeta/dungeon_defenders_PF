using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuController002 : MonoBehaviour {

    public PlaceMonster placeMonster;
    public Text sellText;
    public FamilyLevels[] familyLevels;

    private int monsterFamilyIndex;

    // Update is called once per frame
    void Update () {

        monsterFamilyIndex = placeMonster.monsterFamilyIndex;

        sellText.text = "+" + familyLevels[monsterFamilyIndex].monsterTearsRecovery[1];

    }
}
