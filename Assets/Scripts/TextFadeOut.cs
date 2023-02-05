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
        instructionText.gameObject.SetActive(instructionText.alpha > 0);
    }
    
    IEnumerator FadeOutText()
    {
        yield return new WaitForSeconds(1f);
        _fadeOut = true;
    }
    
}
