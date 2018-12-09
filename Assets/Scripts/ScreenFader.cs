using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScreenFader : MonoBehaviour {

    public static ScreenFader instance;

    [SerializeField]
    private GameObject fadePanel;
    [SerializeField]
    private Animator anim;


	void Awake ()
    {
        MakeSingleton();

    }

    private void MakeSingleton()
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

    public void LoadLevel(string level)
    {
        StartCoroutine(FadeInOut(level));
    }

    IEnumerator FadeInOut(string level)
    {
        fadePanel.SetActive(true);
        anim.Play("FadeIn");

        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(0.7f));

        SceneManager.LoadScene(level);
        anim.Play("FadeOut");

        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(0.7f));

        fadePanel.SetActive(false);
    }





}//ScreenFader
