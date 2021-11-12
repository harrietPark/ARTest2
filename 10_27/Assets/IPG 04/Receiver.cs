using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour
{
    [Header("Color")]
    public MeshRenderer renderer;
    [ColorUsage(false,true)]
    public Color ColorOff;

    //don't show alpha, HDR color
    [ColorUsage(false, true)]
    public Color ColorOn;

    [Range(0,1)]
    public float T = 0;

    [Range(0,1)]
    public float decayPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //every seconds, T decreases by decayPerSecond
        T -= decayPerSecond * Time.deltaTime;
        T = Mathf.Clamp01(T);

        Color color = Color.Lerp(ColorOff, ColorOn, T);
        renderer.material.SetColor("_EmissionColor", color);
    }

    //t : amount of energy I give to the sphere
    public void Power(float t)
    {
        T += t;
        T = Mathf.Clamp01(T); //clamp it to 0-1(saturate)

        //T : 0 -> ColorOff
        //T : 1 -> ColorOn
    
    }
}
