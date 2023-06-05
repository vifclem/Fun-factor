using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;

public class SaveAndLoad : MonoBehaviour
{
    public static SaveAndLoad instance;
    public Dictionary<string, bool> cubeExploded;
    public SaveData saveData;
    float val;

    private void Awake()
    {
        Debug.Log(Application.persistentDataPath);
        

       
    }
    private void Start()
    {
        LoadFile();
        cubeExploded = new Dictionary<string, bool>();
    }
    public void SaveToFile()
    {
        saveData.Save();
        //volumeSettings.SetSoundVolume();
        Debug.Log("save");
        string json = JsonUtility.ToJson(saveData);
        if (!File.Exists(Application.persistentDataPath + "/data.save"))
        {
            File.Create(Application.persistentDataPath + "/data.save").Dispose();
        }
        File.WriteAllText(Application.persistentDataPath + "/data.save", json);
        Debug.Log(json);
    }

    public void LoadFile()
    {

        Debug.Log(Application.persistentDataPath + "/data.save");
        if (File.Exists(Application.persistentDataPath + "/data.save"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/data.save");
            saveData = JsonUtility.FromJson<SaveData>(json);
            Debug.Log(json);
            saveData.Load();
        }
        else
        {
            saveData = new SaveData();

        }
    }

    public void NewLoad()
    {
        saveData.NewScene();
    }

    public void Quit()
    {
        Application.Quit();
    }

}
