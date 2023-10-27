using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] int bricksOnLevel;
    [SerializeField] int playerLives = 3;
    public bool ballIsOnPlay;
    float gameTime;
    bool gameStarted;
    [SerializeField] UIController uiController;
    public bool powerUpOnscene;
    public bool powerUpIsActive;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
    }
    public int BricksOnLevel {
        get => bricksOnLevel;
        set {
            bricksOnLevel = value;
            if (bricksOnLevel == 0) {
                Destroy(GameObject.Find("Ball"));
                uiController.ActivateWinnerScreen();
                gameTime = Time.time - gameTime;
                uiController.UpdateTime(gameTime);
            }
        }
    }

    public int PlayerLives {
        get => playerLives;
        set {
            playerLives = value;
            uiController.UpdateLives(playerLives); //ACTUALIZAR LA CANTIDAD DE VIDAS EN LA UI
            if (playerLives == 0) { //SI EL JUGADOR SE QUEDA SIN VIDAS
                uiController.ActivateLoseScreen(); //MOSTRAR PANTALLA DE PERDEDOR
                Destroy(GameObject.Find("Ball")); //DESTRUIR LA BOLA
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

    private void Update() //CERRAR EL JUEGO
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
