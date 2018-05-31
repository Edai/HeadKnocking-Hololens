using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class TargetTaskButton : MonoBehaviour, IInputClickHandler
{
    [SerializeField]
    private string name = "TargetTask";

    private void Start()
    {
           
    }

    /// <summary>
    /// Called when a click event is detected
    /// </summary>
    /// <param name="eventData">Information about the click.</param>
    public void OnInputClicked(InputClickedEventData eventData)
    {
        SceneLoader.Instance.ChangeToScene(name);
    }
}
