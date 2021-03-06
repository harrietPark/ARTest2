using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : Interactable
{
    public Animator DoorAnim;
    public Animator batAnim;
    public GameObject batParticle;
    public GameObject bat;
    public GameObject batInstruction;
  
    public override void OnTouch()
    {
        if (GoblinBat.gotBat)
        {
            StartCoroutine(FinalProcess());
        }
        
    }

    private IEnumerator FinalProcess()
    {
        batAnim.SetTrigger("isTouched");
        batParticle.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        DoorAnim.SetTrigger("isOpened");
        batInstruction.SetActive(false);
        StartCoroutine(BatDisapper());
    }
    private IEnumerator BatDisapper()
    {
       
        yield return new WaitForSeconds(1.5f);
        bat.SetActive(false);
    }
}
