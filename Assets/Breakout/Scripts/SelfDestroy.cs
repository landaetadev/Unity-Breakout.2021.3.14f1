using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField] float delay;

    void Start()
    {
        Destroy(gameObject, delay);
    }

    public void DestroyFromEvent() {
        Destroy(gameObject);
    }

}
