using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public List<Vector2> pointsPoses;
    public GameObject point;

    public bool isTesting = false;

    public float currentPointsTrailWidth = initTrailWidth;

    List<Point> spawnedPoints = new List<Point>();

    Point currentPoint;

    int pointsPosIndex = 0;

    MyGameManager myGameMan;
    const float initTrailWidth = 0.07f;

    public void Set_Me(MyGameManager myGameMan)
    {
        this.myGameMan = myGameMan;
    }

    private void Awake()
    {
        Test_Points();
    }

    void Test_Points()
    {
        if (isTesting)
        {
            for(int i = 0; i < 5; i++)
            {
                pointsPoses.Add(new Vector2(Random.Range(i + 0f,i + 1f), Random.Range(i + 0f, i + 1f)));
            }

           /* for (int i = 0; i < pointsPoses.Count; i++)
            {

                GameObject tempPoint = Instantiate(point, pointsPoses[i], Quaternion.identity, transform);
                tempPoint.GetComponent<SpriteRenderer>().color = Color.black;
            }*/
        }

    }

    public void Select_Me()
    {
        currentPointsTrailWidth = initTrailWidth * 1.5f;

    }

    public void Unselect_Me()
    {
        currentPointsTrailWidth = initTrailWidth;
    }

    void Spawn_Next_Point()
    {
        currentPoint = Instantiate(point, pointsPoses[pointsPosIndex], Quaternion.identity, transform).GetComponent<Point>();
        spawnedPoints.Add(currentPoint);
        currentPoint.SetMe(this);
        pointsPosIndex++;
    }


    void Update()
    {
        Play_Behavior();
    }

    void Play_Behavior()
    {
        if (myGameMan.canPlay)
        {
            if (pointsPosIndex == 0 || (pointsPosIndex < pointsPoses.Count && Vector2.Distance(currentPoint.transform.position, pointsPoses[pointsPosIndex]) < 0.01f ))
            {
                Spawn_Next_Point();
            }
            else if (pointsPosIndex < pointsPoses.Count)
            {
                Follow_Next_Point();
            }
        }
    }

    void Follow_Next_Point()
    {
        currentPoint.transform.position = Vector2.MoveTowards(currentPoint.transform.position, pointsPoses[pointsPosIndex], Time.deltaTime * myGameMan.gameSpeed);
    }
}
