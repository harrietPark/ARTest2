using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : Interactable
{
    public GameObject broomParticle;
    public GameObject broomDisappearParticle;
    public GameObject broom;
    public GameObject goblinBat;
    public GameObject goblinLetter;
    public GameObject glassCanvas;
    private bool isTouched = false;

    public override void OnTouch()
    {
        isTouched = true;
        if (isTouched)
        {
            
            
            StartCoroutine(ActiveGoblinBat());
        }
        
    }

    private IEnumerator ActiveGoblinBat()
    {
        yield return new WaitForSeconds(0.5f);
        glassCanvas.SetActive(false);
        broomParticle.SetActive(false);
        broomDisappearParticle.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        broom.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        goblinBat.SetActive(true);
        goblinLetter.SetActive(true);
        isTouched = false;
    }
}
