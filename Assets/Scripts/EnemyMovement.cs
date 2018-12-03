using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    //[HideInInspector]
    public GameObject[] waypoints;

    public float speed = 1f;
    public SpriteRenderer spriteRenderer;

    public int currentWaypoint = 0;
    private bool lookingRight;

    // Use this for initialization
    void Start () {}


    void Update()
    {
        Vector3 startPosition = waypoints[currentWaypoint].transform.position;
        Vector3 endPosition = waypoints[currentWaypoint + 1].transform.position;

        if (startPosition.x < endPosition.x)
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
                currentWaypoint++;
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




}
