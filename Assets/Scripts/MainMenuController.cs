using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

    public Text audioButtonText;
    public AudioSource audioSource;

    public void StartGameButton()
    {
        audioSource.PlayOneShot(AudioManager.Instance.clickButton);
        ScreenFader.instance.LoadLevel("Gameplay");
    }

    public void GoToCredits()
    {
        audioSource.PlayOneShot(AudioManager.Instance.clickButton);
        ScreenFader.instance.LoadLevel("Credits");
    }

}
