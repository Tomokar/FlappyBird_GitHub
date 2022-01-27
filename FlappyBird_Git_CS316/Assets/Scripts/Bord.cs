using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bord : MonoBehaviour
{
    public float flapPower = 1f;

    private bool isDead = false;
    private Rigidbody2D Rb2d;
    private Animator anim;

    [SerializeField] private int Lives = 3;

    void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetButtonDown("Flap"))
            {
                anim.SetTrigger("Flap");
                Rb2d.velocity = Vector2.zero;
                Rb2d.AddForce(new Vector2(0, (flapPower * 100)));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        anim.SetTrigger("Die");
        Rb2d.velocity = Vector2.zero;
        isDead = true;
        GameControl.instance.BirdDied();
    }
}
