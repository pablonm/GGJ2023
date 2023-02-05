using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RomanPipesWinConditions : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public static RomanPipesWinConditions Instance;
    public RomanPipesWinCondition[] winConditions;
    public bool won = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    public static void CheckWinConditions()
    {
        if (Instance.won) return;
        bool hasWon = false;
        foreach (RomanPipesWinCondition winCondition in Instance.winConditions)
        {
            bool winConditionSatisfied = true;
            foreach (RomanPipesWinConditionPiece conditionPiece in winCondition.conditions)
            {
                winConditionSatisfied = winConditionSatisfied && Instance.checkConditionPiece(conditionPiece);
            }
            hasWon = hasWon || winConditionSatisfied;
        }

        Instance.won = hasWon;

        if (Instance.won)
        {
            Instance.StartCoroutine(Instance.EndMinigGame());
        }
    }

    bool checkConditionPiece(RomanPipesWinConditionPiece conditionPiece)
    {
        bool conditionSatisfied = true;
        AqueductPiece pipe = conditionPiece.slot.gameObject.GetComponentInChildren<AqueductPiece>();
        conditionSatisfied = conditionSatisfied && pipe != null;
        if (pipe != null) {
            conditionSatisfied = conditionSatisfied && conditionPiece.pipeType == pipe.pipeType;
            conditionSatisfied = conditionSatisfied && Array.IndexOf(conditionPiece.possibleOrientations, pipe.currentOrientation) > -1;
        }

        return conditionSatisfied;
    }

    IEnumerator EndMinigGame()
    {
        CursorController.Instance.currentMinigame = CursorController.Minigame.MainScene;
        GameState.SetNextAge(Ages.Prehistory);
        SFXController.Play("success");
        FadeToBlack.FadeOut(1f, null);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        yield break;
    }
}

[System.Serializable]
public class RomanPipesWinCondition
{
    public RomanPipesWinConditionPiece[] conditions;
}

[System.Serializable]
public class RomanPipesWinConditionPiece
{
    public AqueductSlot slot;
    public PipeTypes pipeType;
    public PipeOrientations[] possibleOrientations;
}
