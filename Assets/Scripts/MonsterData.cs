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
        monsterIndex = index;

        types[monsterIndex].monsterType.GetComponent<MonsterLevel>().ActivateMonster(pos);

        Debug.Log("He creado un monstruo de nivel " + monsterIndex);
    }


}
