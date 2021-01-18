using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    private float speed = .002f;
    public GameObject player;
    public Vector3 offest = new Vector3(0,0,-1);
    public Vector2 min;
    public Vector2 max;
    public bool resetB = false;


    void Start()
    {
        transform.position = new Vector3(player.transform.position.x + .7f, player.transform.position.y + .75f, -10);
    }

    // Update is called once per frame
    void Update()
    {   
        if(player){
            transform.position = new Vector3(transform.position.x + speed, Mathf.Clamp(player.transform.position.y, .85f , 100) , transform.position.z);
        }
        
        
    }

    public void increaseSpeed(){
        speed = speed + .001f;
    }
}
