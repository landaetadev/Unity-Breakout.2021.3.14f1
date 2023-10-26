using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBall : MonoBehaviour
{
    // [SerializeField] float speed = 1;
    // private void Update()
    // {
    //     transform.Translate(Vector2.down * Time.deltaTime * speed);
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player")) {
            Ball ball = FindObjectOfType<Ball>();
            if (ball != null) {
                ball.SuperBall = true;
            }
        
            //GameManager gameManager = FindObjectOfType<GameManager>();
            if (GameManager.InstanceGameManager != null) {
                GameManager.InstanceGameManager.powerUpIsActive = true;
            }

            Destroy(gameObject);
        }
    }

}
