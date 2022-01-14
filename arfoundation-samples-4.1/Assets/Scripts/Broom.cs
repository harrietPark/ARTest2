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
            glassCanvas.SetActive(false);
            broomParticle.SetActive(false);
            StartCoroutine(ActiveGoblinBat());
        }
        
    }

    private IEnumerator ActiveGoblinBat()
    {
        yield return new WaitForSeconds(0.9f);
        broomDisappearParticle.SetActive(true);
        broomDisappearParticle.GetComponentInChildren<ParticleSystem>().Play();
        //yield return new WaitForSeconds(0.5f);
        Destroy(broomDisappearParticle);
        yield return new WaitForSeconds(0.5f);
        broom.SetActive(false);
        StartCoroutine(ActiveGoblinBat());
        yield return new WaitForSeconds(1.3f);
        goblinBat.SetActive(true);
        goblinLetter.SetActive(true);
        isTouched = false;
    }
}
