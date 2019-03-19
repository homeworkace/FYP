using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public float spawnHeight = 10;
    public float timeBetweenSpawn = 1;
    public GameObject cubePrefab;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenSpawn)
        {
            timer = 0;
            GameObject spawnedGO = Instantiate(cubePrefab,transform.parent);
            Vector3 spawnPos = transform.position;
            spawnPos.y += spawnHeight;
            spawnedGO.transform.position = spawnPos;
        }
    }
}
