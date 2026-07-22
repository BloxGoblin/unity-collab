using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.Common;
using UnityEngine.InputSystem.Interactions;
using System;

public static class SaveSystem
{
    public static void SavePlayerData(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.poopy";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();

        Console.WriteLine("Poop");
    }

    public static PlayerData LoadPlayerData(Player player)
    {
        string path = Application.persistentDataPath + "/player.poopy";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Big oopsie alert: No save file found in " + path);
            return null;
        }
    }
}