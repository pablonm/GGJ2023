using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInputProvider : MonoBehaviour
{
    public Vector2 WorldPosition { get; private set; }
    public event Action Clicked;

    private void OnLook(InputValue inputValue)
    {
        WorldPosition = Camera.main.ScreenToWorldPoint(inputValue.Get<Vector2>());
    }

    private void OnAction(InputValue _)
    {
        Clicked?.Invoke();
    }
}
