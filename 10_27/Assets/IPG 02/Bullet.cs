using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public Rigidbody RB;
    [Range(0,100)]
    public float Speed = 10f; // m/s

  

    void Start()
    {
        RB.velocity = transform.forward * Speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }
}
