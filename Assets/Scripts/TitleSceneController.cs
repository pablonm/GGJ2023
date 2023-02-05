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
        Destroy(introScreen);
        yield return new WaitForSeconds(2f);
        theGame.SetActive(true);
        yield return new WaitForSeconds(2f);
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
