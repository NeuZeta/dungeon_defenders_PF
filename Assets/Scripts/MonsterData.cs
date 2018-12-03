using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterData : MonoBehaviour {

    public List<MonsterType> types;
    public Vector3 monsterPosition;

    public int monsterIndex;

    [System.Serializable]
    public class MonsterType
    {
        public GameObject monsterType;
    }

    public void CreateFamily (int index, Vector3 pos)
    {
        //Debug.Log(index);
        monsterIndex = index;

        //types[monsterIndex].monsterType.GetComponent<FamilyLevels>().ActivateMonster(pos);

    }

    public int GetMonsterLevel()
    {
        return types[monsterIndex].monsterType.GetComponent<FamilyLevels>().currentLevel;
    }

    public void UpgradeLevel()
    {
        types[monsterIndex].monsterType.GetComponent<FamilyLevels>().SetCorrectMonster();
    }

}
