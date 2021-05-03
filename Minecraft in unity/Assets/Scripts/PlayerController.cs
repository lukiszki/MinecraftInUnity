using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private BlockType.Type selectedBlockType;
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
        Controls.Gameplay.PlaceBlock.performed += ctx => BuildBlock();
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

    private void BuildBlock()
    {
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _interactionRange, ~_maskToIgnore))
        {
            Vector3 blockPos = hit.point + hit.normal/ 2.0f;
            Vector3 chunkPos = hit.transform.position;
            if(Mathf.Round(this.transform.position.x) == Mathf.Round(blockPos.x)&&Mathf.Round(this.transform.position.y) == Mathf.Round(blockPos.y)&&Mathf.Round(this.transform.position.x) == Mathf.Round(blockPos.x)) return;
            int blockPosX =  (int)(Mathf.Round(blockPos.x - chunkPos.x));
            int blockPosY =  (int)(Mathf.Round(blockPos.y - chunkPos.y));
            int blockPosZ =  (int)(Mathf.Round(blockPos.z - chunkPos.z));
            Vector3 newBlockPos = new Vector3(blockPosX, blockPosY, blockPosZ);
            ValidatePositions(hit.normal,ref newBlockPos,ref chunkPos);
            _world.BuildBlock(World.GenerateChunkName(chunkPos), newBlockPos,selectedBlockType); 
            GameObject particle = Instantiate(ParticleSystem, blockPos, Quaternion.identity);
            Destroy(particle,2);
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
            _world.DestroyBlock(World.GenerateChunkName(chunkPos), new Vector3(blockPosX, blockPosY, blockPosZ)); 
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

    private void ValidatePositions(Vector3 normal, ref Vector3 blockPos, ref Vector3 chunkPos)
    {
        if (normal.x > 0 && blockPos.x >= World.chunkSize)
        {
            blockPos.x = 0;
            chunkPos.x += World.chunkSize;
        }
        if (normal.x < 0 && blockPos.x < 0)
        {
            blockPos.x = World.chunkSize - 1;
            chunkPos.x -= World.chunkSize;
        }
        if (normal.y > 0 && blockPos.y >= World.chunkSize)
        {
            blockPos.y = 0;
            chunkPos.y += World.chunkSize;
        }
        if (normal.y < 0 && blockPos.y < 0)
        {
            blockPos.y = World.chunkSize - 1;
            chunkPos.y -= World.chunkSize;
        }
        if (normal.z > 0 && blockPos.z >= World.chunkSize)
        {
            blockPos.z = 0;
            chunkPos.z += World.chunkSize;
        }
        if (normal.z < 0 && blockPos.z < 0)
        {
            blockPos.z = World.chunkSize - 1;
            chunkPos.z -= World.chunkSize;
        }
    }
    
}
