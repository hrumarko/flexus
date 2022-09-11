using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public static Vector3 p;
    public GameObject go;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        p = transform.forward;
        //Debug.Log(p);
        
        
        Debug.DrawLine(transform.position,p*100);
    }

    public Vector3 PositionRebound(Vector3 pos, string direction){
        switch(direction){
            case "VERTICAL":
                go.transform.position = pos;
                go.transform.localPosition = new Vector3((go.transform.localPosition.x),go.transform.localPosition.y,-go.transform.localPosition.z);
                // return go.transform.position;
                break;
            case "HORIZONTAL":
                go.transform.position = pos;
                go.transform.localPosition = new Vector3((-go.transform.localPosition.x),go.transform.localPosition.y,go.transform.localPosition.z);
                // return go.transform.position;
                break;
        }

        return go.transform.position;
    }
}
