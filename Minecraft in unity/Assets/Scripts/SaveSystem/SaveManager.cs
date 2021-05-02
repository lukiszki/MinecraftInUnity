using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveManager : MonoBehaviour
{
    private PlayerControls Controls;
    private void Awake()
    {
        Controls = new PlayerControls();
        Controls.Gameplay.Save.performed += ctx => SaveFile();
        Controls.Gameplay.Load.performed += ctx => LoadFile();
    }

 /*  private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F5))
        {
            SaveFile();
        }
        if(Input.GetKeyDown(KeyCode.F6))
        {
            LoadFile();
        }
    }*/



 private void SaveFile()
    {
        string fileName = "C:/MinecraftUnity/Data" + "/ save.mindata";
        FileStream file;
        if(File.Exists(fileName))
        {
            file = File.OpenWrite(fileName);
        }
        else
        {
            file = File.Create(fileName);
        }

        GameData data = new GameData(GetPlayerPosition());
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(file,data);
        
        file.Close();
        ChunkSaveData chunksData = new ChunkSaveData();
        SaveChunkData(chunksData);
        

    }
    public void LoadFile()
    {
        string fileName = "C:/MinecraftUnity/Data" + "/ save.mindata";
        FileStream file;
        if(File.Exists(fileName))
        {
            file = File.OpenRead(fileName);
        }
        else
        {
            Debug.LogError("Save file does not exist! Try to save game or check code.");
            return;
        }
        
        BinaryFormatter formatter = new BinaryFormatter();
        GameData data = (GameData)formatter.Deserialize(file); 
        file.Close();

        SetPlayerPosition(data.PlayerPosition);
        SetOffsets(data);
        List<ChunkData> ChunkDatas = LoadChunkData();

         SetChunksData(ChunkDatas);

    }
    private Vector3 GetPlayerPosition()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        return player.transform.position;
    }
    private void SetPlayerPosition(Vector3 position)
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = position;
    }
    private void SetOffsets(GameData data)
    {
        ChunkUtils.firstLayeroffset = data.FirstLayerOffset;
        ChunkUtils.secondLayeroffset = data.SecondLayerOffset;
        ChunkUtils.moistureOffset = data.MoistureOffset;
        ChunkUtils.temperatureOffset = data.TemperatureOffset;
        ChunkUtils.typeOffset = data.TypeOffset;

    }
    private void SetChunksData(List<ChunkData> ChunkDat)
    {
       // var chunkData = data.ChunkData;
        var world = GameObject.Find("World").GetComponent<World>();
        world.GenerateLoadedWorld(ChunkDat);
    }
    private void OnEnable()
    {
        Controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        Controls.Gameplay.Disable();
    }

    private void SaveChunkData(ChunkSaveData data)
    {
        foreach (ChunkData chunkData in data.ChunkData)
        {
            string fileName = "C:/MinecraftUnity/Data/chunks" + "/"+chunkData.Name + ".mindata";
            FileStream file;
            if(File.Exists(fileName))
            {
                file = File.OpenWrite(fileName);
            }
            else
            {
                file = File.Create(fileName);
            }
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file,chunkData);
        
            file.Close();
            
        }
    }
    List<ChunkData> LoadChunkData()
    {
        
        List<ChunkData> chunks = new List<ChunkData>();
        foreach(string fileName  in Directory.GetFiles("C:/MinecraftUnity/Data/chunks"))
        {

            FileStream file;
            file = File.OpenRead(fileName);
           
        
            BinaryFormatter formatter = new BinaryFormatter();
            chunks.Add((ChunkData)formatter.Deserialize(file));
            file.Close();

        }

        return chunks;
    }
    
}
