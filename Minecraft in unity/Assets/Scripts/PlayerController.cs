using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private LayerMask _maskToIgnore;
    [SerializeField]
    private int _interactionRange;
    [SerializeField]
    private Camera _camera;
    private World _world;
    private GameObject player;
    private GameObject panel;
    
    [SerializeField]
    private GameObject ParticleSystem;

    private PlayerControls Controls;
    
    private void Awake()
    {
        _world = GameObject.Find("World").GetComponent<World>();
         panel = GameObject.Find("Panel");
         player = GameObject.FindGameObjectWithTag("Player");
        panel.SetActive(false);
        Controls = new PlayerControls();
        Controls.Gameplay.Destroy.performed += ctx => RemoveBlock();
    }

    private void Update()
    {
       /* if (Input.GetMouseButtonDown(0))
        {
            RemoveBlock();
        }*/

        if (Chunk.waterBlocks.Contains(new  Vector3(Mathf.Ceil(player.transform.position.x),Mathf.Ceil(player.transform.position.y),Mathf.Ceil(player.transform.position.z))))
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
        
    }

    private void RemoveBlock()
    {
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _interactionRange, ~_maskToIgnore))
        {
            Vector3 blockPos = hit.point - hit.normal/ 2.0f;
            Vector3 chunkPos = hit.transform.position;
            int blockPosX =  (int)(Mathf.Round(blockPos.x - chunkPos.x));
            int blockPosY =  (int)(Mathf.Round(blockPos.y - chunkPos.y));
            int blockPosZ =  (int)(Mathf.Round(blockPos.z - chunkPos.z));
            _world.DestroyBlock(hit.transform.name, new Vector3(blockPosX, blockPosY, blockPosZ)); 
            GameObject particle = Instantiate(ParticleSystem, blockPos, Quaternion.identity);
            Destroy(particle,3);
        }
    }
    private void OnEnable()
    {
        Controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        Controls.Gameplay.Disable();
    }
}
