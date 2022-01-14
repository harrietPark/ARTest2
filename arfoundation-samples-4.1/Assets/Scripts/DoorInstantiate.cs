using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DoorInstantiate : MonoBehaviour
{
    public GameObject door;
    public Animator doorAnimator;
    private ARPlaneManager arPlaneManager;
    private ARTapToPlaceObject tapToPlaceObject;

    private Vector3 openedScale = new Vector3(100, 100, 100);
    private Vector3 closedScale = new Vector3(100, 0, 100);

    public bool isInstantiated = false;
    public float T = 0;
    public float decayPerSecond;

    private void Awake()
    {
        arPlaneManager = FindObjectOfType<ARPlaneManager>();
        tapToPlaceObject = FindObjectOfType<ARTapToPlaceObject>();
    }
    void Update()
    {
        T += decayPerSecond * Time.deltaTime;
        T = Mathf.Clamp01(T);
        door.transform.localScale = Vector3.Lerp(closedScale, openedScale, T);
        if (T >= 1) isInstantiated = true;

        if (isInstantiated)
        {
            doorAnimator.enabled = true;
            arPlaneManager.enabled = false;
            arPlaneManager.planePrefab.SetActive(false);
            tapToPlaceObject.enabled = false;
            
        }
    }

}
