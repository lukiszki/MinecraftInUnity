using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertBiome : Biome
{
    public override float firstLayerFirstIncrement { get { return 0.02f; } }
    public override float firstLayerSecondIncrement { get { return 0.02f; } }

    public override float waterLayerY { get { return 0; } }

    public override BlockType GenerateTerrain(float x, float y,float z, Vector3 chunkPos)
    {
        GenerateTerrainValues(x, y, z);
        if (y == generated1stLayerY)
        {
            return GenerateSurface(x,y,z,chunkPos);
        }
        if (y < generated2ndLayerY)
        {
            return Generate2ndLayer(y);
        }
        if (y < generated1stLayerY)
        {
            return Generate1stLayer();
        }
        return World.blockTypes[BlockType.Type.AIR];
    }
    protected override BlockType GenerateSurface(float x, float y, float z, Vector3 chunkPos)
    {
        return World.blockTypes[BlockType.Type.SAND];
    }
    protected override BlockType Generate1stLayer()
    {
        return World.blockTypes[BlockType.Type.SAND];
    }
}
