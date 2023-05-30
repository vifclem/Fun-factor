using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[Serializable]
public class SaveData
{
    public WorldData worldData;
  
    [NonSerialized]public PointDisplay pointDisplay;
   
    public int score;
    public int scoreIn;

    public void Load()
    {
      
        if (PointDisplay.instance != null)
        {
            pointDisplay = PointDisplay.instance;
            pointDisplay.score = score;
            pointDisplay.scoreIn = scoreIn;
            pointDisplay.UpdateDisplay();
            
        }
    }

    public void Save()
    {
       
        if (PointDisplay.instance != null)
        {
            pointDisplay = PointDisplay.instance;
            score = pointDisplay.score;
            scoreIn = pointDisplay.scoreIn;
        }
    }

    public void NewScene()
    {
        pointDisplay.score = 0;
        pointDisplay.scoreIn = 0;
        pointDisplay.UpdateDisplay();

    }




}