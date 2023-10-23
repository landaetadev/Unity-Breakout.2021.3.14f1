using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    //GameObject gameManagerObj;
    GameManager gameManager;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] GameObject[] powerUpsPrefabs;
    [SerializeField] int powerUpChance = 20;
    public bool powerUpOnscene;
    bool isQuitting;

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
        Instantiate(explosionPrefab, transform.position, Quaternion.identity); // ACTIVA SONIDO DE EXPLOSION
        Destroy(gameObject);
    }

    private void OnDestroy() {
        // if (isQuitting)
        //     return;

        // || gameManager.powerUpIsActive
        if (gameManager.powerUpOnscene)
            return;

        int possibility = Random.Range(0, 100);

        if (possibility < powerUpChance) {
            int randomPowerUp = Random.Range(0, powerUpsPrefabs.Length);
            Instantiate(powerUpsPrefabs[randomPowerUp], transform.position, Quaternion.identity);
            gameManager.powerUpOnscene = true;
        }
    }
}
