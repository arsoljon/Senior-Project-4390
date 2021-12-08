using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class SaveSystem : MonoBehaviour
{
    private GameObject _player;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Save()
    {
        Debug.Log("SAVING!!!");
        
        
        FileStream file = new FileStream(Application.persistentDataPath + "/Player.dat", FileMode.OpenOrCreate);
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            PlayerData player = new PlayerData(_player);
            formatter.Serialize(file, player);
        }
        catch (SerializationException e)
        {
            Debug.LogError("There was an issue initializing this data: " + e.Message);
        }
        finally
        {
            file.Close();
        }
    }

    public void Load()
    {

    }
}
