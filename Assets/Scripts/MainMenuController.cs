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
        audioSource.PlayOneShot(GameManager.Instance.clickButton);
        //SceneManager.LoadScene("Gameplay");
        ScreenFader.instance.LoadLevel("Gameplay");
    }

    public void MusicOnOffButton()
    {
        audioSource.PlayOneShot(GameManager.Instance.clickButton);
        
        if (GameManager.Instance.audioSource.mute)
        {
            audioButtonText.text = "MUSIC OFF";
            GameManager.Instance.audioSource.mute = false;
        }
        else
        {
            audioButtonText.text = "MUSIC ON";
            GameManager.Instance.audioSource.mute = true;
        }
    }
}
