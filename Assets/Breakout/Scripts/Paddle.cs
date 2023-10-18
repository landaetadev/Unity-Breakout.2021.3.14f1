using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float paddleSpeed = 5; //Velocidad del paddle
    [SerializeField] float xLimit = 7.1f; //Limite del paddle
    

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D) && transform.position.x < xLimit)
        {
            transform.position += Vector3.right * Time.deltaTime * paddleSpeed;
        }

        if (Input.GetKey(KeyCode.A) && transform.position.x > -xLimit)
        {
            transform.position += Vector3.left * Time.deltaTime * paddleSpeed;
        }
    }
}
