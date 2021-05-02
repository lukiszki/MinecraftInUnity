using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class BiomeUtilis 
{
    public static Biome SelectBiome(Vector3 chunkPos)
    {
        float temperature = ChunkUtils.GenerateTemperature(chunkPos.x/World.chunkSize,chunkPos.z/ World.chunkSize);
        float moisture = ChunkUtils.GenerateMoisture(chunkPos.x/ World.chunkSize, chunkPos.z/ World.chunkSize);
        Biome biome = new DefaultBiome();
        if (temperature < 0.45f)
        {
            biome = new SnowBiome();
        }
        else
        {
            if (moisture < 0.4f && temperature > 0.6f)
            {
                biome = new DesertBiome();
            }
            else
                biome = new DefaultBiome();

            
        }
        return biome;
    }
}
