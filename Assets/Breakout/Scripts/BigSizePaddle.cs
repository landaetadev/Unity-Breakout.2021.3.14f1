using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSizePaddle : MonoBehaviour
{
    [SerializeField] float speed = .25f;
    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player")) {
            Paddle paddle = collision.transform.GetComponent<Paddle>();
            if (paddle != null)
            { 
                paddle.IncreaseSize();
            }
            
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null) {
                gameManager.powerUpIsActive = true;
            }

            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null) {
            if (gameManager.powerUpOnscene == true) {
                gameManager.powerUpOnscene = false;
            }
        }
    }

}