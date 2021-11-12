using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Gun : MonoBehaviour
{
    public Bullet BulletPrefab;
    public Transform FirePoint;
    public Camera camera;

    [Header("Reload")]
    [Range(0,5)]
    public float ReloadTime = 1f; // seconds
    private float ReloadTimer = 0; // seconds

    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip shootingClip;
    public AudioClip cockingClip;

    public CinemachineImpulseSource Impulse;

    [Header("Aim")]
    [Range(0,100)]
    public float MaxDistance = 100f;
    public LayerMask layer;

    public Transform gunObject;

    void Update()
    {
        ReloadTimer -= Time.deltaTime;

        //-----------AIMING------------------
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        Vector3 hitPoint;

        if (Physics.Raycast(ray, out hitInfo, MaxDistance, layer))
        {
            hitPoint = hitInfo.point;
        }
        else
        {
            hitPoint = ray.origin + MaxDistance * ray.direction;
        }

 
        gunObject.LookAt(hitPoint);

        

        //------------SHOOTING----------------
        if (Input.GetMouseButtonDown(0))
        {
            

            if (ReloadTimer <=0)
            {
                Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
                ReloadTimer = ReloadTime;

                audioSource.PlayOneShot(shootingClip, 0.5f);
                Impulse.GenerateImpulse();
                
            }
            else
            {
                audioSource.PlayOneShot(cockingClip, 0.5f);
            }
      
        }
    }
}
