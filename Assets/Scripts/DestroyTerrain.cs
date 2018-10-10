using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTerrain : MonoBehaviour
{

    [SerializeField]
    private Terrain terrain;
    private TerrainData terrainData;
    private Vector3 grenadePos;
    private float[,] heights;
    private Rigidbody rb;
    private Vector3 force;
    private float speed;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
        if (terrain == null)
        {
            terrain = FindObjectOfType<Terrain>();
        }

        terrainData = terrain.terrainData;
    }
    private void Update()
    {
        StartCoroutine(Timer());
    }
    public void Destroy()
    {
        grenadePos = this.transform.position;

        heights = terrainData.GetHeights(0, 0, terrainData.heightmapWidth, terrainData.heightmapHeight);

        int terX = (int)((grenadePos.x / terrainData.size.x) * terrainData.heightmapWidth);
        int terZ = (int)((grenadePos.z / terrainData.size.z) * terrainData.heightmapHeight);
        float y = heights[terX, terZ];
        y = 0.0075f * grenadePos.y;
        float[,] height = new float[14, 14];
        for (int i = 0; i < 14; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                height[i, j] = y;
                Debug.Log(height);
            }
        }
        heights[terX, terZ] = y;
        terrainData.SetHeights(terX, terZ, height);
        Debug.Log(y);
        Destroy(gameObject);
    }
    
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2);
        Destroy();
    }
}

