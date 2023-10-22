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
        string path = Application.dataPath + "/SaveData.csv";
        // Debug.Log(path);
        sw = new StreamWriter(path, isAdd, Encoding.UTF8);
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
        if (sw != null)
        {
            sw.WriteLine(s2);
        }
        startTime = Time.time;
    }

    public void StopwatchStart(bool isAdd)
    {
        InitCSV(isAdd);

        startTime = Time.time;
        Debug.Log("ŠJŽn");
    }

    //    public void StopwatchStop(bool Close)
    public void StopwatchStop()
    {
        // InitCSV(true);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    private void OnApplicationQuit()
    {
        sw.Close();
        Debug.Log("•Â‚¶‚é");
    }
}
