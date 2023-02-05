using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongScoreWall : MonoBehaviour
{
    public bool isPlayerSide;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("PongBall"))
        {
            if (!isPlayerSide)
                PongController.Instance.playerScore++;
            else
                PongController.Instance.playerScore = Mathf.Max(0, PongController.Instance.playerScore - 1);

            PongController.UpdateScores();
            if (PongController.Instance.playerScore >= PongController.Instance.maxScore)
                coll.collider.gameObject.GetComponent<PongBall>().MakeBallIdle();
            else
                coll.collider.gameObject.GetComponent<PongBall>().GoBall();
        }
    }
}
