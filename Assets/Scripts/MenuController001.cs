using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuController001 : MonoBehaviour
{

    public SpriteRenderer monsterToUpgrade;
    public Sprite[] monster;
    
    private int monsterFamilyIndex;
    public FamilyLevels[] familyLevels;
    public Text buyText;
    public Text sellText;

    void Update()
    {

        for (int i = 0; i < monster.Length; i++)
        {
            if (monsterToUpgrade.sprite == monster[i])
            {
                monsterFamilyIndex = i;
            }
        }

        int price = familyLevels[monsterFamilyIndex].monsterPrice[1];
        buyText.text = price.ToString();

        sellText.text = "+" + familyLevels[monsterFamilyIndex].monsterTearsRecovery[0];

        if (GameplayManager.Instance.soulTears < price)
        {
            Color temp = monsterToUpgrade.color;
            temp.a = 0.3f;
            monsterToUpgrade.color = temp;
        }
        else
        {
            Color temp = monsterToUpgrade.color;
            temp.a = 1;
            monsterToUpgrade.color = temp;
        }

    }




}//MenuController001
