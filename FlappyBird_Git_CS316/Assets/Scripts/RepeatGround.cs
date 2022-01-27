using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatGround : MonoBehaviour
{
    private BoxCollider2D groundCollider;

    private SpriteRenderer caveImage;
    [SerializeField] private Transform caveTransform;

    private float caveWidth;
    private float groundWidth;

    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        caveImage = caveTransform.GetComponent<SpriteRenderer>();
        groundWidth = groundCollider.size.x;
        caveWidth = caveImage.size.x;
    }

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

    private void moveCave()
    {
        Vector2 caveOffset = new Vector2(caveWidth * 2f, 0);
        caveTransform.position = (Vector2)caveTransform.position + caveOffset;
    }
}
