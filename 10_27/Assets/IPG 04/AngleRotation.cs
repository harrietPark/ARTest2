using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleRotation : MonoBehaviour
{
    public Transform A;
    public Transform B;

    [Range(0,1)]
    public float t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(A.rotation, B.rotation, t);
    }
}
