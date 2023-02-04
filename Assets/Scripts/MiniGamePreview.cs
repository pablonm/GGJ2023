using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGamePreview : MonoBehaviour
{
    public string MiniGameSceneName;
    bool loading = false;

    public void OpenMiniGame()
    {
        if (loading == false)
            StartCoroutine(OpenMiniGameCoroutine());
    }

    IEnumerator OpenMiniGameCoroutine()
    {
        FadeToBlack.FadeOut(1f, null);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(MiniGameSceneName, LoadSceneMode.Single);
        yield break;
    }
}