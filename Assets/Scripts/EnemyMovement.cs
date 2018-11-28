using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public GameObject[] waypoints;
    public float speed = 10f;

    private int currentWaypoint = 0;
    private float lastWaypointResetTime;
    private bool lookingRight;

    // Use this for initialization
    void Start () {
        lastWaypointResetTime = Time.time;
    }
	

	void Update () {

        Vector3 startPosition = waypoints[currentWaypoint].transform.position;
        Vector3 endPosition = waypoints[currentWaypoint+1].transform.position;

        if(startPosition.x < endPosition.x)
        {
            if (!lookingRight)
            {
                Vector3 temp = transform.localScale;
                temp.x *= -1;
                transform.localScale = temp;

                lookingRight = true;
            }

            //Debug.Log("Mirando a la derecha");
        }
        else
        {
            if (lookingRight)
            {
                Vector3 temp = transform.localScale;
                temp.x *= -1;
                transform.localScale = temp;

                lookingRight = false;
            }
            //Debug.Log("Mirando a la izquierda");
        }

        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - lastWaypointResetTime;

        gameObject.transform.position = Vector2.Lerp(startPosition, endPosition, currentTimeOnPath/totalTimeForPath);

        if (gameObject.transform.position.Equals(endPosition))
        {
            if (currentWaypoint < waypoints.Length - 2)
            {
                currentWaypoint++;
                lastWaypointResetTime = Time.time;
            }
            else
            {

            }
        }

    }
}
