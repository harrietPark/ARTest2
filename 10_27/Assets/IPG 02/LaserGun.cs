using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LaserGun : MonoBehaviour
{
    public Transform FirePoint;
    [Range(0,100)]
    public float MaxDistance = 100; // m

    public LayerMask Layer;

    public Camera Camera;
   // public CinemachineImpulseSource Impulse;
    public LineRenderer Line;

    [Header("Sound")]
    public AudioSource audioSource;

    public Transform gunObject;

    [Header("Power")]
    [Range(0,1)]
    public float PowerPerSecond;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            audioSource.Play();
            //Impulse.GenerateImpulse();

            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            Vector3 hitPoint;
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, MaxDistance, Layer))
            {
                hitPoint = hitInfo.point;

                //this is the point where we hit sth
                Receiver receiver = hitInfo.collider.GetComponent<Receiver>();
                if (receiver!= null)
                {
                    //I know the laser has hit a receiver sphere
                    //receiver.Power(0.001f); //frameRate dependent
                    receiver.Power(PowerPerSecond * Time.deltaTime); //frameRate independent
                }
            }
            else
            {
                hitPoint = ray.origin + MaxDistance * ray.direction;
            }

       
            gunObject.LookAt(hitPoint);
          

            Line.SetPosition(0, FirePoint.position);
            Line.SetPosition(1, (FirePoint.position + hitPoint)/2f  + Random.insideUnitSphere * 0.01f);
            Line.SetPosition(2, hitPoint);
            Line.enabled = true;
        }
        else
        {
            audioSource.Pause();
            Line.enabled = false;
        }
    }
}
