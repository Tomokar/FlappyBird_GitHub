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

        if (groundCollider != null)
        {
            groundWidth = groundCollider.size.x;
        }

        if (caveTransform != null)
        {
            caveImage = caveTransform.GetComponent<SpriteRenderer>();
            caveWidth = caveImage.size.x;
        }
    }

    void Update()
    {
        if (groundCollider != null)
        {
            if (transform.position.x < -groundWidth)
            {
                moveGround();
            }
        }

        if (caveTransform != null)
        {
            if (caveTransform.position.x < -caveWidth)
            {
                moveCave();
            }
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
