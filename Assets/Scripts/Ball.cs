using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float randUp;
    public float speed;
    Rigidbody2D ballBody;
    public float speedUp;

    GameController cont;
    // Start is called before the first frame update
    void Start()
    {
        ballBody = GetComponent<Rigidbody2D>();
        cont = FindObjectOfType<GameController>();
    }

    private void OnEnable()
    {
        Invoke("PushBall", 1f);
    }
    private void PushBall()
    {
        float x, y;
        int direction = Random.Range(0, 2);
        if (direction == 0)
        {
            x = speed;
        }
        else
        {
            x = -speed;
        }

        y = Random.Range(-randUp, randUp);
        ballBody.AddForce(new Vector2(x, y));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = ballBody.velocity.x + (ballBody.velocity.x > 0 ? speedUp : -speedUp);
            float additionalSpeedY = ballBody.velocity.y > 0 ? speedUp : -speedUp;
            vel.y = ((ballBody.velocity.y + additionalSpeedY) / 2) + ((collision.collider.attachedRigidbody.velocity.y + additionalSpeedY) / 2);

            ballBody.velocity = vel;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            if (ballBody.velocity.x > 0)
            {
                cont.Score(true);
            }
            else if (ballBody.velocity.x < 0)
            {
                cont.Score(false);
            }
            else
            {

            }
            ballBody.velocity = Vector2.zero;
            transform.position = Vector3.zero;
            Invoke("PushBall", 2f);
        }
    }
}
