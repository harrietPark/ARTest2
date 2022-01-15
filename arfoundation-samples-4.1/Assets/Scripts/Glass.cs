using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : Interactable
{
    public GameObject glassParticle;
    public GameObject glassEffect;
    public GameObject broomParticle;
    public GameObject glass;
    public Animator shelfAnim;
    public override void OnTouch()
    {
        Debug.Log("glass touched");
        glassParticle.SetActive(true);
        //glassParticle.GetComponentInChildren<ParticleSystem>().Play();
        
        StartCoroutine(GlassEffect());
    }

    private IEnumerator GlassEffect()
    {
        yield return new WaitForSeconds(0.5f);
        glass.SetActive(false);
        yield return new WaitForSeconds(0.6f);
        shelfAnim.SetBool("isClosed", true);
        yield return new WaitForSeconds(1.6f);
        glassEffect.SetActive(true);
        yield return new WaitForSeconds(1.6f);
        broomParticle.SetActive(true);
    }
}
