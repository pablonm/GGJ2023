using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FadeToBlack : MonoBehaviour
{
    public static FadeToBlack Instance;
    private CanvasGroup canvasGroup;
    private float targetAlpha;
    private UnityAction callback;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
        Instance.canvasGroup = Instance.GetComponent<CanvasGroup>();
        targetAlpha = canvasGroup.alpha;
    }

    public static void FadeOut(float time, UnityAction callback)
    {
        Instance.callback = callback;
        Instance.StopAllCoroutines();
        Instance.canvasGroup.alpha = 0;
        Instance.StartCoroutine(Instance.FadeCoroutine(time, 1f));
    }

    public static void FadeIn(float time, UnityAction callback)
    {
        Instance.callback = callback;
        Instance.StopAllCoroutines();
        Instance.canvasGroup.alpha = 1;
        Instance.StartCoroutine(Instance.FadeCoroutine(time, -1f));
    }

    IEnumerator FadeCoroutine(float seconds, float stepMultiplier)
    {
        float frames = seconds / Time.deltaTime;
        float alphaStep = 1f / frames * stepMultiplier;
        for (int i = 0; i < frames; i++)
        {
            yield return new WaitForSeconds(seconds / frames);
            canvasGroup.alpha = canvasGroup.alpha + alphaStep;
        }
        if (callback != null)
            callback.Invoke();
        yield break;
    }
}
