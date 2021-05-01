using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBiome : Biome
{
    protected override BlockType Generate2ndLayer()
    {
        if (typeProbability < 0.15f)
        {
            return World.blockTypes[BlockType.Type.DIAMOND_ORE];
        }
        else if (typeProbability < 0.25f)
        {
            return World.blockTypes[BlockType.Type.COAL_ORE];
        }
        else
        return World.blockTypes[BlockType.Type.STONE];

    }
}
