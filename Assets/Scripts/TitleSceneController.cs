using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{
    public void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }

    IEnumerator StartGameCoroutine()
    {
        SFXController.Play("comenzar");
        FadeToBlack.FadeOut(1f, null);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
