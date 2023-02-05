using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    public Animator creditsAnimator;
    public Image creditsImage;

    private void Awake()
    {
        creditsAnimator = GetComponent<Animator>();
        creditsImage = GetComponent<Image>();
    }

    void LateUpdate()
    {
        Color color = creditsImage.color;
        if (color.a < 1)
        {
            creditsImage.color = new Color(color.r, color.g, color.b, color.a + Time.deltaTime);
        }

        if (color.a > 1)
        {
            creditsAnimator.SetTrigger("StartCredits");
        }
    }

    public void LoadTitleScene()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }

}
