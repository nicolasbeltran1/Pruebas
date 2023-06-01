using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    private Rigidbody2D rb;
    private Rigidbody2D _rigibody;
    private Animator _anim;
    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _rigibody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        moveLeft = false;
        moveRight = false;
    }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        if (Input.GetButtonDown("Jump") )
        {
            Debug.Log(Mathf.Abs(_rigibody.velocity.y));
            _rigibody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            _anim.SetTrigger("jump");
        }
    }
}
