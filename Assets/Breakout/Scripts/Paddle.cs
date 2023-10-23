using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float paddleSpeed = 5; //Velocidad del paddle
    [SerializeField] float xLimit = 7.1f; //Limite del paddle
    [SerializeField] float bigSizeTime = 10; //Tiempo que dura el big size
    [SerializeField] GameManager gameManager;
    bool bulletsActive;
    [SerializeField] GameObject bulletPrefab; //INSTANCIA DE LA BALA
    [SerializeField] float fireRate = 1; //TIEMPO ENTRE DISPAROS DE LAS BALAS
    [SerializeField] float bulletsTime = 10; //TIEMPO QUE DURA EL PODER DE LAS BALAS
    [SerializeField] Vector3 bulletOffset;
    
    public bool BulletsActive {
        get => bulletsActive;
        set {
            bulletsActive = value;
            StartCoroutine(ShootBullets());
            Invoke("ResetBulletsActive", bulletsTime);
        }
    }

    IEnumerator ShootBullets() {
        while (BulletsActive) {
            Instantiate(bulletPrefab, transform.position + bulletOffset, Quaternion.identity);
            yield return new WaitForSeconds(fireRate);
        }
    }

        void ResetBulletsActive() { //DESACTIVAR EL PODER DE LAS BALAS
        bulletsActive = false;
        gameManager.powerUpIsActive = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D) && transform.position.x < xLimit)
        {
            transform.position += Vector3.right * Time.deltaTime * paddleSpeed;
        }

        if (Input.GetKey(KeyCode.A) && transform.position.x > -xLimit)
        {
            transform.position += Vector3.left * Time.deltaTime * paddleSpeed;
        }
    }
    public void IncreaseSize() { //PODER PARA AUMENTAR EL TAMAÑO DE PADDLE
        if (gameManager.ballIsOnPlay == false){
            return;
        }
        // NullReferenceException: Object reference not set to an instance of an object
        // Paddle.IncreaseSize () (at Assets/Breakout/Scripts/Paddle.cs:31)
        // BigSizePaddle.OnTriggerEnter2D (UnityEngine.Collider2D collision) (at Assets/Breakout/Scripts/BigSizePaddle.cs:19)

        Vector3 newSize = transform.localScale;
        newSize.x = 1.2f;
        transform.localScale = newSize;
        StartCoroutine(BackToOriginalSize());
    }

    IEnumerator BackToOriginalSize() {
        yield return new WaitForSeconds(bigSizeTime);
        transform.localScale = new Vector3(1, 1, 1);
        gameManager.powerUpIsActive = false;
    }

}


