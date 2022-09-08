using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public static float y;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float y = this.transform.localEulerAngles.y;
        if(y > 180){
            y -=360;
        }
        
        Debug.Log("rot  "+y);
        
    }
}
