using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    //public string Text;
    public Door Door;

    public bool PlayerInTrigger = false;

    void Update()
    {
        if (PlayerInTrigger &&
            Input.GetKeyDown(KeyCode.E))
        {
            Door.gameObject.SetActive(false); // open the door
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInTrigger = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInTrigger = false;
        }
    }
}
