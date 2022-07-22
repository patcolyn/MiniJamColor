using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;
    public bool primary = false;

    public float runSpeed = 40f;
    bool jump = false;
    float horizontalMove = 0f;

    public Color PlayerColor;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>()) {

            PlayerController other = collision.gameObject.GetComponent<PlayerController>();

            if (other.PlayerColor == PlayerColor)
            {
                Destroy(transform.gameObject);
            }
        }
    }

    private void Start()
    {
        transform.GetComponentInChildren<SpriteRenderer>().color = PlayerColor;
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


        jump = Input.GetKeyDown(KeyCode.Space);
        controller.Move(horizontalMove * Time.deltaTime * 60, false, jump);
        jump = false;
    }
}
