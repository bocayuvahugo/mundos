using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightMap : MonoBehaviour
{
    TerrainData terrainData;
    void Start()
    {
        this.gameObject.AddComponent<Terrain>();
        this.gameObject.AddComponent<TerrainCollider>();
        terrainData = new TerrainData();
        terrainData.size = new Vector3(0, 20, 100);
        terrainData.heightmapResolution = 512;
        terrainData.baseMapResolution = 2049;
        terrainData.SetDetailResolution(2048, 32);
        this.gameObject.GetComponent<Terrain>().terrainData = terrainData;
        this.gameObject.GetComponent<TerrainCollider>().terrainData = terrainData;

    }
}
