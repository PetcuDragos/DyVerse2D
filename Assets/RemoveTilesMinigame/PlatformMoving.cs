using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{

    private Vector3 position;
    private float width;

    void Awake()
    {
        width = Screen.width;

        // Position used for the cube.
        position = this.transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 screenPos = touch.position;
            screenPos.z = 10.0f;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            transform.position = new Vector2(worldPos.x,transform.position.y);
        }
    }
}
