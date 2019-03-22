using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    TerrainData theMap;
    float[,] heightMap;
    RaycastHit hit;
    Vector2 gradient;

    // Start is called before the first frame update
    void Start()
    {
        theMap = GetComponent<Terrain>().terrainData;
        heightMap = theMap.GetHeights(0, 0, theMap.heightmapWidth, theMap.heightmapHeight);
        heightMap[0, 0] = Random.value;
        gradient = new Vector2(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f));
        Vector2 pastLocation = new Vector2(Random.Range(0, theMap.heightmapWidth + Mathf.Epsilon), Random.Range(0, theMap.heightmapHeight + Mathf.Epsilon));
        for (short y = 0; y < theMap.heightmapHeight; ++y)
        {
            for (short x = 0; x < theMap.heightmapHeight; ++x)
            {
                /*if (x > 0 && y > 0)
                    heightMap[x, y] = (heightMap[x - 1, y] + gradient.x + heightMap[x, y - 1] + gradient.y) / 2;
                else if (x > 0)
                    heightMap[x, y] = heightMap[x - 1, y] + gradient.x;
                else if (y > 0)
                    heightMap[x, y] = heightMap[x, y - 1] + gradient.y;
                gradient = new Vector2(Mathf.Clamp(gradient.x + Random.Range(-0.001f, 0.001f), -0.01f, 0.01f), gradient.y);*/
                heightMap[x, y] = 0;
            }
            //gradient = new Vector2(gradient.x, Mathf.Clamp(gradient.y + Random.Range(-0.001f, 0.001f), -0.01f, 0.01f));
        }
        for (short i = 0; i < 1000; ++i)
        {
            Brush(new Vector4((short)pastLocation.x, (short)pastLocation.y, Random.Range(5, 20), Random.Range(10, 40)));
            Vector2 displacement = new Vector2(Random.Range(-Mathf.PI, Mathf.PI), Mathf.Pow(Random.Range(0, Mathf.Pow(theMap.heightmapHeight, 1.5f)), 0.33f));
            pastLocation = new Vector2(Mathf.Clamp(pastLocation.x + Mathf.Cos(displacement.x) * displacement.y, 0, theMap.heightmapWidth), Mathf.Clamp(pastLocation.y + Mathf.Sin(displacement.x) * displacement.y, 0, theMap.heightmapHeight));
        }
        theMap.SetHeights(0, 0, heightMap);
    }

    void Brush(Vector4 info)
    {
        short yStart = (short)(info.y - info.z - info.w), yEnd = (short)(info.y + info.z + info.w), xStart = (short)(info.x - info.z - info.w), xEnd = (short)(info.x + info.z + info.w);
        if (yStart < 0)
            yStart = 0;
        if (yEnd > theMap.heightmapHeight)
            yEnd = (short)theMap.heightmapHeight;
        if (xStart < 0)
            xStart = 0;
        if (xEnd > theMap.heightmapWidth)
            xEnd = (short)theMap.heightmapWidth;
        //loop through outer radius
        for (short y = yStart; y < yEnd; ++y)
            for (short x = xStart; x < xEnd; ++x)
            {
                Vector2 distance = new Vector2(x - info.x, y - info.y);
                if (distance.magnitude < info.z)
                    heightMap[x, y] += 0.05f;
                else if (distance.magnitude < info.z + info.w)
                    heightMap[x, y] += 0.05f - 0.05f * (distance.magnitude - info.z) / info.w;
            }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Mouse0))
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity)) // also consider a layermask to just the terrain layer
            {
                Vector3 distFromStart = hit.point - transform.TransformPoint(theMap.bounds.min);
                Debug.Log(heightMap[(int)(theMap.heightmapWidth * distFromStart.x / theMap.size.x), (int)(theMap.heightmapHeight * distFromStart.z / theMap.size.z)]);
            }*/
    }
}
