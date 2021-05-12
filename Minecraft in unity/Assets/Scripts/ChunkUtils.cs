
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChunkUtils 
{
    public static int firstLayeroffset = 0;
    public static int secondLayeroffset = 0;
    public static int typeOffset = 0;
    public static int moistureOffset = 0;
    public static int temperatureOffset = 0;
    static int caveOffset = 0;

    public static float climateIncrement = 0.1f;
    static int maxHeight = 48;

    static FastNoise noise = new FastNoise();

    public static float Generate1stLayerHeight(float x,float z,float firstIncrement = 0.01f,float secondIncrement = 0.1f)
    { 
      /*  float firstHeight = PerlinNoise(x * firstIncrement + firstLayeroffset, z * firstIncrement + firstLayeroffset);
        firstHeight =  Map(16, maxHeight, 0, 1, firstHeight);
        float secondHeight =    (PerlinNoise(x * (secondIncrement * GenerateTemperature(x, z)) + firstLayeroffset, z * (secondIncrement* GenerateTemperature(x, z)) + firstLayeroffset));
        secondHeight = Map(16, maxHeight * GenerateTemperature(x, z) + 16, 0, 1, secondHeight);
        
        float finalHeight = firstHeight + secondHeight;*/
        float simplex1 = noise.GetSimplex(x * .8f, z * .8f) * 10;
        float simplex2 = noise.GetSimplex(x * 3f, z * 3f) * 10 * (noise.GetSimplex(x * climateIncrement, z * climateIncrement) + .5f);
        
        float heightMap = 48 * .5f + (simplex1 + simplex2);
        return heightMap;
    }
    public static float Generate2ndLayerHeight(float x, float z, int maxHeight,float increment = 0.1f)
    {
        float height = PerlinNoise(x * increment + secondLayeroffset, z * increment * 5 + secondLayeroffset);
        height = Map(16, maxHeight, 0, 1, height);
        return height;
    }
    static float Map(float from,float to,float from2,float to2,float value)
    {
        if (value <= 0)
            return from;

        if (value >= to2)
            return to;

        return (to - from) * ((value - from2) / (to2 - from2)) + from;

        
    }
    public static float GenerateMoisture(float x, float z, float increment = 0.01f)
    {
        
        return PerlinNoise(x * increment + moistureOffset, z * increment + moistureOffset);
    }
    public static float GenerateTemperature(float x, float z, float increment = 0.01f)
    {
        return PerlinNoise(x * increment + temperatureOffset, z * increment + temperatureOffset);
    }

    static float PerlinNoise(float x, float z)
    {
        float height = Mathf.PerlinNoise(x, z);
        return height;
    }
    public static float CalculateBlockProbability(float x,float y,float z, float offset,float increment=0.08f)
    {
        
        x = x * increment + typeOffset + offset;
        y = y * increment + typeOffset + offset;
        z = z * increment + typeOffset + offset;
        return PerlinNoise3D(x, y, z);
    }
    public static float CalculateCaveProbability(float x, float y, float z, float increment = 0.08f)
    {

      /*  x = x * increment + typeOffset;
        y = y * increment + typeOffset;
        z = z * increment + typeOffset;*/

        return noise.GetPerlinFractal(x *2, y*2.5f , z *2);
    }
    static float PerlinNoise3D(float x,float y,float z)
    {
        float XY = Mathf.PerlinNoise(x, y);
        float XZ = Mathf.PerlinNoise(x, z);
        float YZ = Mathf.PerlinNoise(y, z);

        float YX = Mathf.PerlinNoise(y, x);
        float ZX = Mathf.PerlinNoise(z, x);
        float ZY = Mathf.PerlinNoise(z, y);
        return (XY + XZ + YZ + YX + ZX + ZY)/6;

    }
    public static float GetBiomeNoise(float x, float y)
    {
        return (noise.GetSimplex(x * climateIncrement, y * climateIncrement) + .5f);
    }
    public static void GenerateRandomOffset()
    {
        firstLayeroffset = Random.Range(0, 1000);
        secondLayeroffset = Random.Range(0, 1000);
        typeOffset = Random.Range(0, 1000);
        moistureOffset = Random.Range(0, 1000);
        temperatureOffset = Random.Range(0, 1000);
    }

}
