using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager InstanceGameManager;

    [SerializeField] int bricksOnLevel;
    [SerializeField] int playerLives = 3;
    public bool ballIsOnPlay;
    float gameTime; //Tiempo de duracion del juego
    bool gameStarted;
    [SerializeField] UIController uiController;
    public bool powerUpOnscene;
    public bool powerUpIsActive;

    private void Awake()
    {
        if (InstanceGameManager == null) {
            InstanceGameManager = this;
        }
    }

    public int BricksOnLevel {
        get => bricksOnLevel;
        set {
            bricksOnLevel = value;
            if (bricksOnLevel == 0) {
                print("WIN!");
                Destroy(GameObject.Find("Ball")); //DESTRUIR LA BOLA

                //MOSTRAR EL TIEMPO DE JUEGO
                gameTime = Time.time - gameTime;
                print("Tiempo de juego: " + gameTime);

                uiController.ActivateWinnerScreen();//MOSTRAR PANTALLA DE GANADOR
                uiController.UpdateTime(gameTime); //MUESTRA EL TIEMPO FINAL EN LA UI
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
            uiController.UpdateLives(playerLives); //ACTUALIZAR LA CANTIDAD DE VIDAS EN LA UI
            if (playerLives == 0) { //SI EL JUGADOR SE QUEDA SIN VIDAS
                print("LOSE!");
                uiController.ActivateLoseScreen(); //MOSTRAR PANTALLA DE PERDEDOR
                Destroy(GameObject.Find("Ball")); //DESTRUIR LA BOLA
            }
        }
    }

    private void Update()//CERRAR EL JUEGO
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
