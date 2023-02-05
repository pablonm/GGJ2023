using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Texture2D cursorTexture;

    private void Awake()
    {
        if (cursorTexture != null)
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }
}


