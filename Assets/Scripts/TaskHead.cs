using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TaskHead : MonoBehaviour
{
    [SerializeField]
    private string name = "Task";

    public string Name
    {
        get { return name; }
    }

    [SerializeField]
    public bool replayLastRecord = false;
}