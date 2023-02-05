using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextFadeOut : MonoBehaviour
{
    [SerializeField] private TMP_Text instructionText;
    private bool _fadeOut = false;

    void Start()
    {
        StartCoroutine(FadeOutText());
    }

    void Update()
    {
        if (_fadeOut)
        {
            instructionText.alpha -= Time.deltaTime;
        }
    }
    
    IEnumerator FadeOutText()
    {
        yield return new WaitForSeconds(1f);
        _fadeOut = true;
    }
    
}
