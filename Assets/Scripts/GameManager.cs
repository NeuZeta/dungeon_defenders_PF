using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public Text tearsText, goldText;

    [HideInInspector]
    public int soulTears = 500;
    [HideInInspector]
    public int gold = 1000;



    // Use this for initialization
    void Awake () {
        MakeSingleton();
        UpdateTearsState();
        UpdateGoldState();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void UpdateTearsState()
    {
        tearsText.text = soulTears.ToString();
    }

    public void UpdateGoldState()
    {
        goldText.text = gold.ToString();
    }

}//GameManager
