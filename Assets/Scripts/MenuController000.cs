using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController000 : MonoBehaviour {

    public SpriteRenderer[] monsterFamilyButton;
    public FamilyLevels[] familyLevels;
    public Text[] familyText;

    private void OnEnable()
    {
        for (int i = 0; i < familyText.Length; i++)
        {
            int price = familyLevels[i].monsterPrice[0];
            familyText[i].text = price.ToString();
        }
    }


    void Update () {

        for (int i = 0; i < monsterFamilyButton.Length; i++ )
        {
            int price = familyLevels[i].monsterPrice[0];

            if (GameplayManager.Instance.soulTears < price)
            {
                Color temp = monsterFamilyButton[i].color;
                temp.a = 0.3f;
                monsterFamilyButton[i].color = temp;
            }
            else
            {
                Color temp = monsterFamilyButton[i].color;
                temp.a = 1;
                monsterFamilyButton[i].color = temp;
            }
    
        }


	}



}
