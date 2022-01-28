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
    private PolygonCollider2D polyCol;

    [SerializeField] private int Lives = 3;
    [SerializeField] private HeartBar hpBar;

    void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        polyCol = GetComponent<PolygonCollider2D>();
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
        if (other.gameObject.tag == "Ground")
        {
            anim.SetTrigger("Die");
            Rb2d.velocity = Vector2.zero;
            isDead = true;
            GameControl.instance.BirdDied();
        }
        else if (other.gameObject.tag == "Column")
        {
            if (Lives == 1)
            {
                anim.SetTrigger("Die");
                Rb2d.velocity = Vector2.zero;
                isDead = true;
                hpBar.health--;
                Lives--;
                GameControl.instance.BirdDied();
            }
            else
            {
                hpBar.health--;
                Lives--;

                StartCoroutine(goPhase());
            }
        }
    }

    IEnumerator goPhase()
    {
        polyCol.enabled = false;
        //Rb2d.simulated = false;

        yield return new WaitForSeconds(2f);

        polyCol.enabled = true;
        Rb2d.simulated = true;
    }
}
