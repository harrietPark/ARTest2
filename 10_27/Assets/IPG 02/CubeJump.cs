using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJump : MonoBehaviour
{
    public Rigidbody RB;
    [Range(0,100)]
    public float Force = 10f;

    void OnMouseDown()
    {
        RB.AddForce(Vector3.up * Force, ForceMode.Impulse);
    }
}
