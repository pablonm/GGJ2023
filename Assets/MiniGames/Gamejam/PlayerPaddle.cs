using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    public BoxCollider2D boundariesCollider;

    float minPosition;
    float maxPosition;

    private void Start()
    {
        minPosition = boundariesCollider.transform.position.y - boundariesCollider.bounds.extents.y + transform.lossyScale.y * .5f;
        maxPosition = boundariesCollider.transform.position.y + boundariesCollider.bounds.extents.y - transform.lossyScale.y * .5f;
    }

    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, minPosition, maxPosition),
            transform.position.z
        );
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("PongBall"))
        {
            SFXController.Play("hitPlayer");
        }
    }
}
