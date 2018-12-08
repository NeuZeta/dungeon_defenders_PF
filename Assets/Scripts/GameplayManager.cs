using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour {

    private static GameplayManager instance;
    public Text tearsText, goldText;

    [HideInInspector]
    public int soulTears = 500;
    [HideInInspector]
    public int gold = 1000;
    public Slider goldBar;
    public Text waveNumber;
    public bool gameOver = false;
    private int wave;
    public int Wave
    {
        get
        {
            return wave;
        }
        set
        {
            wave = value;
            waveNumber.text = "WAVE " + (wave + 1);
        }
    }

    public static GameplayManager Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }
    public GameObject pauseMenu;
    public Text audioButtonText;
    public AudioSource audioSource;
    public GameObject gameOverPanel, gameOverText, winText;


    // Use this for initialization
    void Awake () {
        gameOverPanel.SetActive(false);
        UpdateTearsState();
        UpdateGoldState();
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        Wave = 0;
    }


    public void UpdateTearsState()
    {
        tearsText.text = soulTears.ToString();
    }

    public void UpdateGoldState()
    {
        goldText.text = gold.ToString();
        goldBar.value = gold;
        if (gold <= 0)
        {
            gold = 0;
            Invoke("GameOver", 1f);
        }
    }

    void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        if (gold > 0)
        {
            gameOverText.SetActive(false);
            winText.SetActive(true);
            audioSource.PlayOneShot(GameManager.Instance.winGame);
        }
        else
        {
            gameOverText.SetActive(true);
            winText.SetActive(false);
            audioSource.PlayOneShot(GameManager.Instance.loseGame);
        }

    }


    public void PauseButton()
    {
        audioSource.PlayOneShot(GameManager.Instance.clickButton);
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        IsMusicOn();
    }

    public void RestartGameButton()
    {
        audioSource.PlayOneShot(GameManager.Instance.clickButton);
        ScreenFader.instance.LoadLevel(SceneManager.GetActiveScene().name);
    }

    public void BackToMenuButton()
    {
        audioSource.PlayOneShot(GameManager.Instance.clickButton);
        Time.timeScale = 1f;
        ScreenFader.instance.LoadLevel("MainMenu");
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

    void IsMusicOn()
    {
        if (audioSource.mute)
        {
            audioButtonText.text = "MUSIC OFF";
            
        }
        else
        {
            audioButtonText.text = "MUSIC ON";
        }
    }

    public void ResumeGameButton()
    {
        audioSource.PlayOneShot(GameManager.Instance.clickButton);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }


}//GameManager
