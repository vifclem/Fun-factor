using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public Vector3 playerPosition;

    public static PlayerData Instance;
    private void Awake()
    {
        Instance = this;

    }

    public void GoTo(Vector3 position)
    {

        playerPosition = position;
        GetComponent<Rigidbody>().MovePosition(playerPosition);
    }

    private void Update()
    {
        Debug.Log(playerPosition);
        playerPosition = transform.position;
    }
}
