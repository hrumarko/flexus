using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        
    }

    public void ShowTrajectory(Vector3 pos, Vector3 pos2){
        Vector3[] points = new Vector3[2];
        _lineRenderer.positionCount = points.Length;
        points[0] = pos;
        points[1]= pos2;
        _lineRenderer.SetPositions(points);
    }
}
