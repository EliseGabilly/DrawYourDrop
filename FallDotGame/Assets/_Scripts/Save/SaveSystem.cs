using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// Save and load information fro player in the persistente data directory
/// </summary>
public static class SaveSystem {

    private static readonly string PATH = Application.persistentDataPath + "/player.txt";

    public static void SavePlayer(Player player) {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(PATH, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadData() {
        if (File.Exists(PATH)) {
            return LoadDataFromPath();
        } else {
            try {
                //try to write a new player if first conection
                SavePlayer(Player.Instance);
                return LoadDataFromPath();
            } catch (Exception e) {
                Debug.LogError("Save file not found (" + PATH + ") "+e.HelpLink);
                return null;
            }
        }
    }

    public static PlayerData LoadDataFromPath() {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(PATH, FileMode.Open);

        PlayerData data = formatter.Deserialize(stream) as PlayerData;
        stream.Close();

        Player.Instance.ChangeData(data);
        return data;
    }
}
