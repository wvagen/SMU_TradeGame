using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public TrailRenderer myTrail;
    public PointsManager pointsMan;

    

    public void SetMe(PointsManager pointsMan)
    {
        this.pointsMan = pointsMan;
    }

    private void Update()
    {
        myTrail.startWidth = pointsMan.currentPointsTrailWidth;
        myTrail.endWidth = pointsMan.currentPointsTrailWidth;
    }
}
