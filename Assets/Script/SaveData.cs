using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class SaveData
{
    public WorldData worldData;
    public PlayerData playerData;
    public Vector3 playerPose;

    public void Load()
    {
        if (PlayerData.Instance != null)
        {
            playerData = PlayerData.Instance;
            worldData = WorldData.instance;
            PlayerData.Instance.GoTo(playerPose);
        }
    }

    public void Save()
    {
        if (PlayerData.Instance != null)
        {
            playerPose = playerData.playerPosition;


        }
    }




}