using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCSVParser : MonoBehaviour
{
    public TextAsset csvFile;

    // Start is called before the first frame update
    void Start()
    {
        Parse();
    }

    void Parse()
    {
        string[] lines = csvFile.text.Split('\n');
        foreach (string line in lines)
        {
            string[] values = line.Split(',');
            Debug.Log(line);
        }

    }
}
