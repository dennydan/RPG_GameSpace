using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] Terrain terrain;
    [SerializeField] TerrainCollider terrainCollider;
    
    void OnTriggerEnter(Collider other)
    {
        terrain.enabled = false;
        Physics.IgnoreCollision(terrainCollider, other, true);
    }

    void OnTriggerStay(Collider other)
    {
        if (Vector3.Angle(transform.forward, other.transform.forward) > 90.0f)
            terrain.enabled = false;
        else
            terrain.enabled = true;
    }

    void OnTriggerExit(Collider other)
    {
        terrain.enabled = true;
        Physics.IgnoreCollision(terrainCollider, other, false);
    }
}
