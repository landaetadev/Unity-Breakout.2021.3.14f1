using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    [SerializeField] AudioClip explosionSfx;
    void Start()
    {
        AudioController audioController = FindObjectOfType<AudioController>();
        audioController.PlaySfx(explosionSfx);
    }

}