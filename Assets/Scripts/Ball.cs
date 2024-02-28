using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed;
    public Rigidbody2D rb;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        Launch();
    }

    public void ResetPosition()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        Launch();
    }

    void Launch()
    {
        float x = 1f;
        float y = Random.Range(-1.0f, 1.0f);
        Vector2 trajectory = new Vector2(x, y).normalized;
        rb.velocity = trajectory * speed;
    }
}
