using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGamePreview : MonoBehaviour
{
    public string MiniGameSceneName;
    public CursorController.Minigame minigame;
    bool loading = false;

    public void OpenMiniGame()
    {
        Age parentAge = transform.parent.GetComponent<Age>();
        if (loading == false && parentAge.ageName == GameState.currentAge)
            StartCoroutine(OpenMiniGameCoroutine());
    }

    IEnumerator OpenMiniGameCoroutine()
    {
        GameObject BGM = GameObject.Find("BGMusic");
        if (BGM != null)
            BGM.GetComponent<AudioSource>().Pause();
        FadeToBlack.FadeOut(1f, null);
        yield return new WaitForSeconds(1f);
        CursorController.Instance.currentMinigame = minigame;
        SceneManager.LoadScene(MiniGameSceneName, LoadSceneMode.Single);
    }
}