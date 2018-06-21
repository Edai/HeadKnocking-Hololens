using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : Singleton<TaskManager>
{
    [SerializeField]
    GameObject cursor;
    
    public GameObject Cursor
    {
        get
        {
            return cursor;
        }
    }
}
