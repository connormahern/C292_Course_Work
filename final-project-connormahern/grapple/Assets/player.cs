using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int lives = 3;
    private int level = 1;
    public bool checkPointRe = false;

    [SerializeField] cameraMovement camera;
    [SerializeField] GameState gs;
    [SerializeField] GameObject checkPoint;
   


    // Start is called before the first frame update
    void Start()
    {
        checkPointRe = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name == "Main Camera"){
            if(lives > 1 && checkPointRe == true){
                transform.position = new Vector3(checkPoint.transform.position.x, checkPoint.transform.position.y, transform.position.z);
                lives -= 1;
                gs.decreaseLives(lives);
                camera.transform.position = new Vector3(checkPoint.transform.position.x, checkPoint.transform.position.y, camera.transform.position.z);
            } else if (lives > 1 && checkPointRe == false){
                transform.position = new Vector3(1.09f, .08f , -1f);
                lives -= 1;
                gs.decreaseLives(lives);
                camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
            } else {
                Destroy(gameObject);
                gs.GameOver();
                gs.decreaseLives(lives);
            }
        }

        if(col.gameObject.name == "LevelComp" && checkPointRe == true){
            gs.showComplete();
            transform.position = new Vector3(1.09f, .08f , -1f);
            level += 1;
            checkPointRe = false;
            camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
            //camera.increaseSpeed();
        }

        if(col.gameObject.name == "CheckPoint1"){
            checkPointRe = true;
            checkPoint = GameObject.Find("CheckPoint1");
        } else if(col.gameObject.name == "CheckPoint2"){
            checkPointRe = true;
            checkPoint = GameObject.Find("CheckPoint2");
        } else if(col.gameObject.name == "CheckPoint3"){
            checkPointRe = true;
            checkPoint = GameObject.Find("CheckPoint3");
        }
        
        
        

    }


    
}
