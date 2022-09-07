using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject ball1;
    public GameObject ball2;
    public Trajectory trajectory;
    public GameObject trajectoryGO;
    int a = 0;
    Vector3 pos1;
    Vector3 pos2;
    Vector3 pos;
    public static Vector3 posa;
    bool shoot;
    bool rebound;
    
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
            ball1.transform.position = Vector3.Lerp(ball1.transform.position, posa, 2f * Time.deltaTime);
            ball2.transform.position = Vector3.Lerp(ball2.transform.position, posa, 2f * Time.deltaTime);
            
        }
    }

    private void FixedUpdate()
    {
        
    }

    void Control(){
            if(Input.GetMouseButton(0)){
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                shoot = false;
                BallColider.isContact= true;
                // if(a == 0){
                //     a =1;
                //     RaycastHit hit;
                //     if(Physics.Raycast(ray, out hit)){
                //         ball1.transform.position = new Vector3(hit.point.x, -2.54f, hit.point.z);  
                //     }
                // }

                    RaycastHit hit1;
                    if(Physics.Raycast(ray, out hit1)){
                        ball2.transform.position = new Vector3(hit1.point.x, -2.54f, hit1.point.z);
                    }
                trajectoryGO.SetActive(true);
                pos1 = ball1.transform.position;
                ShootTrajectory();

            }

            if(Input.GetMouseButtonUp(0)){
                a = 0;
                shoot = true;
                
               
            }
    }
    private void ShootTrajectory(){
        float posX= ball1.transform.position.x - ball2.transform.position.x;
        float posZ =  ball1.transform.position.z - ball2.transform.position.z;
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

    public Vector3 Rebound(Vector3 pos2){
        rebound = true;
        float x = pos2.x - pos1.x;
        float z = (pos1.z)-((pos1.z)-(pos2.z));
        Debug.Log($"{x} + {z}");
        posa = new Vector3(x, ball1.transform.position.y, z);
        
        return posa;
        
        
    }
}
