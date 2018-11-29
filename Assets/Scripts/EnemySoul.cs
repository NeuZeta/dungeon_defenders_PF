using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoul : MonoBehaviour {

    public int totalSoul;
    public int actualSoul;
    public Animator anim;

	// Use this for initialization
	void Start () {
        actualSoul = totalSoul;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(actualSoul);
        if (actualSoul == 0) Destroy(gameObject);
	}

    public void TakeDamage(int damageForce)
    {
        anim.SetTrigger("Scared");
        actualSoul -= damageForce;
        GameManager.instance.soulTears += damageForce;
        GameManager.instance.UpdateTearsState();
        if (actualSoul < 0)
        {
            actualSoul = 0;
        }
    }

}
