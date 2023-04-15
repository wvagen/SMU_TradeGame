using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public MyGameManager gameMan;
    public List<Vector2> pointsPoses;
    public GameObject point;

    GameObject currentPoint;

    int pointsPosIndex = 0;

    private void Start()
    {
        Test_Points();
    }

    void Test_Points()
    {
        for (int i = 0; i < pointsPoses.Count; i++)
        {
            GameObject tempPoint = Instantiate(point, pointsPoses[i], Quaternion.identity, transform);
            tempPoint.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }

    void Spawn_Next_Point()
    {
        currentPoint = Instantiate(point, pointsPoses[pointsPosIndex], Quaternion.identity, transform);
        pointsPosIndex++;
    }


    void Update()
    {
        Play_Behavior();
    }

    void Play_Behavior()
    {
        if (gameMan.canPlay)
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
        currentPoint.transform.position = Vector2.MoveTowards(currentPoint.transform.position, pointsPoses[pointsPosIndex], Time.deltaTime * gameMan.gameSpeed);
    }
}
