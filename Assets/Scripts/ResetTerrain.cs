using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTerrain : MonoBehaviour
{
    [SerializeField] Terrain terrain;

    float[,] hData;
    float[,,] aData;
    // Start is called before the first frame update
    void Start()
    {
        // Data register
        hData = terrain.terrainData.GetHeights(0, 0,
            terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution);
        aData = terrain.terrainData.GetAlphamaps(0, 0,
            terrain.terrainData.alphamapResolution, terrain.terrainData.alphamapResolution);
    }
    
    void OnDestroy()
    {
        terrain.terrainData.SetHeights(0, 0, hData);
        terrain.terrainData.SetAlphamaps(0, 0, aData);
    }
}
