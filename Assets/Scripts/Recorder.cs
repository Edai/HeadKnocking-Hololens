using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Recorder : Singleton<Recorder>
{
    private Camera main;

    private List<string> cameraData;
    private bool recording = false;

    void Start () {
        main = Camera.main;
        cameraData = new List<string>(500);
    }

    public void Launch()
    {
        recording = true;
    }

    public void Stop()
    {
        recording = false;
    }

    public void SaveFile()
    {
        string destination = Application.persistentDataPath + UserManager.Instance.user + ".csv";
        Debug.Log("File created : " + destination);
        using (TextWriter writer = File.CreateText(destination))
        {
            writer.WriteLine(String.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                UserManager.Instance.user.name,  UserManager.Instance.user.age,  UserManager.Instance.user.gender,  UserManager.Instance.user.height,  UserManager.Instance.user.laterality.ToString(),  UserManager.Instance.user.HaveYouEverTriedHololens.ToString()).ToLower());
            foreach (var s in cameraData)
                writer.WriteLine(s);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (recording == true)
        {
            cameraData.Add(String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}", 
                            main.transform.position.x, main.transform.position.y, main.transform.position.z,
                            main.transform.rotation.eulerAngles.x, main.transform.rotation.eulerAngles.y, main.transform.rotation.eulerAngles.z,
                            main.transform.forward.x, main.transform.forward.y, main.transform.forward.z));
        }
    }
}
