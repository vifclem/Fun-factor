using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


[Serializable]
public class SaveData
{
    public WorldData worldData;
  
    [NonSerialized]public PointDisplay pointDisplay;
    [NonSerialized] public Shooting shooting;
    [NonSerialized] public CubeExplosion cubeExplosion;
    [NonSerialized] public volumeSettings volumSettings;
    public float slider = 1f;
    
   
    public int score;
    public int scoreIn;
    public int bulletCount;
    public Vector3 cubePosition;

  
   
 

    void Start()
    {
       
    }

   
    public void Load()
    {
      
        if (PointDisplay.instance != null)
        {
            pointDisplay = PointDisplay.instance;
            pointDisplay.score = score;
            pointDisplay.scoreIn = scoreIn;
            pointDisplay.UpdateDisplay();
            
        }
        if (Shooting.instance != null)
        {
            shooting = Shooting.instance;
            shooting.bulletsLeft = bulletCount;

        }
        if(CubeExplosion.instance != null)
        {
            cubeExplosion = CubeExplosion.instance;
            cubeExplosion.cubePos = cubePosition;
        }

        
    }

    public void Save()
    {
       
        if (PointDisplay.instance != null)
        {
            pointDisplay = PointDisplay.instance;
            score = pointDisplay.score;
            scoreIn = pointDisplay.scoreIn;
            //slider = pointDisplay.sound;
        }
        if(Shooting.instance != null)
        {
            shooting = Shooting.instance;
            bulletCount = shooting.bulletsLeft;
           

        }
        if(volumeSettings.instance != null)
        {
          
        }
        if(CubeExplosion.instance != null)
        {
            cubeExplosion = CubeExplosion.instance;
            cubePosition = cubeExplosion.cubePos;
            
        }

        

        
    }

    public void NewScene()
    {
        pointDisplay.score = 0;
        pointDisplay.scoreIn = 0;
        pointDisplay.UpdateDisplay();
        shooting.bulletsLeft = shooting.magazineSize;
        
        

    }

   







}