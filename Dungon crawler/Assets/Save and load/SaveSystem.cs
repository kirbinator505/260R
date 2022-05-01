using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    public static void SavePlayer(TMPPlayerController player, PlayerStats stats)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player, stats);

        
        formatter.Serialize(stream, data);

        stream.Close();
    }
    public static void SaveBasePlayer(TMPPlayerController player, PlayerStats stats)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.base";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player, stats);

        
        formatter.Serialize(stream, data);

        stream.Close();
    }
    
    public static void SaveBaseWave(EnemySpawner spawn)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/base.wave";
        FileStream stream = new FileStream(path, FileMode.Create);

        WaveData data = new WaveData(spawn);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static void SaveWave(EnemySpawner spawner)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/wave.lmao";
        FileStream stream = new FileStream(path, FileMode.Create);

        WaveData data = new WaveData(spawner);
        
        formatter.Serialize(stream, data);
        
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
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
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static WaveData LoadWave()
    {
        string path = Application.persistentDataPath + "/wave.lmao";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            WaveData data = formatter.Deserialize(stream) as WaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    public static WaveData LoadBaseWave()
    {
        string path = Application.persistentDataPath + "/base.wave";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            WaveData data = formatter.Deserialize(stream) as WaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    public static PlayerData LoadBasePlayer()
    {
        string path = Application.persistentDataPath + "/player.base";
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
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
