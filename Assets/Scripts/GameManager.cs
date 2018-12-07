using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
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
    public GameObject pauseMenu;
    public AudioSource audioSource;
    public Text audioButtonText;

    // Use this for initialization
    void Awake () {
        //MakeSingleton();
        UpdateTearsState();
        UpdateGoldState();
        instance = this;
    }

    private void Start()
    {
        Wave = 0;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
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
            gameOver = true;
        }
    }

    public void PauseButton()
    {
        Time.timeScale=0f;
        pauseMenu.SetActive(true);

    }

    public void RestartGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void BackToMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("");
    }

    public void MusicOnOffButton()
    {
        if (audioSource.mute)
        {
            audioButtonText.text = "MUSIC OFF";
            audioSource.mute = false;
        }
        else
        {
            audioButtonText.text = "MUSIC ON";
            audioSource.mute = true;
        }
    }

    public void ResumeGameButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale=1f;
    }

    





}//GameManager
