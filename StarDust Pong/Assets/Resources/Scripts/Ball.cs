using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float movementSpeed;
    public float extraSpeed;
    public float maxSpeed;
    int hitCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.StartBall());
    }
    void PositionBall(bool isStartingPlayer1)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (isStartingPlayer1)
        {
            this.gameObject.transform.localPosition = new Vector3(-100, 0, -1);
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(100, 0, -1);
        }
    }

    public IEnumerator StartBall(bool isStartingPlayer = true)
    {
        this.PositionBall(isStartingPlayer);

        this.hitCounter = 0;
        yield return new WaitForSeconds(2);
        if (isStartingPlayer)
            this.MoveBall(new Vector2(-1, 0));
        else
            this.MoveBall(new Vector2(1, 0));
    }

    public void MoveBall(Vector2 dir)
    {
        dir = dir.normalized;

        float speed = this.movementSpeed + this.hitCounter * this.extraSpeed;

        Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();

        rigidbody2D.velocity = dir * speed;
    }

    public void increaseHitCounter()
    {
        if (this.hitCounter * this.extraSpeed <= this.maxSpeed)
        {
            this.hitCounter++;
        }
    }


}
