using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{
    private GameObject player;

    private Vector3 newPosition;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        newPosition = player.transform.position;
        newPosition.y = 300;
        transform.position = newPosition;
    }
}
