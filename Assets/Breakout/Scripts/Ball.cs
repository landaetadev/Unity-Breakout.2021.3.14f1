using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody2d;
    [SerializeField] float ballSpeed = 5;
    [SerializeField] AudioController audioController;
    [SerializeField] AudioClip bounceSfx;
    Vector2 moveDirection;
    Vector2 currentVelocity;
    //GameManager gameManager;
    Transform paddle;
    bool superBall;
    [SerializeField] float superBallTime = 10;
    [SerializeField] float yMinSpeed = 2;
    [SerializeField] TrailRenderer trailRenderer; //COLA DE LA BOLA

    public bool SuperBall {
        get => superBall;
        set {
            superBall = value;
            if(superBall)
                StartCoroutine(ResetSuperBall());
        }
    }
    void Start()
    {
        //rigidbody2d = GetComponent<Rigidbody2D>();  
        //rigidbody2d.velocity = Vector2.up * ballSpeed;
        //gameManager = FindObjectOfType<GameManager>();
        paddle = transform.parent;
    }

    private void Update()
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
        if (Input.GetMouseButtonDown(0) && !GameManager.Instance.ballIsOnPlay) {
            rigidbody2d.velocity = Vector2.up * ballSpeed;
            transform.parent = null;
            GameManager.Instance.ballIsOnPlay = true;
            if (!GameManager.Instance.GameStarted) {
                GameManager.Instance.GameStarted = true;
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

        // VELOCIDAD MINIMA EN Y
        if (Mathf.Abs(moveDirection.y) < yMinSpeed) {
            moveDirection.y = yMinSpeed * Mathf.Sign(moveDirection.y);
        }
        rigidbody2d.velocity = moveDirection;
        //SONIDO DE REBOTE
        audioController.PlaySfx(bounceSfx);

        if (collision.transform.CompareTag("BottomLimit")) {
            if (GameManager.Instance != null) {
                GameManager.Instance.PlayerLives--;
                if (GameManager.Instance.PlayerLives > 0) {
                    rigidbody2d.velocity = Vector2.zero;
                    transform.SetParent(paddle); //TRAER LA BOLA AL PADDLE
                    transform.localPosition = new Vector2(0, 0.65f);  //POSICIONAR LA BOLA EN EL PADDLE
                    GameManager.Instance.ballIsOnPlay = false;  //LA BOLA NO ESTA EN JUEGO
                }
            }
        }
    }

    IEnumerator ResetSuperBall() {
        trailRenderer.enabled = true;
        yield return new WaitForSeconds(superBallTime);
        trailRenderer.enabled = false;
        GameManager.Instance.powerUpIsActive = false;
        superBall = false;
    }
}
