using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WorldData
{
    public static WorldData instance;

    public int score = 0;
    public int scoreIn = 0;
    //int nombre de cub detruit ou encore en vie


    public void NewWorldData(int Newscore, int NewscoreIn)
    {

    }
}