using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMonsterBehaviour : MonoBehaviour {

    public int damageForce;
    public float range;
    public float attackRate;
    public float slowIndex = 1f;
    public float slowTime = 1f;
    public float actualTimeBetweenAttacks = 0f;

    public GameObject attackShape;

    public List<GameObject> enemiesInRange;

    public int myMonsterFamily;

    // Use this for initialization
    void Start () {}

    // Update is called once per frame
    void Update()
    {
        actualTimeBetweenAttacks += Time.deltaTime;

        if (actualTimeBetweenAttacks > attackRate)
        {
            actualTimeBetweenAttacks = 0f;
           
            if (enemiesInRange.Count > 0)
            {
                attackShape.SetActive(true);
                Invoke("HideAttackShape", 0.7f);

                foreach (GameObject enemy in enemiesInRange)
                {
                    enemy.GetComponent<EnemySoul>().TakeDamage(damageForce, slowIndex, slowTime);
                }

            }

        }

    }

    void HideAttackShape()
    {
        attackShape.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (!enemiesInRange.Contains(collision.gameObject))
            {
                enemiesInRange.Add(collision.gameObject);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (enemiesInRange.Contains(collision.gameObject))
            {
                enemiesInRange.Remove(collision.gameObject);
            }
        }
    }




}//MonsterBehaviour
