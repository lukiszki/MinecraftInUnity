
public class Tree 
{
    
    /*
     *SKRTYPT NIEAKTYWNY
     * 
     */
    
    
    /*private static List<Vector3> Trees = new List<Vector3>();
    //static Dictionary<Vector3, BlockType> treeType = new Dictionary<Vector3, BlockType>();
    public Vector3 position;

    private static List<Vector3> trunk = new List<Vector3>();
    private static List<Vector3> leaves = new List<Vector3>();


    static private BlockType[,,] treeBlocks;
    

    static private int leavesRadius = 2;
    
    
    
    static private int treeHeight = 10;

    public Tree(Vector3 BlockPos)
    {
        position = BlockPos;
        CreateTree(BlockPos);
    }

   /* void GenerateTree(Vector3 treePosition)
    {
        Vector3 leavesCenter = new Vector3(position.x, treeHeight + position.y, position.z);
        for (int x = (int)leavesCenter.x - leavesRadius; x <= (int)leavesCenter.x + leavesRadius; x++)
        {
            for (int y = (int) leavesCenter.y - leavesRadius; y <= (int) leavesCenter.y + leavesRadius; y++)
            {
                for (int z = (int) leavesCenter.z - leavesRadius; z <= (int) leavesCenter.z + leavesRadius; z++)
                {
                    Vector3 currentPosition = new Vector3(x, y, z); 
                    if ((int) Mathf.Round(Vector3.Distance(currentPosition, leavesCenter)) <= leavesRadius)
                    {
                        leaves.Add(new Vector3(x,y,z));
                    }
                }
            }
        }
        for (int y = (int)treePosition.y; y < treePosition.y + treeHeight; y++)
        {


            trunk.Add(new Vector3(position.x, y, position.z));




        }
        
    }

   public static BlockType GetTreeType(Vector3 BlockPos)
   {
       //if (Trees.Contains(BlockPos)) return World.blockTypes[BlockType.Type.LOG_OAK];
       int treeSize = treeHeight + leavesRadius*2;
       //Vector3 localPosition
       /*foreach (Vector3 treePos in Trees)
       {
           if (!(Vector3.Distance(treePos, BlockPos) < 10)) return World.blockTypes[BlockType.Type.AIR];
           for(int x = 0; x<treeSize-1; x++)
           {
               for (int y = 0; y < treeSize-1; y++)
               {
                   for (int z = 0; z < treeSize-1; z++)
                   {
                       if (BlockPos - new Vector3(x, y, z) == treePos) 
                           return treeBlocks[x, y, z];
                   }
               }
           }
       }
       
        return World.blockTypes[BlockType.Type.AIR];
   } 

    void CreateTree(Vector3 chunkPos)
    {
        
        Trees.Add(position);
    }

   static public void SetTreeValues()
    {
        int treeSize = treeHeight + leavesRadius*2;
        treeBlocks = new BlockType[treeSize, treeSize, treeSize];
        //setting all values to air
        for(int x = 0; x<treeSize-1; x++)
        {
            for (int y = 0; y < treeSize-1; y++)
            {
                for (int z = 0; z < treeSize-1; z++)
                {
                   treeBlocks[x, y, z] = World.blockTypes[BlockType.Type.AIR];
                }
            }
        }
        //trunk
        for (int y = 0; y < treeHeight; y++)
        {
            treeBlocks[leavesRadius,y,leavesRadius] = World.blockTypes[BlockType.Type.LOG_OAK];
        }*/
}
