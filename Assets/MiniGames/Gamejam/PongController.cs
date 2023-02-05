using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PongController : MonoBehaviour
{
    public int playerScore;
    public int maxScore;
    public TextMeshProUGUI playerScoreText;

    public static PongController Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    private void Start()
    {
        playerScore = 0;
        UpdateScores();
        
    }

    public static void UpdateScores()
    {
        Instance.playerScoreText.text = Instance.playerScore.ToString();
        if (Instance.playerScore >= Instance.maxScore)
            Instance.StartCoroutine(Instance.EndMinigGame());
    }

    IEnumerator EndMinigGame()
    {
        CursorController.Instance.currentMinigame = CursorController.Minigame.MainScene;
        GameState.SetNextAge(Ages.Modern);
        SFXController.Play("success");
        yield return new WaitForSeconds(1f);
        FadeToBlack.FadeOut(1f, null);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        yield break;
    }
}
