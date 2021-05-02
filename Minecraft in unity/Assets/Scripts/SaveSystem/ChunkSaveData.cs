using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChunkSaveData : MonoBehaviour
{
    public List<ChunkData> ChunkData { get; private set; }

    public ChunkSaveData()
    {
        ChunkData = new List<ChunkData>();
        BuildChunkData();
    }
    
    private void BuildChunkData()
    {
        foreach (var chunk in World.chunks)
        {
            var chunkData = new ChunkData(chunk.Key, chunk.Value.GetBlockTypes());
            ChunkData.Add(chunkData);
        }
    }
}
