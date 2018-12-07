using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    //[HideInInspector]
    public GameObject[] waypoints;

    public float speed = 1f;
    public SpriteRenderer spriteRenderer;
    public EnemySoul enemySoul;
    public GameObject coin;

    public int currentWaypoint = 0;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool lookingRight;

    // Use this for initialization
    void Start ()
    {
        coin.SetActive(false);
        transform.position = waypoints[currentWaypoint].transform.position;
    }


    void Update()
    {
        if (!enemySoul.runAway)
        {
            startPosition = waypoints[currentWaypoint].transform.position;
            endPosition = waypoints[currentWaypoint + 1].transform.position;
        }
        else
        {
            endPosition = waypoints[currentWaypoint].transform.position;
        }

        if (startPosition.x <= endPosition.x)
        {
            if (!lookingRight)
            {
                spriteRenderer.flipX = true;

                lookingRight = true;
            }

            //Debug.Log("Mirando a la derecha");
        }
        else
        {
            if (lookingRight)
            {
                spriteRenderer.flipX = false;

                lookingRight = false;
            }
            //Debug.Log("Mirando a la izquierda");
        }

        if (gameObject.transform.position.Equals(endPosition))
        {
            if (currentWaypoint < waypoints.Length - 2)
            {
                if (enemySoul.runAway)
                {
                    enemySoul.runAway = false;
                    endPosition = waypoints[currentWaypoint + 1].transform.position;
                }
                else
                {
                    currentWaypoint++;
                }
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, endPosition, Time.deltaTime * speed);

    }


    public float DistanceToTreasure()
    {
        float distance = 0;

        distance += Vector2.Distance(gameObject.transform.position, waypoints[currentWaypoint + 1].transform.position);
        for (int i = currentWaypoint+1; i < waypoints.Length; i++)
        {
            Vector3 startPosition = waypoints[i].transform.position;
            Vector3 endPosition = waypoints[i + 1].transform.position;
            distance += Vector2.Distance(startPosition, endPosition); 
        }

        return distance;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Treasure")
        {
            coin.SetActive(true);
            GameManager.instance.gold -= 100;
            GameManager.instance.UpdateGoldState();
        }
    }


}
