using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public interface IPlayerData<T>
{
    void Save(in T value);
    void Load(out T value);
}

public class PlayerData<T> : Singleton<PlayerData<T>>, IPlayerData<T>
{
    public PlayerData(string key)
    {
        Key = key;
    }

    public PlayerData(string key, T defaultValue)
    {
        Key = key;

        if (PlayerPrefs.HasKey(key) == false)
        {
            Save(defaultValue);
        }
    }

    public string Key;

    public void Save(in T value)
    {
        PlayerPrefs.SetString(Key, Convert.ToBase64String(ToByteArray(value)));
    }

    public void Load(out T value)
    {
        string data = PlayerPrefs.GetString(Key);
        value = FromByteArray(Convert.FromBase64String(data));
    }

    public void Clear()
    {
        PlayerPrefs.DeleteKey(Key);
    }

    private byte[] ToByteArray(T obj)
    {
        if (obj == null)
            return null;
        BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream())
        {
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }
    }

    private T FromByteArray(byte[] data)
    {
        if (data == null)
            return default(T);
        BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream(data))
        {
            object obj = bf.Deserialize(ms);
            return (T)obj;
        }
    }
}