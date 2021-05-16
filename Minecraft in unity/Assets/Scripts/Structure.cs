using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Structure 
{

    public static List<Vector2Int> Trees = new List<Vector2Int>();

    public static void MakeTree (Vector3 position,Vector3 chunkPos, Queue<VoxelMod> queue, int minTrunkHeight, int maxTrunkHeight,int radius)
    {
        int xOffset = 0;
        int yOffset = 0;
        int zOffset = 0;
        Vector3 localPosition = new Vector3(
            (Mathf.Round(position.x - chunkPos.x)),
            (Mathf.Round(position.y - chunkPos.y)),
            (Mathf.Round(position.z - chunkPos.z))
            );

        int height = (int)Mathf.Round(maxTrunkHeight * Mathf.PerlinNoise((position.x + ChunkUtils.firstLayeroffset)*0.4f,
            (position.y + ChunkUtils.firstLayeroffset)*0.4f));

        if (height < minTrunkHeight)
            height = minTrunkHeight;
       
        //KORONA DRZEWA

         yOffset = 0;
        Vector3 center = new Vector3(0, height, 0);
        for (int x = (int)center.x-radius; x < (int)center.x + radius; x++) {
            for (int y = (int)center.y - radius; y < (int)center.y + radius; y++) {
                for (int z = (int)center.z - radius; z < (int)center.z + radius; z++)
                {
                    if (Vector3.Distance(center, new Vector3(x, y, z)) <= radius)
                    {
                        queue.Enqueue(new VoxelMod(
                            new Vector3(ValidatePos((int)localPosition.x + x, ref xOffset),
                                ValidatePos((int)localPosition.y + y, ref yOffset),
                                ValidatePos((int)localPosition.z + z, ref zOffset)),
                        World.blockTypes[BlockType.Type.OAK_LEAVES],
                        SetChunk(chunkPos, new Vector3(xOffset, yOffset, zOffset))));
                    }
                 xOffset = 0;
                 yOffset = 0;
                 zOffset = 0;
                }
            }
        }

        //PIEŃ DRZEWA
        for (int i = 0; i < height; i++)
            queue.Enqueue(new VoxelMod(
                new Vector3(localPosition.x, ValidatePos((int)localPosition.y + i, ref yOffset), localPosition.z),
                World.blockTypes[BlockType.Type.LOG_OAK], SetChunk(chunkPos, new Vector3(xOffset, yOffset, zOffset))));
        Trees.Add(new Vector2Int((int)position.x, (int)position.z));

    }

    private static int ValidatePos(int pos, ref int offset)
    {
        if (pos >= World.chunkSize)
        {
            offset++;
            return ValidatePos(pos - World.chunkSize, ref offset);
        }
       if (pos < 0)
        {
            offset--;
            return ValidatePos(pos + World.chunkSize, ref offset);
        }

        return pos;
    }

    private static Vector3 SetChunk(Vector3 chPos, Vector3 offsets)
    {
        return chPos + new Vector3(World.chunkSize * offsets.x, World.chunkSize * offsets.y,
            World.chunkSize * offsets.z);

    }
    
}
