using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    public float timeToNextScene;
    public GameObject outtroTitle;
    public GameObject outroSound;

    void Start()
    {
        StartCoroutine(JumpToCredits());
    }

    IEnumerator JumpToCredits()
    {
        yield return new WaitForSeconds(timeToNextScene);
        outtroTitle.SetActive(true);
        outroSound.SetActive(true);
        yield return new WaitForSeconds(3f);
        FadeToBlack.FadeOut(1f, null);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }
}
