using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollusionController : MonoBehaviour
{
    public Ball ballMovement;
    public ScoreController scoreController;

    void BounceFromRacket(Collision2D c)
    {
        Vector3 ballPoisition = this.transform.position;
        Vector3 racketPosition = c.gameObject.transform.position;

        float racketHeight = c.collider.bounds.size.y;

        float x;
        if (c.gameObject.name == "RacketPlayer1")
        {
            x = 1;
        }
        else
        {
            x = -1;
        }

        float y = (ballPoisition.y - racketPosition.y) / racketHeight;
        this.ballMovement.increaseHitCounter();
        this.ballMovement.MoveBall(new Vector2(x, y));

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RacketPlayer1" || collision.gameObject.name == "RacketPlayer2")
        {
            this.BounceFromRacket(collision);
        }
        else if (collision.gameObject.name == "LeftWall")
        {
            Debug.Log("Left collision");
            this.scoreController.GoalPlayer2();
            StartCoroutine(this.ballMovement.StartBall(true));
        }
        else if (collision.gameObject.name == "RightWall")
        {
            Debug.Log("Right collision");
            this.scoreController.GoalPlayer1();
            StartCoroutine(this.ballMovement.StartBall(false));
        }
    }
}
