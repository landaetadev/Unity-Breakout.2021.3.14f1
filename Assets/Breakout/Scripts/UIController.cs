using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject winnerScreen;
    [SerializeField] GameObject[] hearts;
    [SerializeField] TMP_Text gameTimeUI;
    [SerializeField] AudioController audioController;
    [SerializeField] AudioClip buttonPressedSfx;
    [SerializeField] AudioClip loseLifeSfx;


    public void ActivateLoseScreen()
    {
        audioController.UpdateMusicVolume(.25f);
        loseScreen.SetActive(true);
    }

    public void ActivateWinnerScreen()
    {
        audioController.UpdateMusicVolume(.25f);
        winnerScreen.SetActive(true);
    }

    public void TryAgain() {
        audioController.PlaySfx(buttonPressedSfx); //SONIDO AL PRESIONAR BOTON
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu() {
        audioController.PlaySfx(buttonPressedSfx); //SONIDO AL PRESIONAR BOTON
        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateLives(int currentLives) {
        for (int i = 0; i < hearts.Length; i++) {
            if (i >= currentLives) {
                hearts[i].SetActive(false);
            }
        }
        audioController.PlaySfx(loseLifeSfx); //SONIDO AL PERDER UNA VIDA
    }

    public void UpdateTime(float gameTime) {
        gameTimeUI.text = "Time: " + Mathf.Floor(gameTime) + " seconds";
        
    }
}
