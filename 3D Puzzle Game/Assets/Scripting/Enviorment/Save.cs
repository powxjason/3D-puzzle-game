using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Save : MonoBehaviour
{

    public SaveFile saveFile;

    const string folderName = "PlayerSaveData";
    const string fileExtension = ".dat";

    public void SaveData()
    {
        string folderPath = Path.Combine(Application.persistentDataPath, folderName);
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string dataPath = Path.Combine(folderPath, saveFile + fileExtension);
        SaveCharacter(saveFile, dataPath);

    }

    public void LoadData(string path)
    {
        string[] filePaths = GetFilePaths();

        if (filePaths.Length > 0)
            saveFile = LoadCharacter(filePaths[0]);
    }

    static void SaveCharacter(SaveFile data, string path)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = File.Open(path, FileMode.OpenOrCreate))
        {
            binaryFormatter.Serialize(fileStream, data);
        }
    }

    static SaveFile LoadCharacter(string path)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = File.Open(path, FileMode.Open))
        {
            return (SaveFile)binaryFormatter.Deserialize(fileStream);
        }
    }

    static string[] GetFilePaths()
    {
        string folderPath = Path.Combine(Application.persistentDataPath, folderName);

        return Directory.GetFiles(folderPath, fileExtension);
    }
}


[System.Serializable]
public class SaveFile 
{
    public int level;

    public SaveFile ()
    {
        level = 0;
    }

    public SaveFile (int _level)
    {
        level = _level;
    }

}
