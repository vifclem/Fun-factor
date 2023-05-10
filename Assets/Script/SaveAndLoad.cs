using UnityEngine;
using System.IO;
using System;

public class SaveAndLoad : MonoBehaviour
{
    public static SaveAndLoad instance;

    public SaveData saveData;


    private void Awake()
    {
        Debug.Log(Application.persistentDataPath);

        SaveToFile();
    }
    public void SaveToFile()
    {
        saveData.Save();
        string json = JsonUtility.ToJson(saveData);
        if (!File.Exists(Application.persistentDataPath + "/data.save"))
        {
            File.Create(Application.persistentDataPath + "/data.save").Dispose();
        }
        File.WriteAllText(Application.persistentDataPath + "/data.save", json);
    }

    public void LoadFile()
    {

        Debug.Log(Application.persistentDataPath + "/data.save");
        if (File.Exists(Application.persistentDataPath + "/data.save"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/data.save");
            saveData = JsonUtility.FromJson<SaveData>(json);
            saveData.Load();
        }
        else
        {
            saveData = new SaveData();
        }
    }

}
