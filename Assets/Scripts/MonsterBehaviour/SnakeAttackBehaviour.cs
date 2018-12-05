using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAttackBehaviour : MonoBehaviour {


    public float speed = 10;
    public Vector3 startPosition;
    public Transform target;
    Vector2 moveDirection;

    public int runAwaySuccess = 10;
    public float slowIndex = 1f;
    public float slowTime = 1f;
    public int damageForce;


    Rigidbody2D rb;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDirection = (target.position - transform.position + new Vector3 (0,1,0)).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 0.5f);
    }


    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.GetComponent<EnemySoul>().TakeDamage(damageForce, slowIndex, slowTime, runAwaySuccess);
            Destroy(gameObject);
        }
    }

}
