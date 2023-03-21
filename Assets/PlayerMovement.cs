using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public JoystickMovement joystickMovement;
    public float baseSpeed;
    public float maxSpeed;
    private Rigidbody2D rb;

    private SpriteRenderer sr;
    private float JOYSTICK_THRESHOLD_TO_MOVE = 6;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if (Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     this.transform.position += new Vector3(0, -1, 0);
        //     print("UpArrow was pressed");
        // }
        // if (Input.GetKeyDown(KeyCode.DownArrow))
        // {
        //     this.transform.position += new Vector3(0, 1, 0);
        //     print("DownArrow was pressed");
        // }
        // if (Input.GetKeyDown(KeyCode.LeftArrow))
        // {
        //     this.transform.position += new Vector3(1, 0, 0);
        //     print("LeftArrow was pressed");
        // }
        // if (Input.GetKeyDown(KeyCode.RightArrow))
        // {
        //     this.transform.position += new Vector3(-1, 0, 0);
        //     print("RightArrow was pressed");
        // }

        if (joystickMovement != null && joystickMovement.getJoystickDirection().magnitude > JOYSTICK_THRESHOLD_TO_MOVE)
        {
            rb.velocity = (joystickMovement.getJoystickDirection().normalized *
                Mathf.Min(baseSpeed * joystickMovement.getDistanceFromFingerToJoystickOrigin(), maxSpeed)) * Time.deltaTime;
            if (rb.velocity.x < 0) sr.flipX = false;
            else sr.flipX = true;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
