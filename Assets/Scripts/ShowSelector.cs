using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSelector : MonoBehaviour {

    public GameObject monsterSelector;
    public GameObject monster;

    void Start()
    {

    }


    void Update()
    {

    }

    private bool CanPlaceMonster()
    {
        return monster == null;
    }


    private void OnMouseUp()
    {
        if (CanPlaceMonster())
        {
            monsterSelector.transform.position = transform.position;
            monsterSelector.SetActive(true);
        }
    }
}
