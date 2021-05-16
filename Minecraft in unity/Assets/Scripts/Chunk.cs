using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Chunk
{
    public Block[,,] chunkBlocks;
    public GameObject chunkObject;
    Material[] blockMaterial;
    public enum chunkStatus { GENERATED, DRAWN, TO_DRAW };
    public chunkStatus status;
    public int VertexIndex { get; set; }

    public List<Vector3> vertices = new List<Vector3>();
    public List<int> triangles = new List<int>();
    public List<int> transparentTriangles = new List<int>();
    public List<int> waterTriangles = new List<int>();
    public List<Vector2> uvs = new List<Vector2>();
    public List<Color> colors = new List<Color>(); 
    public static List<Vector3> waterBlocks = new List<Vector3>();
    private Sounds _sounds;

    public Chunk(string name, Vector3 position, Material[] material)
    {
        this.chunkObject = new GameObject(name);
        this.chunkObject.transform.position = position;
        this.blockMaterial = material;
        this.status = chunkStatus.GENERATED;
        _sounds = GameObject.Find("SoundManager").GetComponent<Sounds>();
        GenerateChunk(16);
    }

    public Chunk(string name, Vector3 position, Material[] material, BlockType.Type[,,] blockTypes)
    {
        this.chunkObject = new GameObject(name);
        this.chunkObject.transform.position = position;
        this.blockMaterial = material;
        this.status = chunkStatus.GENERATED;
        _sounds = GameObject.Find("SoundManager").GetComponent<Sounds>();
        GenerateLoadedChunk(16, blockTypes);
    }

    void GenerateChunk(int chunkSize)
    {
        chunkBlocks = new Block[chunkSize, chunkSize, chunkSize];
        Biome biome = BiomeUtilis.SelectBiome(this.chunkObject.transform.position);

        for (int z = 0; z < chunkSize; z++)
        {
            for (int y = 0; y < chunkSize; y++)
            {
                for (int x = 0; x < chunkSize; x++)
                {
                    float worldX = x + chunkObject.transform.position.x;
                    float worldY = y + chunkObject.transform.position.y;
                    float worldZ = z + chunkObject.transform.position.z;

                    biome = BiomeUtilis.SelectBiome(new Vector3(worldX,worldY,worldZ));

                    //Terrain Pass
                    BlockType biomeBlock = biome.GenerateTerrain(worldX, worldY, worldZ, chunkObject.transform.position);
                    
                    chunkBlocks[x, y, z] = new Block(biomeBlock, this, new Vector3(x, y, z));
  

                    if (biomeBlock == World.blockTypes[BlockType.Type.AIR])
                        this.status = chunkStatus.TO_DRAW;
                }
            }
        }

        if (status == chunkStatus.TO_DRAW)
        {
            string chunkName = (int)this.chunkObject.transform.position.x + "_" + ((int)this.chunkObject.transform.position.y - 16) + "_" + (int)this.chunkObject.transform.position.z;
            Chunk chunkBelow;

            if (World.chunks.TryGetValue(chunkName, out chunkBelow))
            {
                chunkBelow.status = chunkStatus.TO_DRAW;
            }
        }
    }

    void GenerateLoadedChunk(int chunkSize, BlockType.Type[,,] blockTypes)
    {
        chunkBlocks = new Block[chunkSize, chunkSize, chunkSize];

        for (int z = 0; z < chunkSize; z++)
        {
            for (int y = 0; y < chunkSize; y++)
            {
                for (int x = 0; x < chunkSize; x++)
                {
                    chunkBlocks[x, y, z] = new Block(World.blockTypes[blockTypes[x, y, z]], this, new Vector3(x, y, z));
                }
            }
        }
    }

    public void RefreshChunk(string name, Vector3 position)
    {
        this.chunkObject = new GameObject(name);
        this.chunkObject.transform.position = position;

        foreach (Block block in chunkBlocks)
        {
            if (block.GetBlockType() == World.blockTypes[0])
            {
                this.status = chunkStatus.TO_DRAW;

                string chunkName = (int)this.chunkObject.transform.position.x + "_" + ((int)this.chunkObject.transform.position.y - 16) + "_" + (int)this.chunkObject.transform.position.z;
                Chunk chunkBelow;

                if (World.chunks.TryGetValue(chunkName, out chunkBelow))
                {
                    chunkBelow.status = chunkStatus.TO_DRAW;
                }

                break;
            }
        }
    }

    public void DrawChunk(int chunkSize, bool isAnimating)
    {
        VertexIndex = 0;
        vertices.Clear();
        triangles.Clear();
        transparentTriangles.Clear();
        waterTriangles.Clear();
        uvs.Clear();
        colors.Clear();
        CalculateLight();
        for (int z = 0; z < chunkSize; z++)
        {
            for (int y = 0; y < chunkSize; y++)
            {
                for (int x = 0; x < chunkSize; x++)
                {
                    chunkBlocks[x, y, z].CreateBlock();
                }
            }
        }

        CombineSides();
       // if(isAnimating)
      //  chunkObject.AddComponent<ChunkAnimation>();


        this.status = chunkStatus.DRAWN;
    }

    public void RedrawChunk(int chunkSize)
    {
        vertices = new List<Vector3>();
        triangles = new List<int>();
        transparentTriangles = new List<int>();
        waterTriangles = new List<int>();
        uvs = new List<Vector2>();
        colors = new List<Color>();
        DrawChunk(chunkSize, false);

    }

    private void RedrawNeighbourChunk(Vector3 neighbourPosition)
    {
        Vector3 neighbourChunkPos = this.chunkObject.transform.position;
        neighbourChunkPos.x += neighbourPosition.x;
        neighbourChunkPos.y += neighbourPosition.y;
        neighbourChunkPos.z += neighbourPosition.z;
        string neighbourChunkName = World.GenerateChunkName(neighbourChunkPos);
        Chunk neighbourChunk;
        if (World.chunks.TryGetValue(neighbourChunkName, out neighbourChunk))
        {
            neighbourChunk.RedrawChunk(World.chunkSize);
        }
    }


    void CombineSides()
    {

        var mesh = new Mesh();
        mesh.vertices = vertices.ToArray();
        mesh.subMeshCount = 2;
        mesh.SetTriangles(triangles.ToArray(), 0);
        mesh.SetTriangles(transparentTriangles.ToArray().Concat(waterTriangles.ToArray()).ToArray(), 1);
        mesh.uv = uvs.ToArray();
        mesh.RecalculateNormals();
        mesh.colors = colors.ToArray();
        


        var colliderMesh = new Mesh();
        colliderMesh.vertices = mesh.vertices;
        colliderMesh.subMeshCount = 2;
        colliderMesh.SetTriangles(triangles.ToArray(), 0);
        colliderMesh.SetTriangles(transparentTriangles.ToArray(), 1);
        
        
        if (!chunkObject.TryGetComponent<MeshFilter>(out MeshFilter blockMeshFilter))
        { 
            blockMeshFilter = chunkObject.AddComponent(typeof(MeshFilter)) as MeshFilter;
        }
      
        blockMeshFilter.mesh = mesh;

        if (!chunkObject.TryGetComponent<MeshRenderer>(out MeshRenderer blockMeshRenderer))
        { 
            blockMeshRenderer = chunkObject.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        }
        
        
        blockMeshRenderer.materials = blockMaterial;

        
        if (!chunkObject.TryGetComponent<MeshCollider>(out MeshCollider blockMeshCollider))
        { 
            blockMeshCollider = chunkObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
        }
        
        
        blockMeshCollider.sharedMesh = colliderMesh;

        foreach (Transform side in chunkObject.transform)
        {
            GameObject.Destroy(side.gameObject);
        }

       
    }

    public void ChangeBlockType(Vector3 blockPosition, BlockType blockType)
    {
    //    Debug.Log();
        if (blockPosition.x >= World.chunkSize || blockPosition.x < 0 ||
            blockPosition.y >= World.chunkSize || blockPosition.y < 0 ||
            blockPosition.z >= World.chunkSize || blockPosition.z < 0)
        {
            return;
        }
      //  Debug.Log("test");
        Block block = chunkBlocks[(int) blockPosition.x, (int) blockPosition.y, (int) blockPosition.z];
        if (block.GetBlockType() == World.blockTypes[BlockType.Type.BEDROCK] ||
            block.GetBlockType() == World.blockTypes[BlockType.Type.WATER]) return;
        _sounds.DestroyBlockSound(block.GetBlockType().name.ToString());
        block.SetBlockType(blockType);
        RedrawChunk(World.chunkSize);
        if (blockPosition.x == 0) RedrawNeighbourChunk(new Vector3(-16,0));
        if (blockPosition.x == World.chunkSize - 1) RedrawNeighbourChunk(new Vector3(16, 0));
        if (blockPosition.y == 0) RedrawNeighbourChunk(new Vector3(0,-16));
        if (blockPosition.y == World.chunkSize - 1) RedrawNeighbourChunk(new Vector3(0, 16));
        if (blockPosition.z == 0) RedrawNeighbourChunk(new Vector3(0,0,-16));
        if (blockPosition.z == World.chunkSize - 1) RedrawNeighbourChunk(new Vector3(0, 0,16));
    }
    

    public BlockType.Type[,,] GetBlockTypes()
    {
        var arraySize = chunkBlocks.GetLength(0);
        var blockTypes = new BlockType.Type[arraySize, arraySize, arraySize];

        for (int i = 0; i < arraySize; i++)
        {
            for (int j = 0; j < arraySize; j++)
            {
                for (int k = 0; k < arraySize; k++)
                {
                    blockTypes[i, j, k] = chunkBlocks[i, j, k].GetBlockType().blockType;
                }
            }
        }

        return blockTypes;
    }
    /*public bool isShade(Vector3 pos)
    {
        int yPos = (int)pos.y + 1;

        int chunkDis = 5;

        while(yPos < World.chunkSize)
        {
            if (!chunkBlocks[(int)pos.x, yPos, (int)pos.z].GetBlockType().isTransparent)
                return true;
            yPos++;
        }
        yPos = (int)pos.y + 1;
        for (int i = 1; i < chunkDis; i++)
        {
            Chunk chunk;
            Vector3 chunkPos = (new Vector3(chunkObject.transform.position.x, chunkObject.transform.position.y + World.chunkSize * i, chunkObject.transform.position.z));
            string chunkName = World.GenerateChunkName(chunkPos);
            if (World.chunks.TryGetValue(chunkName, out chunk))
            {
                while (yPos < World.chunkSize)
                {
                    if (!chunkBlocks[(int)pos.x, yPos, (int)pos.z].GetBlockType().isTransparent)
                        return true;
                    yPos++;
                }
            }
        }
        return false;
    }*/
    void CalculateLight()
    {
        Queue<Vector3Int> litVoxels = new Queue<Vector3Int>();
        for (int x = 0; x < World.chunkSize; x++)
        {
            for (int z = 0; z < World.chunkSize; z++)
            {
                float lightRay = 1f;
                for (int y = World.chunkSize-1; y >= 0; y--)
                {
                    Block block = chunkBlocks[x,y,z];
                    block.globalLightPrecentage = lightRay;

                    if (block.GetBlockType()!=World.blockTypes[BlockType.Type.AIR]&& block.GetBlockType().trasparency<lightRay)
                    {
                        lightRay = block.GetBlockType().trasparency; 
                    }


                    chunkBlocks[x, y, z] = block;
                    if (lightRay > Block.lightFallof)
                    {
                        litVoxels.Enqueue(new Vector3Int(x, y, z));
                    }
                    

                }

            }
        }
        //Debug.Log(litVoxels.Count);
        while(litVoxels.Count > 0)
        {
            Vector3Int v = litVoxels.Dequeue();
            for (int p = 0; p < 6; p++)
            {
                Vector3 currentVoxel = v + Block.faceChecks[p];
                Vector3Int neighbor = new Vector3Int((int)currentVoxel.x, (int)currentVoxel.y, (int)currentVoxel.z);

                if(IsVoxelInChunk(neighbor.x,neighbor.y,neighbor.z))
                {
                    if(chunkBlocks[neighbor.x,neighbor.y,neighbor.z].globalLightPrecentage < chunkBlocks[v.x,v.y,v.z].globalLightPrecentage - Block.lightFallof)
                    {
                        chunkBlocks[neighbor.x, neighbor.y, neighbor.z].globalLightPrecentage = chunkBlocks[v.x, v.y, v.z].globalLightPrecentage - Block.lightFallof;
                        if (chunkBlocks[neighbor.x, neighbor.y, neighbor.z].globalLightPrecentage > Block.lightFallof)
                            litVoxels.Enqueue(neighbor);
                    }
                }
            }
        }
    }
    bool IsVoxelInChunk(int x, int y, int z)
    {

        if (x < 0 || x > World.chunkSize - 1 || y < 0 || y > World.chunkSize - 1 || z < 0 || z > World.chunkSize - 1)
            return false;
        else
            return true;

    }

}