using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class BiomeUtilis 
{
    public static Biome SelectBiome(Vector3 chunkPos)
    {
        /* float temperature = ChunkUtils.GenerateTemperature(chunkPos.x/World.chunkSize,chunkPos.z/ World.chunkSize);
         float moisture = ChunkUtils.GenerateMoisture(chunkPos.x/ World.chunkSize, chunkPos.z/ World.chunkSize);*/
        float biomeNoise = ChunkUtils.GetBiomeNoise(chunkPos.x, chunkPos.z);
        Biome biome = new DefaultBiome();
        if (biomeNoise > 0.85f)
        {
            biome = new SnowBiome();
        }
        else if (biomeNoise < 0.25f)
        {

            biome = new DesertBiome();
        }
        else
            biome = new DefaultBiome();

            
        
        return biome;
    }
}
