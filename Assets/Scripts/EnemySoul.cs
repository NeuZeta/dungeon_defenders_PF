using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySoul : MonoBehaviour {

    public int totalSoul;
    [HideInInspector]
    public int actualSoul;
    public Animator anim;
    public Slider healthBar;

	// Use this for initialization
	void Start () {
        actualSoul = totalSoul;
        healthBar.maxValue = totalSoul;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(actualSoul);
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

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBar.value = actualSoul;
    }

    

}//EnemySoul

