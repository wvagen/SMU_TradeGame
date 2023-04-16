using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public List<Vector2> pointsPoses;
    public GameObject point;
    public TextAsset csvFile;

    public bool isTesting = false;

    public float currentPointsTrailWidth = initTrailWidth;
    public float alphaColor = 0.5f;
    public int currentPrice = 0;

    List<Point> spawnedPoints = new List<Point>();
    List<string> alerts = new List<string>();

    public Point currentPoint;

    int pointsPosIndex = 0;

    MyGameManager myGameMan;
    const float initTrailWidth = 0.07f;

    bool isMoving = false;

    public void Set_Me(MyGameManager myGameMan)
    {
        this.myGameMan = myGameMan;
    }

    private void Awake()
    {
        Test_Points();
        ParseCSV();
    }


    void ParseCSV()
    {
        string[] lines = csvFile.text.Split('\n');

            string[] values = lines[0].Split(',');
                for (int count = 0; count < values[0].Split(';').Length; count++)
                {
                    pointsPoses.Add(new Vector2(float.Parse(values[0].Split(';')[count].ToString()) * 1.655f, 0));
                 }

         values = lines[1].Split(',');
        for (int count = 0; count < values[0].Split(';').Length; count++)
        {
            pointsPoses[count] = new Vector2(pointsPoses[count].x, float.Parse(values[0].Split(';')[count].ToString()) / 10000);
        }

        values = lines[2].Split(',');
        for (int count = 0; count < values[0].Split(';').Length; count++)
        {
            alerts.Add(values[0].Split(';')[count].ToString());
        }

        // Debug.Log(lines[i]);

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
        alphaColor = 1;

    }

    public void Unselect_Me()
    {
        currentPointsTrailWidth = initTrailWidth;
        alphaColor = 0.5f;
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
        //float distance = Vector3.Distance(currentPoint.transform.position, pointsPoses[pointsPosIndex]);
       // currentPoint.transform.position = Vector3.MoveTowards(currentPoint.transform.position, pointsPoses[pointsPosIndex], (distance / 1) * Time.deltaTime);

        if (!isMoving)
        {
            if (!string.IsNullOrEmpty(alerts[pointsPosIndex - 1]))
            myGameMan.Display_Alert(alerts[pointsPosIndex - 1]);
            else
            myGameMan.Hide_Alert();

            StartCoroutine(MoveToPos(pointsPoses[pointsPosIndex]));
        }

        currentPrice = (int) (currentPoint.transform.position.y * 100);
    }

    IEnumerator MoveToPos(Vector3 endPos)
    {
        isMoving = true;
        Vector3 startPos = currentPoint.transform.position;
        float t = 0f;
        while (t < myGameMan.pointsSpeed)
        {
            currentPoint.transform.position = Vector3.Lerp(startPos, endPos, t/ myGameMan.pointsSpeed);
            t += Time.deltaTime;
            yield return null;
        }
        isMoving = false;
    }

}
