using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColider : MonoBehaviour
{
    public static bool isContact = true;
    [SerializeField] Ball ball;

    public Animator animBall;
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Wall"){
            isContact = false;
            Vector3 pos2 = this.transform.position;
            ball.Rebound(pos2);
            animBall.SetBool("isTouched", true);
            StartCoroutine(AnimationOff());
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "Wall"){
            isContact = false;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Wall"){
            isContact = true;
            
        }
    }
    IEnumerator AnimationOff(){
        yield return new WaitForSeconds(0.2f);
        animBall.SetBool("isTouched", false);
    }

    
    
}
