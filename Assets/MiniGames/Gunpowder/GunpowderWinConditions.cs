using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunpowderWinConditions : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public static GunpowderWinConditions Instance;
    public bool won = false;
    public int carbonAmount;
    public int azufreAmount;
    public int potasioAmount;
    public int charcoalCurrentAmount;
    public int azufreCurrentAmount;
    public int potasiumCurrentAmount;
    public GameObject[] mezclas;
    private int currentMezcla = 0;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    public static void AddIngredient(IngredientNames name)
    {
        switch (name)
        {
            case IngredientNames.carbon:
                if (Instance.charcoalCurrentAmount < Instance.carbonAmount)
                {
                    Instance.charcoalCurrentAmount++;
                    SFXController.Play("ok");
                    if (Instance.charcoalCurrentAmount == Instance.carbonAmount)
                    {
                        Instance.mezclas[Instance.currentMezcla].SetActive(true);
                        Instance.currentMezcla++;
                    }
                }
                else
                {
                    Debug.Log("here");
                    SFXController.Play("wrong");
                }
                break;
            case IngredientNames.azufre:
                if (Instance.azufreCurrentAmount < Instance.azufreAmount)
                {
                    Instance.azufreCurrentAmount++;
                    SFXController.Play("ok");
                    if (Instance.azufreCurrentAmount == Instance.azufreAmount)
                    {
                        Instance.mezclas[Instance.currentMezcla].SetActive(true);
                        Instance.currentMezcla++;
                    }
                } else
                {
                    SFXController.Play("wrong");
                }
                break;
            case IngredientNames.potasio:
                if (Instance.potasiumCurrentAmount < Instance.potasioAmount)
                {
                    Instance.potasiumCurrentAmount++;
                    SFXController.Play("ok");
                    if (Instance.potasiumCurrentAmount == Instance.potasioAmount)
                    {
                        Instance.mezclas[Instance.currentMezcla].SetActive(true);
                        Instance.currentMezcla++;
                    }
                } else
                {
                    SFXController.Play("wrong");
                }
                break;
        }

        if (Instance.charcoalCurrentAmount == Instance.carbonAmount 
            && Instance.potasiumCurrentAmount == Instance.potasioAmount 
            && Instance.azufreCurrentAmount == Instance.azufreAmount)
        {
            Instance.StartCoroutine(Instance.EndMiniGame());
        }
    }
    
    IEnumerator EndMiniGame()
    {
        GameState.SetNextAge(Ages.Ancient);
        FadeToBlack.FadeOut(1f, null);
        SFXController.Play("success");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        yield break;
    }
}