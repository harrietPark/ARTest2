using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawline : MonoBehaviour
{
    private Vector3 hi = new Vector3(0, 3, 0);
    // Start is called before the first frame update
    void Start()
    {
        Debug.DrawLine(this.transform.position, this.transform.position + this.transform.right, Color.white, 10, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
