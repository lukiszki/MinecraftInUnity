using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SeralizableVector3 
{
    private float x;
    private float y;
    private float z;

    public SeralizableVector3(Vector3 vector)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
    }
    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }
}
