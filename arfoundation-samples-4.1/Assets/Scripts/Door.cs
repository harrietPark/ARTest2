using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Door : Interactable
{
    public Animator animator; 
    
    public override void OnTouch()
    {
        Debug.Log("Door touched");
        animator.SetTrigger("isOpen");
    }
}
