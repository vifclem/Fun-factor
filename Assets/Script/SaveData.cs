using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

[Serializable]
public class SaveData
{
    public WorldData worldData;
  
    [NonSerialized]public PointDisplay pointDisplay;
    [NonSerialized] public Shooting shooting;
    [NonSerialized] public CubeExplosion cubeExplosion;
    [NonSerialized] public volumeSettings volumSettings;
    [SerializeField] private List<Vector3> cubePositions= new List<Vector3>();
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
        //if(CubeExplosion.instance != null)
        //{
        //    cubeExplosion = CubeExplosion.instance;
        //    cubeExplosion.cubePos = cubePosition;
        //}
        CubeExplosion[] cubes = GameObject.FindObjectsOfType<CubeExplosion>();
        Debug.Log($"Saved {cubePositions.Count} cubes");
        if (cubePositions.Count > 0)
        {
            for (int c = 0; c < cubePositions.Count; c++)
            {
                if (c < cubes.Length) cubes[c].transform.position = cubePositions[c];
            }
            for (int c = cubePositions.Count; c < cubes.Length; c++)
            {
                GameObject.Destroy(cubes[c].gameObject);
            }
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
        //if(CubeExplosion.instance != null)
        //{
        //    cubeExplosion = CubeExplosion.instance;
        //    cubePosition = cubeExplosion.cubePos;

        //}
        cubePositions.Clear();
        foreach(CubeExplosion cube in GameObject.FindObjectsOfType<CubeExplosion>())
        {
            cubePositions.Add(cube.transform.position);
        }
        Debug.Log($"Saved {cubePositions.Count} cubes");

        
    }

    public void NewScene()
    {
        pointDisplay.score = 0;
        pointDisplay.scoreIn = 0;
        pointDisplay.UpdateDisplay();
        shooting.bulletsLeft = shooting.magazineSize;
        cubePositions.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

   







}