using System.Collections;
using UnityEngine;

public class tilesScript : MonoBehaviour
{
    public Transform tile;
    //tiles dimentions
    public int tilesAlongX;
    public int tilesAlongZ;
    public float widthOfTile;
    public float lengthOfTile;
    public float y; // zero in general for y-axis
    public float gap;
    Vector3 startPos;
    //tiles materials
    public Material[] materials;
    public int currentMaterial = 0;
    //functions
    void Start()
    {
        tilesStartPos();
        tilesGrid();
    }
    //tilesStartPos() defines starting position of the tiles
    void tilesStartPos()
    {
        startPos = Vector3.zero;
    }
    //tilesGrid() instantiating tiles
    void tilesGrid()
    {
        for (int x = 0; x < tilesAlongX; x++)
        {   
            for (int z = 0; z < tilesAlongZ; z++)
            {
                Transform grid = Instantiate(tile) as Transform;
                Vector3 gridPos = new Vector3(x, y, z);
                grid.position = CalcWorldPos(gridPos);
                grid.parent = this.transform;
                grid.name = "Tile " + x + " | " + z;
                grid.GetComponent<Renderer>().material = materials[currentMaterial];
                MaterialBoundry();
            }
            MaterialBoundry();
        }
    }
    //CalcWorldPos(Vector3 _gridPos) calculates position of each new tile
    Vector3 CalcWorldPos(Vector3 _gridPos)
    {
        float x = startPos.x + _gridPos.x * (widthOfTile + gap);
        float z = startPos.z + _gridPos.z * (lengthOfTile + gap);
        return new Vector3(x,y,z);
    }
    void MaterialBoundry()
    {
        currentMaterial++;
        currentMaterial = currentMaterial < materials.Length ? currentMaterial : 0;
    }
}
