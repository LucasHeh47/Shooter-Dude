using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class PlayerDataManager 
{
    public static void SaveData(PlayerData playerData)
    {
        string dataFilePath = Application.persistentDataPath + "/PlayerData.monkeysap";
        BinaryFormatter formatter = new BinaryFormatter();

        Debug.Log(playerData.PlayerExp + "After: " + playerData);

        FileStream stream = new FileStream(dataFilePath, FileMode.Create);

        formatter.Serialize(stream, playerData);
        stream.Close();
    }

    public static PlayerData LoadData()
    {
        string dataFilePath = Application.persistentDataPath + "/PlayerData.monkeysap";
        if (File.Exists(dataFilePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(dataFilePath, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
