using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    //GameObject gameManagerObj;
    GameManager gameManager;
    private void Start()
    {
        /*gameManagerObj = GameObject.Find("GameManager");
        if (gameManagerObj != null) {
            gameManager = gameManagerObj.GetComponent<GameManager>();
            if (gameManager != null) {
                gameManager.bricksOnLevel += 1;
            }
        }*/

        gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null) {
            gameManager.BricksOnLevel += 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {

        if (gameManager != null) {
            gameManager.BricksOnLevel -= 1;
        }

        Destroy(gameObject);

    }
}
