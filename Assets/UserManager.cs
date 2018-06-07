using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour
{
	// Use this for initialization
	void Start () {
        LoadUserFromFile();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
    }

    void LoadUserFromFile()
    {
        //TODO
    }
}

public class User
{
    [SerializeField] public string name = "Mike";
    [SerializeField] public int age = 20;
    [SerializeField] public int height = 175;
    [SerializeField] public Gender gender = Gender.MALE;
    [SerializeField] public Laterality laterality = Laterality.RIGHT_HANDED;
    [SerializeField] public bool HaveYouEverTriedHololens = true;
}

public enum Gender
{
    FEMALE,
    MALE
}

public enum Laterality
{
    RIGHT_HANDED,
    LEFT_HANDED,
    AMBIDEXTROUS
}