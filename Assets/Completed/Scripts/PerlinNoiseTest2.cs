using UnityEngine;
using System.Collections;

public class PerlinNoiseTest2 : MonoBehaviour
{
    public float power = 3.0f;
    public float scale = 1.0f;
    private Vector2 v2SampleStart = new Vector2(0f, 0f);

    MeshFilter mF;

    void Start()
    {
        mF = GetComponent<MeshFilter>();
        MakeSomeNoise();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            v2SampleStart = new Vector2(Random.Range(0.0f, 100.0f), Random.Range(0.0f, 100.0f));
            MakeSomeNoise();
        }
    }

    void MakeSomeNoise()
    {
        Vector3[] vertices = mF.mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            float xCoord = v2SampleStart.x + vertices[i].x * scale;
            float yCoord = v2SampleStart.y + vertices[i].z * scale;
            vertices[i].y = (Mathf.PerlinNoise(xCoord, yCoord) - 0.5f) * power;
        }
        mF.mesh.vertices = vertices;
        mF.mesh.RecalculateBounds();
        mF.mesh.RecalculateNormals();
    }
}

/*public class MYCLASSNAME : MonoBehaviour {
void  GenerateHeights ( Terrain terrain ,   float tileSizes  ){
    float[] heights = new [terrain.terrainData.heightmapWidth,terrain.terrainData.heightmapHeight];
    Debug.Log(terrain.terrainData.heightmapHeight);
        for (int i= 0; i < terrain.terrainData.heightmapWidth; i++)
        {
            for (int k= 0; k < terrain.terrainData.heightmapHeight; k++)
            {
                float iasfloat = i;
                float widthasfloat = terrain.terrainData.heightmapWidth;
                float heightasfloat = terrain.terrainData.heightmapHeight;
                heights[i] = Mathf.PerlinNoise((i / heightasfloat) * tileSizes, (k / widthasfloat) * tileSizes)/10.0ff;
            }
        }
        */