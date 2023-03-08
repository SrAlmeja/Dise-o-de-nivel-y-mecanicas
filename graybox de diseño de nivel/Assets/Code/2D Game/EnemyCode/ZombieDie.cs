using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDie : MonoBehaviour
{
    public Animator animator;
    public GameObject canon;

    public void Activar()
    {
        animator.SetTrigger("SuperZombieDie");
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Door"))
        {
            Invoke("Activar", 2f);
            Invoke("DesactivarObjeto", 2f);
        }
    }
    
    private void DesactivarObjeto()
    {
        canon.SetActive(false);
    }
}