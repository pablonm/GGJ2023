using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class PlanetsCamera : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField] [Range(.01f, 1f)]private float smoothSpeed = .125f;
    private Vector3 _velocity = Vector3.zero;
    public float MinX, MaxX, MinY, MaxY;
    public bool isCompleted = false;
    private MouseInputProvider _mouse;
    private void Awake()
    {
        _mouse = FindObjectOfType<MouseInputProvider>();
        _mainCamera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(Mathf.Clamp(GetMousePosition().x, MinX, MaxX),
            Mathf.Clamp(GetMousePosition().y, MinY, MaxY),
            GetMousePosition().z);
        transform.position = Vector3.SmoothDamp(transform.position,
            desiredPosition,
            ref _velocity, 
            smoothSpeed);
    }

    Vector3 GetMousePosition()
    {
        if (!isCompleted)
        {
            Vector2 mouseWorldPosition = _mouse.WorldPosition;
            return new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, -5f);
        }

        return new Vector3(0f, 0f, -5f);
    }
}
