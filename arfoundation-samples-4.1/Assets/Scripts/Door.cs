using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Door : Interactable
{
    public Animator animator;

    public GameObject instruction;
    public GameObject twinkleParticle;
    public GameObject closeDoor;
    public GameObject openDoor;
    
    public override void OnTouch()
    {
        Debug.Log("Door touched");
        animator.SetTrigger("isOpen");
        StartCoroutine(Instruction());
        
    }

    private IEnumerator Instruction()
    {
        yield return new WaitForSeconds(7f);
        closeDoor.SetActive(true);
        openDoor.SetActive(false);
        yield return new WaitForSeconds(3.5f);
        instruction.SetActive(true);

    }

    public void TouchCloseBtn()
    {
        Destroy(instruction);
        twinkleParticle.SetActive(true);
    }
}
