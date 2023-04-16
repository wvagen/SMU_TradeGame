using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public TrailRenderer myTrail;
    public SpriteRenderer mySprite;
    public PointsManager pointsMan;

    Color matCol;
    private void Start()
    {
        matCol = myTrail.material.color;
    }

    public void SetMe(PointsManager pointsMan)
    {
        this.pointsMan = pointsMan;
    }

    private void Update()
    {
        myTrail.startWidth = pointsMan.currentPointsTrailWidth;
        myTrail.endWidth = pointsMan.currentPointsTrailWidth;
        matCol.a = pointsMan.alphaColor;
        myTrail.material.color = matCol;
        mySprite.color = matCol;
    }
}
