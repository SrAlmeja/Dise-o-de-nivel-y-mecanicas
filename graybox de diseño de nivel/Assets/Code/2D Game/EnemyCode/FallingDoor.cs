using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDoor : MonoBehaviour
{
    public Animator animator;

    public void Activar()
    {
        animator.SetTrigger("FallingDoor");
    }
}

