using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombUpdate : MonoBehaviour
{
    [SerializeField] private GameObject TheBomb;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Invoke("DesactivarObjeto", 2f);
        }
    }

    private void DesactivarObjeto()
    {
        gameObject.SetActive(false);
    }
}
