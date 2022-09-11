using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColider : MonoBehaviour
{
    public static bool isContact = true;
    [SerializeField] Ball ball;
    public GameObject particles;
    public GameObject particlesCoin;

    public Animator animBall;
    private void OnCollisionEnter(Collision other)
    {
        
        if(other.gameObject.tag == "RWall" || other.gameObject.tag == "LWall"){
            string direction = "HORIZONTAL";
            var wall = other.gameObject.GetComponent<Wall>();
            isContact = false;
            ball.Rebound(wall,direction);
            AnimationOn();
        }
        if(other.gameObject.tag == "UPWall" || other.gameObject.tag == "DWall"){
            string direction = "VERTICAL";
            var wall = other.gameObject.GetComponent<Wall>();
            isContact = false;
            ball.Rebound(wall,direction);
            AnimationOn();
        }
        if(other.gameObject.tag == "Coin"){
            Destroy(other.gameObject);
            Score.ScoreCount++;
            GameObject partCoin = Instantiate(particlesCoin, this.transform.position, Quaternion.identity);
            Destroy(partCoin, 1.1f);
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
    void AnimationOn(){
        animBall.SetBool("isTouched", true);
            StartCoroutine(AnimationOff());
            GameObject partGO = Instantiate(particles, this.transform.position, Quaternion.identity);
            Destroy(partGO, 1.1f);
    }
    IEnumerator AnimationOff(){
        yield return new WaitForSeconds(0.2f);
        animBall.SetBool("isTouched", false);
    }

    
    
}
