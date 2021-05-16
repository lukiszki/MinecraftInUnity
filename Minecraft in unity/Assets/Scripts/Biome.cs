
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public abstract  class Biome
{
    public virtual float typeIncrement { get { return 0.08f; } }

    public virtual float coalIncrement { get { return 0.4f; } }

    public virtual float diamondIncrement { get { return 0.2f; } }


    public virtual float firstLayerFirstIncrement { get { return 0.02f; } }
    public virtual float firstLayerSecondIncrement { get { return 0.1f; } }
    public virtual float secondLayerIncrement { get { return 0.01f; } }

    public virtual float waterLayerY { get { return 20; } }


    protected float diamondProbability;
    protected float coalProbability;
    protected float caveProbability;
    protected int generated1stLayerY;
    protected int generated2ndLayerY;

    public virtual BlockType GenerateTerrain(float x, float y,float z, Vector3 chunkPos)
    {
        

        GenerateTerrainValues(x,y,z);
        if (y == generated1stLayerY&& y > waterLayerY-1)
        {
            return GenerateSurface(x, y, z, chunkPos);
        }
        if (y <= 1)
        {
            return GenerateBedrockLayer();
        }
        if (caveProbability < 0.15f && caveProbability > -0.15f&& y <= generated1stLayerY-2 && y > 4)
        {
            return GenerateCave();
        }
        if( y < generated2ndLayerY && y > 1)
        {
            return Generate2ndLayer(y);
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
        
        //return Tree.GetTreeType(new Vector3(x, y, z));

       return World.blockTypes[BlockType.Type.AIR];

       //    


    }

    protected virtual BlockType GenerateSurface(float x,float y,float z, Vector3 chunkPos)
    {

        if (Mathf.PerlinNoise(x * 0.03f, z * 0.03f) < 0.55f)
        {


            if (Mathf.PerlinNoise(x * 0.45f, z * 0.45f) < 0.13f)
            {

                if(CheckTree(x,y,z)) 
                    Structure.MakeTree(new Vector3(x, y, z), chunkPos, World.modifications, 7, 10, 3);
                else
                    return World.blockTypes[BlockType.Type.GRASS];
            }
        }
        return World.blockTypes[BlockType.Type.GRASS];
    }
    protected virtual BlockType GenerateCave()
    {
        return World.blockTypes[BlockType.Type.CAVE];
    }



    protected virtual BlockType Generate2ndLayer(float y)
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
         coalProbability = ChunkUtils.CalculateBlockProbability(x, y, z,100, coalIncrement);
         diamondProbability = ChunkUtils.CalculateBlockProbability(x, y, z,-100, diamondIncrement);
        caveProbability = ChunkUtils.CalculateCaveProbability(x, y, z,typeIncrement);
        generated1stLayerY = (int)ChunkUtils.Generate1stLayerHeight(x, z,firstLayerFirstIncrement,firstLayerSecondIncrement);
         generated2ndLayerY = (int)ChunkUtils.Generate2ndLayerHeight(x, z, generated1stLayerY,secondLayerIncrement);
    }
    bool CheckTree(float x,float y,float z)
    {
        if (Structure.Trees.Contains(new Vector2Int((int)x, (int)z)) ||
    Structure.Trees.Contains(new Vector2Int((int)x + 1, (int)z)) ||
    Structure.Trees.Contains(new Vector2Int((int)x, (int)z + 1)) ||
    Structure.Trees.Contains(new Vector2Int((int)x - 1, (int)z)) ||
    Structure.Trees.Contains(new Vector2Int((int)x, (int)z + 1)) ||
    Structure.Trees.Contains(new Vector2Int((int)x - 1, (int)z - 1)) ||
    Structure.Trees.Contains(new Vector2Int((int)x + 1, (int)z + 1)))
            return false;
        else return true;
    }

}
