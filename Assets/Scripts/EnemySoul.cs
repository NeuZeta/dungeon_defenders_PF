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
    public EnemyMovement enemyMovement;

    private bool scared = false;
    

	// Use this for initialization
	void Start () {
        actualSoul = totalSoul;
        healthBar.maxValue = totalSoul;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(actualSoul);
        if (actualSoul == 0) Destroy(gameObject);
        AnimationControl();


    }

    public void TakeDamage(int damageForce, float slowIndex, float slowTime)
    {
        actualSoul -= damageForce;
  
        if (!scared)
        {
            scared = true;
            enemyMovement.speed /= slowIndex;
            StartCoroutine(RestoreEnemySpeed(slowTime, slowIndex));
        }

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

    IEnumerator RestoreEnemySpeed (float slowTime, float slowIndex)
    {
        yield return new WaitForSeconds(slowTime);
        enemyMovement.speed *= slowIndex;
        scared = false;
    }

    void AnimationControl()
    {
        if (scared == true)
        {
            anim.SetLayerWeight(1, 0);
        }
        else
        {
            anim.SetLayerWeight(1, 1);
        }
    }


}//EnemySoul

