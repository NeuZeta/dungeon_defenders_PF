using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private static AudioManager instance;
    public static AudioManager Instance
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
    public AudioSource audioSource;
    public AudioClip clickButton;

    void Awake () {
        MakeSingleton();
    }

    void MakeSingleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
