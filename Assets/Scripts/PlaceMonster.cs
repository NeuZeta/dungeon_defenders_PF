using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlaceMonster : MonoBehaviour {

    
    public GameObject[] monsterSelector;
    public SpriteRenderer monsterToUpgrade;
    public Sprite[] monsters;
    public GameObject[] monsterData;

    [HideInInspector]
    public Transform loseta;

    public int monsterFamilyIndex;

    private Vector3 newMonsterPosition;
    private string[] menu00Buttons = new string[] { "Horns", "Snake" };

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider)
            {

                if (hit.transform.tag == "MonsterSpot")
                {
                    newMonsterPosition = hit.transform.position;
                    loseta = hit.transform;

                    if (loseta.transform.GetComponent<SpotStatus>().CanPlaceMonster())
                    {
                        monsterSelector[0].transform.position = newMonsterPosition;

                        for (int i = 0; i < monsterSelector.Length; i++)
                        {
                            if (i == 0)
                            {
                                monsterSelector[i].SetActive(true);
                            }
                            else
                            {
                                monsterSelector[i].SetActive(false);
                            }
                        }
                    }
                    else
                    {
                        int activeMonsterType = loseta.transform.GetComponent<SpotStatus>().monster.GetComponent<FamilyLevels>().familyIndex;
                        int currentMonsterLevel = loseta.transform.GetComponent<SpotStatus>().monster.GetComponent<FamilyLevels>().currentLevel;

                        //Debug.Log("active Monster Type = " + activeMonsterType);
                        //Debug.Log("Current Monster Level = " + currentMonsterLevel);

                        if (currentMonsterLevel == 0)
                        {
                            monsterSelector[currentMonsterLevel + 1].transform.position = newMonsterPosition;
                            monsterSelector[currentMonsterLevel + 1].SetActive(true);
                            monsterToUpgrade.sprite = monsters[activeMonsterType];
                        }
                        else if (currentMonsterLevel == 1)
                        {
                            monsterSelector[currentMonsterLevel + 1].transform.position = newMonsterPosition;
                            monsterSelector[currentMonsterLevel + 1].SetActive(true);
                            monsterToUpgrade.enabled = false;
                        }




                    }
                }
                else if (hit.transform.tag == "Menu00")
                {
                    if (hit.transform.name == "Horns")
                    {
                        monsterFamilyIndex = 0;
                        int monsterPrice = monsterData[monsterFamilyIndex].GetComponent<FamilyLevels>().monsterPrice[0];
                        if (GameManager.instance.soulTears >= monsterPrice)
                        {
                            GameManager.instance.soulTears -= monsterPrice;
                            GameManager.instance.UpdateTearsState();

                            
                            loseta.transform.GetComponent<SpotStatus>().monster = Instantiate(monsterData[monsterFamilyIndex], newMonsterPosition, Quaternion.identity);
                            loseta.transform.GetComponent<SpotStatus>().monster.GetComponent<FamilyLevels>().SetCorrectMonster();
                            
                        }
                    }
                    else if (hit.transform.name == "Snake")
                    {
                        monsterFamilyIndex = 1;
                        int monsterPrice = monsterData[monsterFamilyIndex].GetComponent<FamilyLevels>().monsterPrice[0];
                        if (GameManager.instance.soulTears >= monsterPrice)
                        {
                            GameManager.instance.soulTears -= monsterPrice;
                            GameManager.instance.UpdateTearsState();

                            
                            loseta.transform.GetComponent<SpotStatus>().monster = Instantiate(monsterData[monsterFamilyIndex], newMonsterPosition, Quaternion.identity);
                            loseta.transform.GetComponent<SpotStatus>().monster.GetComponent<FamilyLevels>().SetCorrectMonster();
                        }
                    }
                    else if (hit.transform.name == "Star")
                    {
                        monsterFamilyIndex = 2;
                        int monsterPrice = monsterData[monsterFamilyIndex].GetComponent<FamilyLevels>().monsterPrice[0];
                        if (GameManager.instance.soulTears >= monsterPrice)
                        {
                            GameManager.instance.soulTears -= monsterPrice;
                            GameManager.instance.UpdateTearsState();

                            
                            loseta.transform.GetComponent<SpotStatus>().monster = Instantiate(monsterData[monsterFamilyIndex], newMonsterPosition, Quaternion.identity);
                            loseta.transform.GetComponent<SpotStatus>().monster.GetComponent<FamilyLevels>().SetCorrectMonster();
                        }
                    }
                    else if (hit.transform.name == "Mass")
                    {
                        monsterFamilyIndex = 3;
                        int monsterPrice = monsterData[monsterFamilyIndex].GetComponent<FamilyLevels>().monsterPrice[0];
                        if (GameManager.instance.soulTears >= monsterPrice)
                        {
                            GameManager.instance.soulTears -= monsterPrice;
                            GameManager.instance.UpdateTearsState();

                            
                            loseta.transform.GetComponent<SpotStatus>().monster = Instantiate(monsterData[monsterFamilyIndex], newMonsterPosition, Quaternion.identity);
                            loseta.transform.GetComponent<SpotStatus>().monster.GetComponent<FamilyLevels>().SetCorrectMonster();
                        }
                    }

                    foreach (GameObject menu in monsterSelector)
                    {
                        menu.SetActive(false);
                    }
                    loseta = null;
                }
                else if (hit.transform.tag == "Menu01")
                {
                    if (hit.transform.name == "Upgrade")
                    {
                        int monsterPrice = monsterData[monsterFamilyIndex].GetComponent<FamilyLevels>().monsterPrice[1];
                        if (GameManager.instance.soulTears >= monsterPrice)
                        {
                            GameManager.instance.soulTears -= monsterPrice;
                            GameManager.instance.UpdateTearsState();
                            loseta.transform.GetComponent<SpotStatus>().monster.GetComponent<FamilyLevels>().UpgradeLevel();
                        }
                           
                    }

                    foreach (GameObject menu in monsterSelector)
                    {
                        menu.SetActive(false);
                    }
                    loseta = null;

                }
                else if (hit.transform.tag == "Menu02") { }
            }
            else
            {
                foreach (GameObject menu in monsterSelector)
                {
                    menu.SetActive(false);
                }

            }
        }
    }
}//PlaceMonsters





