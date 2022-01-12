using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInstantiate : MonoBehaviour
{
    public GameObject door;
    private Vector3 openedScale = new Vector3(100, 100, 100);
    private Vector3 closedScale = new Vector3(100, 0, 100);

    public float T = 0;
    public float decayPerSecond;
    void Update()
    {
        T += decayPerSecond * Time.deltaTime;
        T = Mathf.Clamp01(T);
        door.transform.localScale = Vector3.Lerp(closedScale, openedScale, T);
    }
}
