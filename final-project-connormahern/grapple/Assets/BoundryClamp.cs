using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoundryClamp : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, .82f, 3.37f), transform.position.z);
        
    }
}
