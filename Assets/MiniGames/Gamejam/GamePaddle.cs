using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePaddle : MonoBehaviour
{
    public BoxCollider2D boundariesCollider;
    public GameObject ball;
    public float responsiveness;
    PolygonCollider2D coll;
    float ballOffset;

    float minPosition;
    float maxPosition;

    private void Awake()
    {
        coll = GetComponent<PolygonCollider2D>();
    }

    private void Start()
    {
        ballOffset = 0;
        minPosition = boundariesCollider.transform.position.y - boundariesCollider.bounds.extents.y + transform.lossyScale.y * .5f;
        maxPosition = boundariesCollider.transform.position.y + boundariesCollider.bounds.extents.y - transform.lossyScale.y * .5f;
        StartCoroutine(UpdatePositionToTrack());
    }

    IEnumerator UpdatePositionToTrack()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            ballOffset = Random.Range(coll.bounds.extents.y * -0.5f, coll.bounds.extents.y * 0.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("PongBall"))
        {
            SFXController.Play("hitGame");
        }
    }

    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Lerp(transform.position.y, Mathf.Clamp(ball.transform.position.y + ballOffset, minPosition, maxPosition), Time.deltaTime * responsiveness),
            transform.position.z
        );
    }
}
