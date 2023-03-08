using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationActivate : MonoBehaviour
{
    public FallingDoor activador;
    public ZombieDie zActivator;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            activador.Activar();
        }
    }
}