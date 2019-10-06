using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float bombRange = 10;
    [SerializeField] float bombDepth = 10;
    [SerializeField] Texture2D cavityTexture;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider is TerrainCollider)
        {
            Terrain terrain = other.gameObject.GetComponent<Terrain>();
            TerrainData tData = terrain.terrainData;

            SetHeight(other, tData);
            SetAlpha(other, tData);
        }
        Destroy(gameObject);        
    }

    void SetHeight(Collision other, TerrainData tData)
    {
        Vector3 startPosition = other.GetContact(0).point - new Vector3(bombRange / 2, 0, bombRange / 2);
        int xBase = (int)Mathf.Round(startPosition.x / tData.size.x * tData.heightmapResolution);
        int yBase = (int)Mathf.Round(startPosition.z / tData.size.z * tData.heightmapResolution);
        int Range = (int)Mathf.Round(bombRange / tData.size.x * tData.heightmapResolution);
        float[,] hData = tData.GetHeights(xBase, yBase, Range, Range);

        for (int y = 0; y < hData.GetLength(0); y++)
        {
            for (int x = 0; x < hData.GetLength(1); x++)
            {
                int xTextureBase = (int)Mathf.Round(1.0f * x / hData.GetLength(1) * cavityTexture.width);
                int yTextureBase = (int)Mathf.Round(1.0f * y / hData.GetLength(0) * cavityTexture.height);
                Color grayTexture = cavityTexture.GetPixel(xTextureBase, yTextureBase);

                hData[y, x] -= bombDepth / tData.size.y * grayTexture.grayscale;
            }
        }
        tData.SetHeights(xBase, yBase, hData);
    }

    void SetAlpha(Collision other, TerrainData tData)
    {
        Vector3 StartPosition = other.GetContact(0).point - new Vector3(bombRange / 2, 0,bombRange / 2);
        int xBase = (int)Mathf.Round(StartPosition.x / tData.size.x * tData.alphamapResolution);
        int yBase = (int)Mathf.Round(StartPosition.z / tData.size.z * tData.alphamapResolution);
        int Range = (int)Mathf.Round(bombRange / tData.size.x * tData.alphamapResolution);
        float[,,] aData = tData.GetAlphamaps(xBase, yBase, Range, Range);

        for(int y = 0; y < aData.GetLength(0); y++)
        {
            for(int x = 0; x < aData.GetLength(1); x++)
            {
                int xTextureBase = (int)Mathf.Round(1.0f * x / aData.GetLength(1) * cavityTexture.width);
                int yTextureBase = (int)Mathf.Round(1.0f * y / aData.GetLength(0) * cavityTexture.height);
                Color grayTexture = cavityTexture.GetPixel(xTextureBase, yTextureBase);

                aData[y, x, 1] = grayTexture.grayscale;
                aData[y, x, 0] = 1 - grayTexture.grayscale;
            }
        }
        tData.SetAlphamaps(xBase, yBase, aData);
    }
}

