using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(JumpToCredits());
    }

    IEnumerator JumpToCredits()
    {
        yield return new WaitForSeconds(7f);
        FadeToBlack.FadeOut(1f, null);
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }
}
