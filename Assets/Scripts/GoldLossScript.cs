using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldLossScript : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip[] goldLossSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            audioSource.PlayOneShot(goldLossSound[Random.Range(0, goldLossSound.Length)]);
        }
    }

}
