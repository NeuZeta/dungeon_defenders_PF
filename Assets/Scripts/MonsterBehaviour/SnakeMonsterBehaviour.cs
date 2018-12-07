using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMonsterBehaviour : MonoBehaviour {

    public float attackRate;
    public float actualTimeBetweenAttacks = 0f;
    public GameObject[] attackShape;
    public AudioSource audioSource;
    public AudioClip snakeAttack;

    [SerializeField]
    GameObject SnakeBullet;
    public float bulletSpeed = 10;

    public List<GameObject> enemiesInRange;

    public int myMonsterFamily;

    private void Start(){}

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
                
                Shoot(enemiesInRange[0].transform);
                audioSource.PlayOneShot(snakeAttack);

                Invoke("HideAttackShape", 0.4f);
            } 
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

    void Shoot(Transform target)
    {
        GameObject myBullet = Instantiate(SnakeBullet, this.transform.position + new Vector3(0,1,0), Quaternion.identity);

        SnakeAttackBehaviour bullet = myBullet.GetComponent<SnakeAttackBehaviour>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }

    }

    void HideAttackShape()
    {
        foreach (GameObject shape in attackShape)
        {
            shape.SetActive(false);
        }
        
    }




}//MonsterBehaviour
