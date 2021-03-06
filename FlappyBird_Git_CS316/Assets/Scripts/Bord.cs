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
    //private PolygonCollider2D polyCol;

    private bool phaseActive = false;

    private SpriteRenderer activeSprite;

    private PolygonCollider2D columnCol1;
    private PolygonCollider2D columnCol2;

    [SerializeField] public int Lives = 3;
    [SerializeField] private HeartBar hpBar;

    void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        activeSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetButtonDown("Flap"))
            {
                FindObjectOfType<AudioManager>().Play("Flap");

                if (phaseActive == true)
                {
                    anim.SetTrigger("phaseFlap");
                }
                else
                {
                    anim.SetTrigger("Flap");
                }
                Rb2d.velocity = Vector2.zero;
                Rb2d.AddForce(new Vector2(0, (flapPower * 100)));
            }
        }
    }

    IEnumerator OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Column")
        {
            if (Lives > 1)
            {
                columnCol1 = other.gameObject.transform.GetChild(0).GetComponent<PolygonCollider2D>();
                columnCol2 = other.gameObject.transform.GetChild(1).GetComponent<PolygonCollider2D>();
            }

            if (Lives == 1)
            {
                FindObjectOfType<AudioManager>().Play("Death");
                anim.SetTrigger("Die");
                Rb2d.velocity = Vector2.zero;
                isDead = true;
                hpBar.health--;
                Lives--;
                GameControl.instance.BirdDied();
            }

            else
            {
                columnCol1.enabled = false;
                columnCol2.enabled = false;
                phaseActive = true;
                anim.SetBool("phaseActive", true);

                FindObjectOfType<AudioManager>().Play("Hurt");
                hpBar.health--;
                Lives--;

                yield return new WaitForSeconds(2.5f);

                columnCol1.enabled = true;
                columnCol2.enabled = true;
                phaseActive = false;
                anim.SetBool("phaseActive", false);
            }
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Death");
            anim.SetTrigger("Die");
            Rb2d.velocity = Vector2.zero;
            isDead = true;
            GameControl.instance.BirdDied();
        }
    }
}
