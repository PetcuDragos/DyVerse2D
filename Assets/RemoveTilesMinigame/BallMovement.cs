using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed;
    private bool touchWasActive = false;
    private Vector2 lastVelocity;

    private Rigidbody2D rb;
    private Vector2 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = this.transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!touchWasActive && Input.touchCount > 0)
        {
            touchWasActive = true;
            rb.AddForce(new Vector2(0, speed * Time.deltaTime));
        }
        lastVelocity = rb.velocity;
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        float speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision2D.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
        if (collision2D.collider.gameObject.name.Contains("Tile"))
        {
            collision2D.collider.gameObject.SetActive(false);
        }
        if (collision2D.collider.gameObject.name.Contains("GameOverBorder"))
        {
            rb.velocity = Vector2.zero;
            this.transform.position = initialPosition;
            touchWasActive = false;
        }
    }
}
