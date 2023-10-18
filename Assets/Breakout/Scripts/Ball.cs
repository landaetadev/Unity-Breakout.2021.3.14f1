using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody2d;
    [SerializeField] float ballSpeed = 5;
    Vector2 moveDirection;
    Vector2 currentVelocity;

    void Start()
    {
        //rigidbody2d.GetComponent<Rigidbody2D>();
        rigidbody2d.velocity = Vector2.up * ballSpeed;
    }

    private void FixedUpdate()
    {
        currentVelocity = rigidbody2d.velocity;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveDirection = Vector2.Reflect(currentVelocity, collision.GetContact(0).normal);
        rigidbody2d.velocity = moveDirection;
    }
}
