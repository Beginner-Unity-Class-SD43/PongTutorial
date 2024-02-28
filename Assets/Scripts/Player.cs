using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    Vector3 startPosition;

    [SerializeField] bool isAI;
    Vector2 forwardDirection;

    Ball ball;

    float movement;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();

        ball = FindObjectOfType<Ball>();

        if (isAI)
        {
            forwardDirection = Vector2.left;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAI)
        {
            movement = Input.GetAxisRaw("Vertical");
        }
        else
        {
            float targetYPos = GetNewYPos();
            transform.position = new Vector3(transform.position.x, targetYPos, transform.position.z);
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, movement * speed);
    }

    public void ResetPosition()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }

    float GetNewYPos()
    {
        float result = transform.position.y;

        if (BallIncoming())
        {
            result = Mathf.MoveTowards(transform.position.y, ball.transform.position.y, speed * Time.deltaTime);
        }

        return result;
    }

    bool BallIncoming()
    {
        float dotP = Vector2.Dot(ball.rb.velocity, forwardDirection);
        return dotP < 0f;
    }
}
