using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAttackBehaviour : MonoBehaviour {


    public float speed = 10;
    public Vector3 startPosition;
    public Vector3 targetPosition;
    Vector2 moveDirection;

    public float slowIndex = 1f;
    public float slowTime = 1f;
    public int damageForce;


    Rigidbody2D rb;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDirection = (targetPosition - transform.position + new Vector3 (0,1,0)).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 0.2f);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.GetComponent<EnemySoul>().TakeDamage(damageForce, slowIndex, slowTime);
            Destroy(gameObject);
        }
    }

}
