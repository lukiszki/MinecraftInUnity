using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkAnimation : MonoBehaviour
{
    float speed = 2f;
    Vector3 targetPos;
    private void Start()
    {
        targetPos = transform.position;
        transform.position = new Vector3(transform.position.x, -World.chunkSize, transform.position.z);
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);
        if(targetPos.y -transform.position.y < 0.05f)
        {
            transform.position = targetPos;
            Destroy(this);
        }
    }
}
