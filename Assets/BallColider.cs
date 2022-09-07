using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColider : MonoBehaviour
{
    public static bool isContact = true;
    [SerializeField] Ball ball;


    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Wall"){
            isContact = false;
            Vector3 pos2 = this.transform.position;
            Ball.posa =ball.Rebound(pos2);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "Wall"){
            isContact = false;
        }
    }

    
    
}
