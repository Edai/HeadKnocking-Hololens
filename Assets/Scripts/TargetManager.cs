using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : Singleton<TargetManager>
{
    [SerializeField]
    private GameObject target;

    private GameObject currentTarget;

    private void Start()
    {
        currentTarget = Instantiate(target);
        SetTargetPosition();
    }

    private void SetTargetPosition()
    {
        Vector3 playerPos = Camera.main.transform.position;
        Vector3 playerDirection = Camera.main.transform.forward;
        Quaternion playerRotation = Camera.main.transform.rotation;
        float spawnDistance = 1.5f;

        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

        currentTarget.transform.position = spawnPos;
        currentTarget.transform.LookAt(playerPos);
    }
}
