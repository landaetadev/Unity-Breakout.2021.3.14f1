using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] int bricksOnLevel;
    [SerializeField] int playerLives = 3;
    public bool ballIsOnPlay;
    float gameTime; //Tiempo de duracion del juego
    bool gameStarted;
    

    public int BricksOnLevel {
        get => bricksOnLevel;
        set {
            bricksOnLevel = value;
            if (bricksOnLevel == 0) {
                print("Game Over!");
                Destroy(GameObject.Find("Ball"));
                //MOSTRAR EL TIEMPO
                gameTime = Time.time - gameTime;
                print("Tiempo de juego: " + gameTime);
                // uiController.ActivateWinnerScreen();
                //MOSTRAR PANTALLA DE GANADOR
                // uiController.UpdateTime(gameTime);
            }
        }
    }

    public bool GameStarted {
        get => gameStarted;
        set {
            gameStarted = value;
            gameTime = Time.time;
        }
    }

    public int PlayerLives {
        get => playerLives;
        set {
            playerLives = value;
            // uiController.UpdateLives(playerLives);
            if (playerLives == 0) {
                // uiController.ActivateLoseScreen();
                Destroy(GameObject.Find("Ball"));
            }
        }
    }
}
