using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBiome : Biome
{
    protected override BlockType GenerateSurface(float x, float y, float z, Vector3 chunkPos)
    {
        return World.blockTypes[BlockType.Type.SNOW];
    }
    protected override BlockType Generate1stLayer()
    {
        return World.blockTypes[BlockType.Type.SNOW];
    }
}
