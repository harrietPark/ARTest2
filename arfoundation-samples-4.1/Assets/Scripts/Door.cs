using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Door : Interactable
{
    public Animator animator;
    private bool isAnimated = false;

    public GameObject instruction;
    public GameObject twinkleParticle;
    
    public override void OnTouch()
    {
        Debug.Log("Door touched");
        animator.SetTrigger("isOpen");
        isAnimated = true;
        StartCoroutine(Instruction());
    }

    private IEnumerator Instruction()
    {
        yield return new WaitForSeconds(6.5f);
        instruction.SetActive(true);
    }

    public void TouchCloseBtn()
    {
        instruction.SetActive(false);
        twinkleParticle.SetActive(true);
    }
}
