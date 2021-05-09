using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkUtils 
{
    public static int firstLayeroffset = 0;
    public static int secondLayeroffset = 0;
    public static int typeOffset = 0;
    public static int moistureOffset = 0;
    public static int temperatureOffset = 0;
    static int caveOffset = 0;
     

    static int maxHeight = 90;


    public static float Generate1stLayerHeight(float x,float z,float firstIncrement = 0.01f,float secondIncrement = 0.1f)
    {
        float firstHeight = PerlinNoise(x * firstIncrement + firstLayeroffset, z * firstIncrement + firstLayeroffset);
        firstHeight = Map(16, maxHeight, 0, 1, firstHeight);
        float secondHeight = PerlinNoise(x * secondIncrement + firstLayeroffset, z * secondIncrement + firstLayeroffset);
        secondHeight = Map(16, 32, 0, 1, secondHeight);
        float finalHeight = (firstHeight +secondHeight)/2;
        return finalHeight;
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
    public static float GenerateMoisture(float x, float z, float increment = 0.1f)
    {
        
        return PerlinNoise(x * increment + moistureOffset, z * increment + moistureOffset);
    }
    public static float GenerateTemperature(float x, float z, float increment = 0.1f)
    {
        return PerlinNoise(x * increment + temperatureOffset, z * increment + temperatureOffset);
    }

    static float PerlinNoise(float x, float z)
    {
        float height = Mathf.PerlinNoise(x, z);
        return height;
    }
    public static float CalculateBlockProbability(float x,float y,float z,float increment=0.08f)
    {

        x = x * increment + typeOffset;
        y = y * increment + typeOffset;
        z = z * increment + typeOffset;
        return PerlinNoise3D(x, y, z);
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
    public static void GenerateRandomOffset()
    {
        firstLayeroffset = Random.Range(0, 1000);
        secondLayeroffset = Random.Range(0, 1000);
        typeOffset = Random.Range(0, 1000);
        moistureOffset = Random.Range(0, 1000);
        temperatureOffset = Random.Range(0, 1000);
    }

}
