using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] float speed;
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player")) {
            Paddle paddle = FindObjectOfType<Paddle>();
            if (paddle != null) {
                paddle.BulletsActive = true;

                GameManager gameManager = FindObjectOfType<GameManager>();
                if (gameManager != null) {
                    gameManager.powerUpIsActive = true;
                }
            }

            //Destroy(gameObject);
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
