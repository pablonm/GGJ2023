using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunPowderWinCondition : MonoBehaviour
{
    public static GunPowderWinCondition Instance;
    public GunPowderWinCondition[] winCondition;
    public bool won = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    IEnumerator EndMinigGame()
    {
        GameState.SetNextAge(Ages.Prehistory);
        FadeToBlack.FadeOut(1f, null);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        yield break;
    }

}