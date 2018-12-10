using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour {

    public AudioSource audioSource;

    public void GoToMainMenu()
    {
        audioSource.PlayOneShot(AudioManager.Instance.clickButton);
        ScreenFader.instance.LoadLevel("MainMenu");
    }

}
