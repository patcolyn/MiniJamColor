using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public bool player;
    public float speed;
    public float jump_force;
    public Color PlayerColor;

    bool jumpbtn;

    private Rigidbody2D _rigidBody;

    private void Start()
    {
        transform.GetComponentInChildren<SpriteRenderer>().color = PlayerColor;
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void UpdatePosition()
    {
        float movement = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        transform.position += new Vector3(movement, 0, 0);

    }

    private void Update()
    {
        jumpbtn = Input.GetButtonDown("Jump");

        if (jumpbtn)
        {
            _rigidBody.AddForce(new Vector2(0, jump_force), ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        UpdatePosition();
    }
}
