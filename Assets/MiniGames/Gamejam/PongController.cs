using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PongController : MonoBehaviour
{
    public int playerScore;
    public int gameScore;
    public int maxScore;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI gameScoreText;

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
        gameScore = 0;
        UpdateScores();
        
    }

    public static void UpdateScores()
    {
        Instance.playerScoreText.text = Instance.playerScore.ToString();
        Instance.gameScoreText.text = Instance.gameScore.ToString();
        if (Instance.playerScore >= Instance.maxScore)
            Instance.StartCoroutine(Instance.EndMinigGame());
    }

    IEnumerator EndMinigGame()
    {
        GameState.SetNextAge(Ages.Modern);
        SFXController.Play("success");
        yield return new WaitForSeconds(1f);
        FadeToBlack.FadeOut(1f, null);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        yield break;
    }
}
