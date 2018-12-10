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
    public GameObject stunnedStars;
    public GameObject runAwayShadow;
    public ParticleSystem deathExplosion;
    public int enemyLevel;
    public int[] rewardForKill; 


    private bool scared = false;
    private bool stunned = false;
    [HideInInspector]
    public bool runAway = false;
    private int runAwayIndex;
    

	// Use this for initialization
	void Start () {
        actualSoul = totalSoul;
        healthBar.maxValue = totalSoul;
        stunnedStars.SetActive(false);
        runAwayShadow.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(actualSoul);
        if (actualSoul == 0)
        {
            GameplayManager.Instance.soulTears += rewardForKill[enemyLevel];
            GameplayManager.Instance.UpdateTearsState();

            Destroy(gameObject);
            Explode(transform.position);
        }

        AnimationControl();
        if (runAway == false)
        {
            runAwayShadow.SetActive(false);
        }
        else
        {
            runAwayShadow.SetActive(true);
        }
    }

    public void Explode(Vector3 position)
    {
        Instantiate(deathExplosion, position, Quaternion.identity);
    }

    public void TakeDamage(int damageForce, float slowIndex, float slowTime, int runAwaySuccess)
    {
        actualSoul -= damageForce;

        scared = true;
        Invoke("StopBeingScared", 0.5f);

        runAwayIndex = Random.Range(0,10);

        if (runAwayIndex > runAwaySuccess)
        {
            runAway = true;
            //Invoke("StopRunAway", 2f);
        }

        if (slowIndex > 1)
        {
            if (!stunned)
            {
                stunned = true;
                enemyMovement.speed /= slowIndex;
                StartCoroutine(RestoreEnemySpeed(slowTime, slowIndex));
            }
            
        }

        if (!scared)
        {
            scared = true;
            Invoke("StopBeingScared", 0.5f);
        }

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
        yield return new WaitForSeconds(Random.Range(0,slowTime));
        enemyMovement.speed *= slowIndex;
        stunnedStars.SetActive(false);
        stunned = false;
    }

    void StopBeingScared()
    {
        scared = false;
    }

    void StopRunAway()
    {
        runAway = false;
    }
    

    void AnimationControl()
    {
        if (scared == true)
        {
            anim.SetLayerWeight(anim.GetLayerIndex("Scared"), 1);
        }
        else
        {
            anim.SetLayerWeight(anim.GetLayerIndex("Scared"), 0);
        }

        if (stunned == true)
        {
            stunnedStars.SetActive(true);
            anim.SetLayerWeight(anim.GetLayerIndex("Stunned"), 1);
        } else
        {
            anim.SetLayerWeight(anim.GetLayerIndex("Stunned"), 0);
        }

    }


}//EnemySoul

