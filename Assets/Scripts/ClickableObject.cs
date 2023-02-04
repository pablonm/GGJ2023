using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class ClickableObject : MonoBehaviour
{
    public UnityEvent OnClick; 

    private void OnMouseDown()
    {
        OnClick.Invoke();
    }
}
