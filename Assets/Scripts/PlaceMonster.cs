using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMonster : MonoBehaviour {

    
    public GameObject monsterSelector;
    //private GameObject monster;
    [HideInInspector]
    public Transform loseta;
    public GameObject Snake, Horns;

    private Vector3 newMonsterPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider)
            {
                if (!monsterSelector.activeInHierarchy)
                {
                    if (hit.transform.tag == "MonsterSpot")
                    {
                        newMonsterPosition = hit.transform.position;
                        loseta = hit.transform;

                        if (loseta.transform.GetComponent<SpotStatus>().CanPlaceMonster())
                        {
                            monsterSelector.transform.position = newMonsterPosition;
                            monsterSelector.SetActive(true);
                        }
                    }
                }
                else
                {
                    if (hit.transform.tag == "MonsterSpot")
                    {
                        newMonsterPosition = hit.transform.position;
                        loseta = hit.transform;

                        if (loseta.transform.GetComponent<SpotStatus>().CanPlaceMonster())
                        {
                            monsterSelector.transform.position = newMonsterPosition;
                            monsterSelector.SetActive(true);
                        }
                    }
                    else if (hit.transform.tag == "Snake")
                    {
                        if (GameManager.instance.soulTears >= 200)
                        {
                            GameManager.instance.soulTears -= 200;
                            GameManager.instance.UpdateTearsState();

                            loseta.transform.GetComponent<SpotStatus>().monster = Instantiate(Snake, newMonsterPosition, Quaternion.identity);
                            monsterSelector.SetActive(false);
                            loseta = null;
                        }
                        
                    }
                    else if (hit.transform.tag == "Horns")
                    {
                        if (GameManager.instance.soulTears >= 250)
                        {
                            GameManager.instance.soulTears -= 250;
                            GameManager.instance.UpdateTearsState();

                            loseta.transform.GetComponent<SpotStatus>().monster = Instantiate(Horns, newMonsterPosition, Quaternion.identity);
                            monsterSelector.SetActive(false);
                            loseta = null;
                        }
                        
                    }

                }
  
            }
            else
            {
                if (monsterSelector.activeInHierarchy)
                {
                    monsterSelector.SetActive(false);
                }
            }
        }
    }




}
