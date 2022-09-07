using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject ball1;
    // public GameObject ball2;
    Vector3 stretchPos;
    public Trajectory trajectory;
    public GameObject trajectoryGO;
    int a = 0;
    Vector3 pos1;
    Vector3 finishPos;
    Vector3 pos;
    
    bool shoot;
    bool rebound;
    Vector3 p;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Control();
        if(shoot){
            Shoot();
        }

        if(rebound){
            ball1.transform.position = Vector3.Lerp(ball1.transform.position, finishPos, 2f * Time.deltaTime);
        }
    }

   
    void Control(){
            if(Input.GetMouseButton(0)){
                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                shoot = false;
                rebound = false;
                BallColider.isContact= true;
                if(a == 0){
                    a =1;
                    pos1 = ball1.transform.position;
                    RaycastHit hit;
                    if(Physics.Raycast(ray, out hit)){
                        p = new Vector3(hit.point.x, -2.54f, hit.point.z);  
                    }
                }

                    RaycastHit hit1;
                    if(Physics.Raycast(ray, out hit1)){
                       stretchPos = new Vector3(hit1.point.x, -2.54f, hit1.point.z);
                    }
                trajectoryGO.SetActive(true);
                
                ShootTrajectory();

            }

            if(Input.GetMouseButtonUp(0)){
                a = 0;
                shoot = true;
                
               
            }
    }
    private void ShootTrajectory(){
        float posX= p.x - stretchPos.x;
        float posZ =  p.z - stretchPos.z;
        pos = new Vector3(posX, -2.52f, posZ);
        Vector3 posFT = new Vector3(posX, 0,posZ);
        pos = new Vector3(posX, -2.52f, posZ);
        pos += new Vector3(ball1.transform.position.x, 0 , ball1.transform.position.z);
        float scale = Mathf.Abs(pos.x * pos.z);
        trajectory.ShowTrajectory(ball1.transform.position, pos);
        
    }

    public void Shoot(){
        if(!BallColider.isContact) shoot = false;
        ball1.transform.position = Vector3.Lerp(ball1.transform.position, pos, 2f * Time.deltaTime);        
        trajectoryGO.SetActive(false);
    }
    public void Rebound(Vector3 secondPos){        
        Vector3 vector = secondPos - pos1;
        vector = new Vector3(-vector.x, vector.y, -vector.z);        
        finishPos = new Vector3((vector.x + secondPos.x), -2.52f, (secondPos.z - vector.z));        
        rebound = true;
        
    }

    
}
