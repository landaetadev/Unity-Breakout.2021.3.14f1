using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip buttonPressedSfx;

    public void LoadGameScene() {
        SceneManager.LoadScene("Game");
    }

    public void PlaySfx() {
        audioSource.PlayOneShot(buttonPressedSfx);
    }

}
