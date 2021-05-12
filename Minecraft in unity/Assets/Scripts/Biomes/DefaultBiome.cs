using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBiome : Biome
{
    protected override BlockType Generate2ndLayer(float y)
    {
        if (diamondProbability < 0.265f&&y<16)
        {
            return World.blockTypes[BlockType.Type.DIAMOND_ORE];
        }
        else if (coalProbability < 0.35f)
        {
            return World.blockTypes[BlockType.Type.COAL_ORE];
        }
        else
        return World.blockTypes[BlockType.Type.STONE];

    }
}
