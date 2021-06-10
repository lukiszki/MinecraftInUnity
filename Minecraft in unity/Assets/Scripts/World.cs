using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class World : MonoBehaviour
{
    [Range(0f, 1f)]
    public float globalLightLevel;


    public Color day;
    public Color night;


    [SerializeField]
    private Camera camera;



    public Texture2D[] atlasTextures;
    public Texture2D[] atlasTransparentTextures;
    public Sprite[] icons;

    static Dictionary<string, Sprite> iconsDictionary = new Dictionary<string, Sprite>();
    public static Dictionary<string, Rect> atlasDictionary = new Dictionary<string, Rect>();
    public static Dictionary<string, Chunk> chunks = new Dictionary<string, Chunk>();
    public static Dictionary<string, Chunk> modChunks = new Dictionary<string, Chunk>();
    
    
    public static Queue<VoxelMod> modifications = new Queue<VoxelMod>();

    
    
    public int columnHeight = 16;
    public static int chunkSize = 16;
    public int worldRadius = 5;
    Material[] blockMaterial = new Material[2];


    GameObject player;
    Vector2 lastPlayerPosition;
    Vector2 currentPlayerPosition;
    private SaveManager _manager;


    public static Dictionary<BlockType.Type, BlockType> blockTypes = new Dictionary<BlockType.Type, BlockType>();
    // public float lightIntensity=1;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(false);
        UpdatePlayerPosition();
        _manager = GameObject.Find("GameManager").GetComponent<SaveManager>();


        Texture2D atlas = GetTextureAtlas();

        Material material = new Material(Shader.Find("Minecraft/Blocks"));
        atlas.filterMode = FilterMode.Point;
        material.mainTexture = atlas;
        /*material.SetTexture("_BaseColorMap", atlas);*/
        material.SetFloat("_Metallic", 0f);
        material.SetFloat("_Glossiness", 0f);
        blockMaterial[0] = material;

        Texture2D transparentAtlas = GetTextureAtlas(true);
        transparentAtlas.filterMode = FilterMode.Point;

        Material transparentMaterial = new Material(Shader.Find("Minecraft/Blocks"));
        transparentAtlas.alphaIsTransparency = true;
        //player.SetActive(false);

        transparentMaterial.mainTexture = transparentAtlas;
        blockMaterial[1] = transparentMaterial;

        GenerateBlockTypes();

    }

    void Start()
    {



       Application.targetFrameRate = 70;

        ChunkUtils.GenerateRandomOffset();

        StartCoroutine(GenerateWorld(false));
        StartCoroutine(BuildWorld(true));

    }
    private void Update()
    {
        if (player.activeInHierarchy)
           camera.backgroundColor = Color.Lerp(night, day, globalLightLevel);

        Shader.SetGlobalFloat("GlobalLightLevel", globalLightLevel);
        Shader.SetGlobalFloat("minGlobalLightLevel", Block.minLightLevel);
        Shader.SetGlobalFloat("maxGlobalLightLevel", Block.maxLightLevel);

        UpdatePlayerPosition();

        if (lastPlayerPosition != currentPlayerPosition)
        {
            lastPlayerPosition = currentPlayerPosition;
             
            StartCoroutine(GenerateWorld(true));
            StartCoroutine(BuildWorld(true));

        }

    }
    
    public void BuildBlock(string chunkName, Vector3 blockPosition, BlockType.Type blockType)
    {
        Chunk chunk;
        if(chunks.TryGetValue(chunkName, out chunk))
        {
            if(!modChunks.TryGetValue(chunkName, out Chunk f)) modChunks.Add(chunkName, chunk);
            chunk.ChangeBlockType(blockPosition, World.blockTypes[blockType]);
        }
    }

    public void DestroyBlock(string chunkName, Vector3 blockPosition)
    {
        Chunk chunk;
        if(chunks.TryGetValue(chunkName, out chunk))
        {
            if(!modChunks.TryGetValue(chunkName, out Chunk f)) modChunks.Add(chunkName, chunk);
            chunk.ChangeBlockType(blockPosition, World.blockTypes[BlockType.Type.AIR]);
        }

    }

    //funkcja generuje nazwe chunka
    public static string GenerateChunkName(Vector3 chunkPositon)
    {
        return chunkPositon.x + "_" + chunkPositon.y + "_" + chunkPositon.z;
    }

    //corutyna generuje kolumny chunkow
    IEnumerator BuildWorld(bool isAnimating)
    {
        foreach (Chunk chunk in chunks.Values.ToList())
        {
            if (chunk.status == Chunk.chunkStatus.TO_DRAW)
            {
                chunk.DrawChunk(chunkSize, isAnimating);
            }

            yield return null;
        }

        if (!player.activeInHierarchy)
        { 
            
            player.SetActive(true);


          

        }

    }
    IEnumerator GenerateWorld(bool isUpdating)
    {
        for (int z = -worldRadius + (int)currentPlayerPosition.y - 1; z <= worldRadius + (int)currentPlayerPosition.y + 1; z++)
        {
            for (int x = -worldRadius + (int)currentPlayerPosition.x - 1; x <= worldRadius + (int)currentPlayerPosition.x + 1; x++)
            {
                for (int y = 0; y < columnHeight; y++)
                {
                    Vector3 chunkPosition = new Vector3(x * chunkSize, y * chunkSize, z * chunkSize);
                    string chunkName = GenerateChunkName(chunkPosition);
                    Chunk chunk;

                    if (z == -worldRadius + (int)currentPlayerPosition.y - 1 || z == worldRadius + (int)currentPlayerPosition.y + 1
                                                                             || x == -worldRadius + (int)currentPlayerPosition.x - 1 || x == worldRadius + (int)currentPlayerPosition.x + 1)
                    {
                        if (chunks.TryGetValue(chunkName, out chunk))
                        {
                            chunk.status = Chunk.chunkStatus.GENERATED;
                            Destroy(chunk.chunkObject);
                        }
                        

                        continue;
                    }

                    if (chunks.TryGetValue(chunkName, out chunk))
                    {
                        if (chunk.status == Chunk.chunkStatus.GENERATED)
                        {
                            chunk.RefreshChunk(chunkName, chunkPosition);
                            chunk.chunkObject.transform.parent = this.transform;

                        }
                    }
                    else
                    {
                        chunk = new Chunk(chunkName, chunkPosition, blockMaterial);
                        chunk.chunkObject.transform.parent = this.transform;
                        chunks.Add(chunkName, chunk);

                    }
                   
                }
                if (isUpdating)
                    yield return null;
            }
        }
        if (modifications.Count > 0)
            ApplyModifications();
        yield return null;

        

    }

    public void GenerateLoadedWorld(List<ChunkData> chunksData)
    {
        StopAllCoroutines();
        foreach (ChunkData data in chunksData)
        {
            Debug.Log(data.Name);
        }
        chunks.Clear();
        lastPlayerPosition = Vector3.negativeInfinity;
        player.SetActive(false);

        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }

        for (int z = -worldRadius + (int)currentPlayerPosition.y - 1; z <= worldRadius + (int)currentPlayerPosition.y + 1; z++)
        {
            for (int x = -worldRadius + (int)currentPlayerPosition.x - 1; x <= worldRadius + (int)currentPlayerPosition.x + 1; x++)
            {
                for (int y = 0; y < columnHeight; y++)
                {
                    Vector3 chunkPosition = new Vector3(x * chunkSize, y * chunkSize, z * chunkSize);
                    string chunkName = GenerateChunkName(chunkPosition);
                    Chunk chunk;
                    ChunkData chunkData = chunksData.Find(i => i.Name == chunkName);

                    if (chunkData != null)
                    {
                        chunk = new Chunk(chunkName, chunkPosition, blockMaterial, chunkData.Blocks);
                        chunk.chunkObject.transform.parent = this.transform;
                        chunks.Add(chunkName, chunk);
                        
                    }
                }
            }
        }
        StartCoroutine(GenerateWorld(false));

    }

    void ApplyModifications()
    {

        int count = 0;
        while (modifications.Count > 0)
        {
            Chunk chunk;
            VoxelMod v = modifications.Dequeue();
            string chunkName = GenerateChunkName(v.chunkPos);

            if(chunks.TryGetValue(chunkName, out chunk))
            {
               
              //  chunk.ChangeBlockType(v.position,v.type);
                chunk.chunkBlocks[(int) v.position.x, (int) v.position.y, (int) v.position.z]  = new Block(v.type,chunk, v.position);
                //chunk.DrawChunk(chunkSize);
                chunk.status = Chunk.chunkStatus.TO_DRAW;
            }
           
          

        }
        StartCoroutine(GenerateWorld(true));



    }


    void GenerateBlockTypes()
    {
        BlockType air = new BlockType("air", true, true, true,1);
        air.sideUV = setBlockTypeUV();
        air.GenerateBlockUVs();
        blockTypes.Add(BlockType.Type.AIR,air);

        BlockType cave = new BlockType("cave", true, true, true,1);
        cave.sideUV = setBlockTypeUV();
        cave.GenerateBlockUVs();
        blockTypes.Add(BlockType.Type.CAVE, cave);

        BlockType dirt = new BlockType("dirt",false,false,true);
        dirt.sideUV = setBlockTypeUV("dirt");
        dirt.GenerateBlockUVs();
        dirt.icon = GetIcon("dirt");
        blockTypes.Add(BlockType.Type.DIRT, dirt);

        

        BlockType wooden = new BlockType("wooden", false, false, true);
        wooden.sideUV = setBlockTypeUV("wooden");
        wooden.GenerateBlockUVs();
        wooden.icon = GetIcon("wooden");
        blockTypes.Add(BlockType.Type.WOODEN, wooden);

        BlockType grass = new BlockType("grass", false, false, false);
        grass.topUV = setBlockTypeUV("grass");
        grass.sideUV = setBlockTypeUV("grass_side");
        grass.bottomUV = setBlockTypeUV("dirt");
        grass.icon = GetIcon("grass");
        grass.GenerateBlockUVs();
        wooden.icon = GetIcon("wooden");

        blockTypes.Add(BlockType.Type.GRASS, grass);

        BlockType stone = new BlockType("stone", false, false, true);
        stone.sideUV = setBlockTypeUV("stone");
        stone.GenerateBlockUVs();
        stone.icon = GetIcon("stone");
        blockTypes.Add(BlockType.Type.STONE, stone);


        BlockType coal_ore = new BlockType("coal_ore", false, false, true);
        coal_ore.sideUV = setBlockTypeUV("coal_ore");
        coal_ore.GenerateBlockUVs();
        coal_ore.icon = GetIcon("coal_ore");
        blockTypes.Add(BlockType.Type.COAL_ORE,coal_ore);

        BlockType diamond_ore = new BlockType("diamond_ore", false, false, true);
        diamond_ore.sideUV = setBlockTypeUV("diamond_ore");
        diamond_ore.GenerateBlockUVs();
        diamond_ore.icon = GetIcon("diamond_ore");
        blockTypes.Add(BlockType.Type.DIAMOND_ORE, diamond_ore);

        BlockType snow = new BlockType("snow", false, false, true);
        snow.sideUV = setBlockTypeUV("snow");
        snow.GenerateBlockUVs();
        snow.icon = GetIcon("snow");
        blockTypes.Add(BlockType.Type.SNOW, snow);

        BlockType sand = new BlockType("sand", false, false, true);
        sand.sideUV = setBlockTypeUV("sand");
        sand.GenerateBlockUVs();
        sand.icon = GetIcon("sand");
        blockTypes.Add(BlockType.Type.SAND, sand);

        BlockType glass = new BlockType("glass", false, true, true,0.8f);
        glass.sideUV = setBlockTypeUV("glass");
        glass.GenerateBlockUVs();
        glass.icon = GetIcon("glass");
        blockTypes.Add(BlockType.Type.GLASS, glass);

        BlockType bedrock = new BlockType("bedrock", false, false, true);
        bedrock.sideUV = setBlockTypeUV("bedrock");
        bedrock.GenerateBlockUVs();
        bedrock.icon = GetIcon("bedrock");
        blockTypes.Add(BlockType.Type.BEDROCK, bedrock);

        BlockType water = new BlockType("water", false, true, true,0.7f);
        water.sideUV = setBlockTypeUV("water");
        water.GenerateBlockUVs();
        blockTypes.Add(BlockType.Type.WATER, water);
        
        BlockType log_oak = new BlockType("log_oak", false, false, false);
        log_oak.topUV = setBlockTypeUV("log_oak");
        log_oak.sideUV = setBlockTypeUV("log_oak_side");
        log_oak.bottomUV = setBlockTypeUV("log_oak");
        log_oak.GenerateBlockUVs();
        log_oak.icon = GetIcon("log_oak");
        blockTypes.Add(BlockType.Type.LOG_OAK, log_oak);
        
        BlockType oak_leaves = new BlockType("oak_leaves", false, true, true, 0.75f);
        oak_leaves.sideUV = setBlockTypeUV("oak_leaves");
        oak_leaves.GenerateBlockUVs();
        oak_leaves.icon = GetIcon("oak_leaves");
        blockTypes.Add(BlockType.Type.OAK_LEAVES, oak_leaves);

    }
    Sprite GetIcon(string name)
    {
        foreach(Sprite icon in icons)
        {
            if (icon.name == name + "_icon")
                return icon;
        }
        return Sprite.Create(new Texture2D(16, 16), new Rect(-8, -8, 16, 16), new Vector2(0, 0)); 
    }

    Vector2[] setBlockTypeUV (string name = null)
    {
        if(name == null)
        {
            return new Vector2[4] {new Vector2(0f,0f),
                                    new Vector2(1f,0f),
                                    new Vector2(0f,1f),
                                    new Vector2(1f,1f)
                                                        };
        }
        return new Vector2[4]
            {
                new Vector2(atlasDictionary[name].x,
                            atlasDictionary[name].y),

                new Vector2(atlasDictionary[name].x+atlasDictionary[name].width,
                            atlasDictionary[name].y),

                new Vector2(atlasDictionary[name].x,
                            atlasDictionary[name].y+atlasDictionary[name].height),

                new Vector2(atlasDictionary[name].x+atlasDictionary[name].width,
                            atlasDictionary[name].y+atlasDictionary[name].height)
            };
    }

    //funkcja generuje atlas tekstor
    Texture2D GetTextureAtlas(bool transparent = false)
    {
        Texture2D[] usedAtlas = transparent ? this.atlasTransparentTextures : this.atlasTextures;
        Texture2D textureAtlas = new Texture2D(256, 256);
        Rect[] rectCoordinates = textureAtlas.PackTextures(usedAtlas, 0, 256, false);
        textureAtlas.Apply();
        for (int i = 0; i < rectCoordinates.Length; i++)
        {
            atlasDictionary.Add(usedAtlas[i].name.ToLower(), rectCoordinates[i]);
        }
        return textureAtlas;

    }
    private void UpdatePlayerPosition()
    {
        currentPlayerPosition.x = Mathf.Floor(player.transform.position.x / 16);
        currentPlayerPosition.y = Mathf.Floor(player.transform.position.z / 16);
    }
}

public class VoxelMod {

    public Vector3 position,chunkPos;
    public BlockType type;

    public VoxelMod () {

        position = new Vector3();
        type = World.blockTypes[BlockType.Type.AIR];

    }

    public VoxelMod (Vector3 _position, BlockType _type,Vector3 _chunkPos) {

        position = _position;
        chunkPos = _chunkPos;
        type = _type;

    }

}
