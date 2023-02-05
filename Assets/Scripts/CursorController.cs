using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{
    public static CursorController Instance;
    
    public List<Texture2D> cursorImages;
    public Minigame currentMinigame = Minigame.MainScene;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
            Destroy(gameObject);
        else
            Instance = this;
        
        SceneManager.sceneLoaded += UpdateCursor;
        DontDestroyOnLoad(gameObject);
    }

    void UpdateCursor(Scene scene, LoadSceneMode loadSceneMode)
    {
        Texture2D cursorTexture = findCursorTexture(currentMinigame);
        if (cursorTexture != null)
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    private Texture2D findCursorTexture(Minigame minigame)
    {
        foreach (Texture2D  texture2D in cursorImages)
        {
            if (texture2D.name == minigame.ToString())
                return texture2D;
        }

        Debug.Log($"Cursor not found for:{minigame.ToString()}");
        
        return null;
    }

    public enum Minigame
    {
        MainScene,
        GGJ,
        Astronomy,
        Gunpowder,
        Acueduct,
        Crops,
        End
    }
    
}


