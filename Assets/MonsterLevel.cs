using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLevel : MonoBehaviour {

    public List<Level> levels;
    public int currentLevel;
    private Vector3 monsterPosition;

    [System.Serializable]
    public class Level
    {
        public float cost;
        public GameObject visualization;
    }

    private void OnEnable()
    {
        currentLevel = 0;
    }

    public void ActivateMonster(Vector3 pos)
    {
        monsterPosition = pos;
        Instantiate(levels[currentLevel].visualization, monsterPosition, Quaternion.identity);  
        levels[currentLevel].visualization.SetActive(true);
    }

    public void UpgradeMonster()
    {
        Debug.Log("Upgrade Monster");
        levels[currentLevel].visualization.SetActive(false);

        if (currentLevel < levels.Count)
        {
            currentLevel++;
        }
        levels[currentLevel].visualization.SetActive(true);
        Instantiate(levels[currentLevel].visualization, monsterPosition, Quaternion.identity);
    }

}
