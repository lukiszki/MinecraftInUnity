using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract  class Biome
{
    public virtual float typeIncrement { get { return 0.08f; } }
    public virtual float firstLayerFirstIncrement { get { return 0.02f; } }
    public virtual float firstLayerSecondIncrement { get { return 0.1f; } }
    public virtual float secondLayerIncrement { get { return 0.01f; } }

    public virtual float waterLayerY { get { return 32f; } }

    private List<Vector3> Trees = new List<Vector3>();

    protected float typeProbability;
    protected int generated1stLayerY;
    protected int generated2ndLayerY;

    public virtual BlockType GenerateTerrain(float x, float y,float z)
    {
        GenerateTerrainValues(x,y,z);
        if (y == generated1stLayerY&& y > waterLayerY-1)
        {
            if (Random.Range(1, 1000) > 990)
            {
                Trees.Add(new Vector3(x,y,z));
                return World.blockTypes[BlockType.Type.WOODEN];
                
            }
            else
            return GenerateSurface();
        }
        if (y <= 1)
        {
            return GenerateBedrockLayer();
        }
        if (typeProbability > 0.5f && y < generated1stLayerY - 5)
        {
            return GenerateCave();
        }
        if( y < generated2ndLayerY && y > 1)
        {
            return Generate2ndLayer();
        }
        if( y < generated1stLayerY)
        {
            return Generate1stLayer();
        }
        if(y < waterLayerY)
        {
            Chunk.waterBlocks.Add(new Vector3(x,y,z));
            return GenerateWaterLayer();
        }

        if (Trees.Contains(new Vector3(x, y-1, z)))
        {
            return World.blockTypes[BlockType.Type.WOODEN];
        }
        if (Trees.Contains(new Vector3(x, y-2, z)))
        {
            return World.blockTypes[BlockType.Type.WOODEN];
        }
        if (Trees.Contains(new Vector3(x, y-3, z)))
        {
            return World.blockTypes[BlockType.Type.WOODEN];
        }
       
        return World.blockTypes[BlockType.Type.AIR];
        

    }
    protected virtual BlockType GenerateSurface()
    {
        
            return World.blockTypes[BlockType.Type.GRASS];
    }
    protected virtual BlockType GenerateCave()
    {
        return World.blockTypes[BlockType.Type.CAVE];
    }



    protected virtual BlockType Generate2ndLayer()
    {
        return World.blockTypes[BlockType.Type.STONE];
    }
    protected virtual BlockType Generate1stLayer()
    {
        return World.blockTypes[BlockType.Type.DIRT];
    }
    protected virtual BlockType GenerateBedrockLayer()
    {
        return World.blockTypes[BlockType.Type.BEDROCK];
    }
    protected virtual BlockType GenerateWaterLayer()
    {
        return World.blockTypes[BlockType.Type.WATER];
    }


    protected virtual void GenerateTerrainValues(float x,float y,float z)
    {
         typeProbability = ChunkUtils.CalculateBlockProbability(x, y, z,typeIncrement);
         generated1stLayerY = (int)ChunkUtils.Generate1stLayerHeight(x, z,firstLayerFirstIncrement,firstLayerSecondIncrement);
         generated2ndLayerY = (int)ChunkUtils.Generate2ndLayerHeight(x, z, generated1stLayerY,secondLayerIncrement);
    }

}
