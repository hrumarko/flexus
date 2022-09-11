using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject ball;


    private void Update()
    {
        float z = ball.transform.position.z;
        float x = ball.transform.position.x;
        float y = this.transform.position.y;
        Vector3 ballPos = new Vector3(x, y, z-3);
        this.transform.position = Vector3.Lerp(this.transform.position, ballPos, 0.05f);
    }
}
