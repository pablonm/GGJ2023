using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunpowderWinConditions : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public static GunpowderWinConditions Instance;
    public GunpowderWinCondition[] winConditions;
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
        foreach (GunpowderWinCondition winCondition in Instance.winConditions)
        {
            bool winConditionSatisfied = true;
            foreach (GunpowderWinConditionIngredient conditionPiece in winCondition.conditions)
            {
                winConditionSatisfied = winConditionSatisfied && Instance.checkConditionPiece(conditionPiece);
            }
            hasWon = hasWon || winConditionSatisfied;
        }

        Instance.won = hasWon;

        if (Instance.won)
        {
            Instance.StartCoroutine(Instance.EndMiniGame());
        }
    }

    bool checkConditionPiece(GunpowderWinConditionIngredient conditionPiece)
    {
        bool conditionSatisfied = false;
        Ingredient ingredient = conditionPiece.slot.GetComponentInChildren<Ingredient>();
        switch (ingredient.ingredientName)
        {
            case IngredientNames.carbon : conditionPiece.Ingredientquantity[0] = +1;
                break;
            case IngredientNames.azufre : conditionPiece.Ingredientquantity[1] = +1;
                break;
            case IngredientNames.potasio : conditionPiece.Ingredientquantity[2] = +1;
                break;
        }
        
        conditionSatisfied = conditionPiece.Ingredientquantity[0] >= 1 
                                                && conditionPiece.Ingredientquantity[1] >= 2
                                                && conditionPiece.Ingredientquantity[2] >= 3;

        return conditionSatisfied;
    }

    IEnumerator EndMiniGame()
    {
        GameState.SetNextAge(Ages.Ancient);
        FadeToBlack.FadeOut(1f, null);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        yield break;
    }
}

[System.Serializable]
public class GunpowderWinCondition
{
    public GunpowderWinConditionIngredient[] conditions;
}

[System.Serializable]
public class GunpowderWinConditionIngredient
{
    public IngredientSlot slot;
    public IngredientNames ingredientName;
    public int[] Ingredientquantity = { 0, 0, 0 };
}
