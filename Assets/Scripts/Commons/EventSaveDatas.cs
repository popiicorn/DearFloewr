using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
public class EventSaveDatas : MonoBehaviour
{
    private StreamWriter sw;

    float startTime;

    public static EventSaveDatas Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    void InitCSV(bool isAdd)
    {
        // string path = Application.persistentDataPath + "/SaveData.csv";
        // string path = @"SaveData.csv";
        string path = Application.dataPath + "/SaveData.csv";

        Debug.Log(path);
        sw = new StreamWriter(path, isAdd, Encoding.UTF8);
        // string[] s1 = {"Time" };
        // string s2 = string.Join(",", s1);
        // sw.WriteLine(s2);
        Debug.Log("èâä˙âª");
    }

    void SaveData(string txt1, string time)
    {
        string[] s1 = { txt1, time };
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
    }
    public void SaveData(string stageName)
    {
        string[] s1 = { stageName, (Time.time - startTime).ToString("0.0") };
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        startTime = Time.time;
    }

    public void StopwatchStart(bool isAdd)
    {
        InitCSV(isAdd);

        startTime = Time.time;
        Debug.Log("äJén");
    }

    public void StopwatchStop()
    {
        sw.Close();
        InitCSV(true);
    }
}
