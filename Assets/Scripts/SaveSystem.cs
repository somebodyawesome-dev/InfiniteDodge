using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem 
{
  static string path = Application.persistentDataPath + "/playerData.wiow";

    public static void saveDate(float score)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        GameData gameData = new GameData(score);
        binaryFormatter.Serialize(stream, gameData);
        stream.Close();
    }
    public static void saveDate(float score,int donuts)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        GameData gameData = new GameData(score,donuts);
        binaryFormatter.Serialize(stream, gameData);
        stream.Close();
    }

    public static GameData loadData()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData result = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return result;
        }
        else
        {
            Debug.LogError("GameData File Doesnt exist");
            return new GameData(0.0f);
        }
    }

}
