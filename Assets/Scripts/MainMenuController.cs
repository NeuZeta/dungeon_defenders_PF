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
        //SceneManager.LoadScene("Gameplay");
        ScreenFader.instance.LoadLevel("Gameplay");
    }

    public void MusicOnOffButton()
    {
        audioSource.PlayOneShot(AudioManager.Instance.clickButton);
        
        if (AudioManager.Instance.audioSource.mute)
        {
            audioButtonText.text = "MUSIC OFF";
            AudioManager.Instance.audioSource.mute = false;
        }
        else
        {
            audioButtonText.text = "MUSIC ON";
            AudioManager.Instance.audioSource.mute = true;
        }
    }
}
