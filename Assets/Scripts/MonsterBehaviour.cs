using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour {

    public int damageForce;
    public float range;
    public float attackRate;
    public float actualTimeBetweenAttacks = 0f;
    public GameObject attackShape;

    public List<GameObject> enemiesInRange;

    // Use this for initialization
    void Start () {
		
	}

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
                    enemy.GetComponent<EnemySoul>().TakeDamage(damageForce);
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

            //Debug.Log(collision.GetInstanceID());
            //Attack(collision.gameObject);

            if (!enemiesInRange.Contains(collision.gameObject))
            {
                enemiesInRange.Add(collision.gameObject);
                Debug.Log(enemiesInRange.Count);
            }

            //foreach (GameObject enemy in items)
            //{
            //    Attack(enemy);
            //}
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
