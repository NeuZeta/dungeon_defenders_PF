using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornsMonsterData : MonoBehaviour {

    [System.Serializable]
    public class HornsMonsterLevel
    {
        public int cost;
        public GameObject visualization;
    }

    public List<HornsMonsterLevel> levels;

    private HornsMonsterLevel currentLevel;
    public HornsMonsterLevel CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
            int currentLevelIndex = levels.IndexOf(currentLevel);

            GameObject levelVisualization = levels[currentLevelIndex].visualization;
            for (int i = 0; i < levels.Count; i++)
            {
                if (levelVisualization != null)
                {
                    if (i == currentLevelIndex)
                    {
                        levels[i].visualization.SetActive(true);
                    }
                    else
                    {
                        levels[i].visualization.SetActive(false);
                    }
                }
            }
        }
    }


    private void OnEnable()
    {
        CurrentLevel = levels[0];
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
