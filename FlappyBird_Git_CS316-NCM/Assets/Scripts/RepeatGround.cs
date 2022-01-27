using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatGround : MonoBehaviour
{
    private BoxCollider2D groundCollider;

    private float groundWidth;

    // Start is called before the first frame update
    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundWidth = groundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -groundWidth)
        {
            moveGround();
        }
    }

    private void moveGround()
    {
        Vector2 groundOffset = new Vector2(groundWidth * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
