using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody2d;
    [SerializeField] float ballSpeed = 5;
    Vector2 moveDirection;
    Vector2 currentVelocity;
    GameManager gameManager;
    Transform paddle;
    [SerializeField] AudioController audioController;
    [SerializeField] AudioClip bounceSfx;
    bool superBall;
    [SerializeField] float superBallTime = 10;

    public bool SuperBall {
        get => superBall;
        set {
            superBall = value;
            if(superBall == true)
                StartCoroutine(ResetSuperBall());
        }
    }
    IEnumerator ResetSuperBall() {
        // trailRenderer.enabled = true;
        yield return new WaitForSeconds(superBallTime);
        // trailRenderer.enabled = false;
        gameManager.powerUpIsActive = false;
        superBall = false;
    }

    void Start()
    {
        //rigidbody2d.GetComponent<Rigidbody2D>();
        //rigidbody2d.velocity = Vector2.up * ballSpeed;
        gameManager = FindObjectOfType<GameManager>();
        paddle = transform.parent;
    }

    void Update()
    {
        //INICIA LA BOLA CON ESPACIO
        // if (Input.GetKeyDown(KeyCode.Space)) {
        //     rigidbody2d.velocity = Vector2.up * ballSpeed;
        //     transform.SetParent(null);
        //         gameManager.ballIsOnPlay = true;
        //         if (gameManager.GameStarted = false) {
        //             gameManager.GameStarted = true; //COMIENZA A CONTAR EL TIEMPO DE JUEGO
        //     }
        // }

        //INICIA LA BOLA CON EL CLICK DEL MOUSE
        if (Input.GetMouseButtonDown(0) && gameManager.ballIsOnPlay == false) {
            rigidbody2d.velocity = Vector2.up * ballSpeed;
            transform.SetParent(null);
            gameManager.ballIsOnPlay = true;
            if (gameManager.GameStarted == false) {
                gameManager.GameStarted = true; //COMIENZA A CONTAR EL TIEMPO DE JUEGO
            }
        }
    }

    private void FixedUpdate()
    {
        currentVelocity = rigidbody2d.velocity;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        //SI LA BOLA CHOCO CON UN BRICK CAMBIA DE DIRECCION
        if (collision.transform.CompareTag("Brick") && superBall) {
            rigidbody2d.velocity = currentVelocity;
            return;
        }

        moveDirection = Vector2.Reflect(currentVelocity, collision.GetContact(0).normal);
        rigidbody2d.velocity = moveDirection;
        //SONIDO
        audioController.PlaySfx(bounceSfx);

        if (collision.transform.CompareTag("BottomLimit")) {

            if (gameManager != null) {
                gameManager.PlayerLives -= 1;
                if (gameManager.PlayerLives > 0) {
                    rigidbody2d.velocity = Vector2.zero;
                    transform.SetParent(paddle); //TRAER LA BOLA AL PADDLE
                    transform.localPosition = new Vector2(0, 0.61f); //POSICIONAR LA BOLA EN EL PADDLE
                    gameManager.ballIsOnPlay = false; //LA BOLA NO ESTA EN JUEGO
                }
            }
        }
    }

}
