using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Receiver receiver;
    public GameObject door;
    public Transform positionClose;
    public Transform positionOpen;

    private void Update()
    {
        door.transform.position = Vector3.Lerp(positionClose.position, positionOpen.position, 
            Mathf.InverseLerp(0.5f, 0.75f, receiver.T));

        //receiver.T : [0,        1]
        //door.y :     [close, open]

        //do linear interpolation  btw 0.5~0.75
        //receiver.T : [0,     0.5,     0.75,     1]
        //InverseLerp: [0,     0,       1,        1]
        //door.y :     [close, close,   open,    open]


        /*
        if (receiver.T >= 0.95f)
        {
            door.SetActive(false);
        }
        else if (receiver.T < 0.5)
        {
            door.SetActive(true);
        }
        */
    }
}
