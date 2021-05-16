using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockType 
{

    //Wszystkie bloki gry
    //Pamietaj podczas dodawania dodaj rowniez w skrypcie world
    public enum Type    {AIR, DIRT, WOODEN, GRASS, STONE, COAL_ORE, DIAMOND_ORE, SNOW, SAND, CAVE, GLASS, BEDROCK, WATER, LOG_OAK, OAK_LEAVES};

    public string name { get; private set; }
    public bool isTransparent { get; private set; }
    public bool isTransluent { get; private set; }
    public bool everySideSame { get; private set; }

    public float trasparency;

    public Type blockType { get; private set; }


    public Vector2[] topUV{ private get; set; }
    public Vector2[] sideUV{ private get; set; }
    public Vector2[] bottomUV{ private get; set; }

    List<Vector2[]> blockUVs = new List<Vector2[]>();


    public BlockType (string typeName, bool isTransparent,bool isTransluent, bool everySideSame, float _transparency = 0.35f)
    {
        this.name = typeName;
        this.isTransparent = isTransparent;
        this.isTransluent = isTransluent;
        this.everySideSame = everySideSame;
        this.blockType = (Type)Enum.Parse(typeof(Type), typeName.ToUpper());
        this.trasparency = _transparency;
    }
    
    public Vector2[] GetUV (Block.BlockSide side)
    {
        if (everySideSame || (side != Block.BlockSide.TOP && side != Block.BlockSide.BOTTOM))
            return this.sideUV;
        if (side == Block.BlockSide.TOP)
            return this.topUV;
        else
            return this.bottomUV;

    }
    public void GenerateBlockUVs()
    {
        this.blockUVs.Add(new Vector2[] { sideUV[3], sideUV[2], sideUV[0], sideUV[1] });

        if (everySideSame)
        {
            return;
        }

        if (topUV.Length>0)
        {
            this.blockUVs.Add(new Vector2[] { topUV[3], topUV[2], topUV[0], topUV[1] });
        }
        if (bottomUV.Length > 0)
        {
            this.blockUVs.Add(new Vector2[] { bottomUV[3], bottomUV[2], bottomUV[0], bottomUV[1] });
        }
    }
    public Vector2[]GetBlockUVs(Block.BlockSide side)
    {
      
        if (everySideSame || (side != Block.BlockSide.TOP && side != Block.BlockSide.BOTTOM))
            return this.blockUVs[0];
        if (side == Block.BlockSide.TOP)
            return this.blockUVs[1];
        else
            return this.blockUVs[2];
    }
    public bool isLiquid()
    {
        if (this.name == "water")
        {
            return true;
        }
        else return false;

    }

}
