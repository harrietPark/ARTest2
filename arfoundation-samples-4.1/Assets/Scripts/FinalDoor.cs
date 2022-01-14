using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : Interactable
{
    public Animator DoorAnim;
    public Animator batAnim;
    public GameObject batParticle;
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
    }
}
