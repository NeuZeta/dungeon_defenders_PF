﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornsMonsterBehaviour : MonoBehaviour {

    public int damageForce;
    public int runAwaySuccess = 0;
    public float attackRate;
    public float slowIndex = 1f;
    public float slowTime = 1f;
    public float actualTimeBetweenAttacks = 0f;
    public ParticleSystem hornsExplosion;
    public AudioSource audioSource;
    public AudioClip hornsAttack;

    public GameObject[] attackShape;

    public List<GameObject> enemiesInRange;

    public int myMonsterFamily;

    void Awake()
    {
        foreach (GameObject shape in attackShape)
        {
            shape.SetActive(false);
        }
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
                foreach (GameObject shape in attackShape)
                {
                    shape.SetActive(true);
                }
                Invoke("HideAttackShape", 0.7f);
                audioSource.PlayOneShot(hornsAttack);
                foreach (GameObject enemy in enemiesInRange)
                {
                    enemy.GetComponent<EnemySoul>().TakeDamage(damageForce, slowIndex, slowTime, runAwaySuccess);
                    
                    Instantiate(hornsExplosion, enemy.transform.position, Quaternion.identity);
                }
            }
        }
    }

    void HideAttackShape()
    {
        foreach (GameObject shape in attackShape)
        {
            shape.SetActive(false);
        }
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
