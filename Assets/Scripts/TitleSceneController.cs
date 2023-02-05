using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{
    public GameObject introScreen;
    public GameObject theGame;
    public GameObject startButton;
    public float introTime;
    
    private void Awake()
    {
        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {
        yield return new WaitForSeconds(introTime);
        introScreen.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        theGame.SetActive(true);
        yield return new WaitForSeconds(1.9f);
        startButton.SetActive(true);
    }
    
    public void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }

    IEnumerator StartGameCoroutine()
    {
        SFXController.Play("comenzar");
        FadeToBlack.FadeOut(1f, null);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
