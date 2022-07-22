using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;
    bool jump = false;
    float horizontalMove = 0f;

    public Color PlayerColor;


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
