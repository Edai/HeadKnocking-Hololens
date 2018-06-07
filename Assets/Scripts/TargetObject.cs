using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class TargetObject : MonoBehaviour, IInputClickHandler
{
  
    public enum TargetType : int
    {
        Click = 1,
        Pass = 2,
        Dwell = 3
    };

    [SerializeField]
    TargetType type = TargetType.Click;

    [SerializeField]
    private Renderer mainCircle;

    [SerializeField]
    private Renderer smallCircle;

    void ChangeType(TargetType t)
    {
       type = t;
       switch (type)
        {
            case TargetType.Click:
                mainCircle.material.color = Color.red;
                smallCircle.material.color = Color.red;
                break;
            case TargetType.Pass:
                mainCircle.material.color = Color.blue;
                smallCircle.material.color = Color.blue;
                break;
            case TargetType.Dwell:
                mainCircle.material.color = Color.green;
                smallCircle.material.color = Color.green;
                break;
        }
    }

    // Use this for initialization
    void Start()
    {
        ChangeType(type);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("CLICK");
    }
}