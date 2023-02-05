using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneController : MonoBehaviour
{
    private void Start()
    {
        GoToAge(GameState.previousAge, true);
        FadeToBlack.FadeIn(1f, () => GoToAge(GameState.currentAge));
        GameObject BGM = GameObject.Find("BGMusic");
        if (BGM != null)
            BGM.GetComponent<AudioSource>().UnPause();
    }
    

    public void GoToAge(Ages targetAge)
    {
        SFXController.Play("makingProgress");
        GoToAge(targetAge, false);
    }

    public void GoToAge(Ages targetAge, bool immediate)
    {
        List<Age> agesList = new List<Age>(FindObjectsByType<Age>(FindObjectsSortMode.None));
        Age ageToGo = agesList.Find(a => a.ageName == targetAge);
        if (ageToGo != null)
            if (immediate)
                CameraController.MoveTo(ageToGo.gameObject);
            else
                CameraController.MoveSmoothlyTo(ageToGo.gameObject);
    }

    // JUST FOR DEBUGGING
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) GoToAge(Ages.Contemporary);
        if (Input.GetKeyDown(KeyCode.W)) GoToAge(Ages.Modern);
        if (Input.GetKeyDown(KeyCode.E)) GoToAge(Ages.Middle);
        if (Input.GetKeyDown(KeyCode.R)) GoToAge(Ages.Ancient);
        if (Input.GetKeyDown(KeyCode.T)) GoToAge(Ages.Prehistory);

        if (Input.GetKeyDown(KeyCode.A)) FadeToBlack.FadeOut(1f, null);
        if (Input.GetKeyDown(KeyCode.S)) FadeToBlack.FadeIn(1f, null);
    }
}

public enum Ages
{
    Prehistory,
    Ancient,
    Middle,
    Modern,
    Contemporary
}
