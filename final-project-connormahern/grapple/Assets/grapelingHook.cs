using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=DTFgQIs5iMY

public class grapelingHook : MonoBehaviour
{
    public LineRenderer line;
    DistanceJoint2D joint;
    Vector3 tragetPos;
    RaycastHit2D hit;
    public float distance = 10f;
    public LayerMask mask;
    public float step = .001f;


    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        line.enabled = false;
    }

    
    void Update()
    {
    
    if(joint.distance > .1f ){
         joint.distance -= step;
    } else {
        line.enabled = false;
        joint.enabled = false;
    }
       



        if(Input.GetKeyDown(KeyCode.Space))
        {
            tragetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tragetPos.z = 0;

            hit = Physics2D.Raycast(transform.position, tragetPos - transform.position, distance, mask);

            if(hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                joint.enabled = true;
                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.connectedAnchor = hit.point - new Vector2(hit.collider.transform.position.x , hit.collider.transform.position.y);
                joint.distance = Vector2.Distance(transform.position , hit.point);

                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point);
            }

        }

        if (Input.GetKey (KeyCode.Space))
        {
            line.SetPosition(0, transform.position);
        }

        if(Input.GetKeyUp(KeyCode.Space)){
            joint.enabled = false;
            line.enabled = false;
        }
        
    }
}
