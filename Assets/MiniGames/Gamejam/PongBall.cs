using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    public BoxCollider2D boundaries;
    public float ballSpeed;
    Rigidbody2D rb;
    Vector3 lastFrameVelocity;
    bool ballStarted = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        transform.position = boundaries.bounds.center;
    }

    public void GoBall()
    {
        transform.position = boundaries.bounds.center;
        rb.velocity = Vector2.right * ballSpeed;
    }

    public void MakeBallIdle()
    {
        transform.position = boundaries.bounds.center;
        rb.velocity = Vector2.zero;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !ballStarted)
        {
            ballStarted = true;
            rb.velocity = Vector2.right * ballSpeed;
        }
    }
}
