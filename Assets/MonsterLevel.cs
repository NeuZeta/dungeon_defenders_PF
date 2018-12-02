using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLevel : MonoBehaviour {

    public List<Level> levels;
    public int monsterLevel;


    [System.Serializable]
    public class Level
    {
        public float cost;
        public GameObject visualization;
    }

    private void OnEnable()
    {
        monsterLevel = 0;   
    }

    public void ActivateMonster(Vector3 pos)
    {
        Debug.Log("Activamos monstruo");
        Instantiate(levels[monsterLevel].visualization, pos, Quaternion.identity);
        
    }

}
