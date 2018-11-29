using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour {

    public int damageForce;
    public float range;
    public float attackRate;
    public float actualTimeBetweenAttacks = 0f;
    public GameObject attackShape;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        actualTimeBetweenAttacks += Time.deltaTime;
        //Attack();
	}

    public void Attack(Collider2D enemy)
    {
        if (actualTimeBetweenAttacks > attackRate)
        {
            actualTimeBetweenAttacks = 0f;
            attackShape.SetActive(true);
            Invoke("HideAttackShape", 0.7f);

            Debug.Log("Attack! Dealing " + damageForce.ToString() + " damage");

            enemy.GetComponent<EnemySoul>().TakeDamage(damageForce);
            

        }
    }

    void HideAttackShape()
    {
        attackShape.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Attack(collision);
        }
    }

}//MonsterBehaviour
