using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;
    public bool primary = false;
    private Rigidbody2D rb;
    public float runSpeed = 40f;
    bool jump = false;
    float horizontalMove = 0f;
    private bool hasEnteredFinish = false;
    public Color PlayerColor;
    public ParticleSystem dust;
    private bool facingRight = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasEnteredFinish) {
            if (collision.gameObject.GetComponent<PlayerController>())
            {

                PlayerController other = collision.gameObject.GetComponent<PlayerController>();

                if (other.PlayerColor == PlayerColor)
                {
                    Destroy(transform.gameObject);
                }
            }
        }
    }

    private void Start()
    {
        transform.GetComponentInChildren<SpriteRenderer>().color = PlayerColor;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!hasEnteredFinish)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            jump = Input.GetKeyDown(KeyCode.Space);
            controller.Move(horizontalMove * Time.deltaTime * 60, false, jump);
            jump = false;
            if(horizontalMove > 0.01f || horizontalMove < -0.01f || jump)
            {
                CreateDust();
            }

            Flip();
        }
        else
        {
            Destroy(rb);
            Destroy(GetComponent<BoxCollider2D>());
        }
    }

    public void EnteredFinish()
    {
        hasEnteredFinish = true;
        Debug.Log("Has entered Finish");
        StartCoroutine(destroyAfterAnimDuration());
    }
    private IEnumerator destroyAfterAnimDuration()
    {
        Debug.Log("start wait " + Time.time);
        yield return new WaitForSeconds(0.35f);
        Debug.Log("end wait "+ Time.time);
        Destroy(transform.gameObject);
    }
    private void CreateDust()
    {
        dust.Play();
    }

    // Doesn't work for some reason
    private void Flip()
    {
        if (horizontalMove > 0.01f && !facingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            facingRight = !facingRight;
        }
        else if (horizontalMove < -0.01f && facingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            facingRight = !facingRight;
        }
    }
}
