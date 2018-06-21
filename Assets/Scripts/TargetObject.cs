using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class TargetObject : MonoBehaviour, IInputClickHandler
{
    private int targetType;
    private GameObject controller;

    [SerializeField]
    private Renderer mainCircle;

    [SerializeField]
    private Renderer smallCircle;

    private TargetManager study;

    private bool isHeadClicking;

    private Color c;

    private Vector3[] headpos;
    private Vector3[] headforwards;
    private int record_length = 120;
    private int timer_count = 0;
    private int durationPass = 20;
    private int durationDwell = 90;
    private bool timeout = false;

    void Start()
    {
        study = GameObject.FindObjectOfType<TargetManager>();
        c = mainCircle.material.color;
        isHeadClicking = true;
        if (isHeadClicking == false)
        {
// Recorder.Instance.Launch();
        }
    }

    private void Update()
    {
        //timer event
        if (timer_count > 0)
        {
            timer_count--;
            if (timer_count == 0)
            {
                timeout = true;
                mainCircle.material.color = Color.black;
            }
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        //Recorder.Instance.Stop();
        //Recorder.Instance.SaveFile();
        //TargetRecorder.Instance.Stop();
        //TargetRecorder.Instance.SaveFile();
        Debug.Log("click");
        transform.gameObject.SetActive(false);
    }

    public void ActionStart()
    {
        if (isHeadClicking == true)
        {
            //Recorder.Instance.Launch();
            //TargetRecorder.Instance.Launch();
        }
    }

    public void ActionEnd()
    {
        bool islegal = true;
        if (isHeadClicking)
        {
            //islegal = Recorder.Instance.isNod ();
            islegal = true;
        }
        if (islegal)
        {
            //Recorder.Instance.SaveFile();
            //TargetRecorder.Instance.SaveFile();
            transform.parent.gameObject.SetActive(false);
        }
        //Debug.Log(islegal);
        //Recorder.Instance.Stop();
        //TargetRecorder.Instance.Stop();
    }

    public void OnPress()
    {
        /*
        Debug.Log("Press");
		if (isHeadClicking == true) {
			Recorder.Instance.Launch ();

		}*/
    }

    public void OnRelease()
    {
        /*
		bool islegal = true;
		if (isHeadClicking) {
            //islegal = Recorder.Instance.isNod ();
            islegal = true;
		}
		if (islegal) {
			Recorder.Instance.SaveFile();
			TargetRecorder.Instance.SaveFile();
			transform.parent.gameObject.SetActive(false);
		}
		Debug.Log (islegal);
		Recorder.Instance.Stop();
	    TargetRecorder.Instance.Stop();
	    */

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == TaskManager.Instance.Cursor)
        {  
            //TargetRecorder.Instance.Enter();
            mainCircle.material.color = mainCircle.material.color / 1.2f + new Color(0, 0, 0, 0.5f);
            if (targetType == (int)TargetManager.targetType.Pass)
            {
                timer_count = durationDwell;
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        mainCircle.material.color = c;
       // TargetRecorder.Instance.Leave();
        //timeout for pass and dwell
        if (timeout == true || targetType == (int)TargetManager.targetType.Dwell)
        {
            //Recorder.Instance.SaveFile();
            //TargetRecorder.Instance.SaveFile();
            transform.gameObject.SetActive(false);
            timeout = false;
        }
    }

    public void ChangeType(int t)
    {
        targetType = t;
        switch (t)
        {
            case (int)TargetManager.targetType.Click:
                mainCircle.material.color = Color.red;
                smallCircle.material.color = Color.red;
                break;
            case (int)TargetManager.targetType.Pass:
                mainCircle.material.color = Color.blue;
                smallCircle.material.color = Color.blue;
                break;
            case (int)TargetManager.targetType.Dwell:
                mainCircle.material.color = Color.green;
                smallCircle.material.color = Color.green;
                break;
        }
    }
}