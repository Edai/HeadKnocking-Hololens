using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : Singleton<UserManager>
{
    [SerializeField]
    private User _user;
    public User user
    {
        get
        {
            return _user;
        }
    }

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
        _user = new User();
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