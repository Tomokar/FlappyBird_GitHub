using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int poolSize = 5;

    public GameObject prefab;

    public float spawnRate = 4f;

    public float columnMin = -1f;

    public float columnMax = 3.5f;

    private GameObject[] columns;

    private Vector2 objPosition = new Vector2(-15, -25);

    private float lastSpawn;

    private float spawnX = 10f;

    private int currentColumn = 0;

    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(prefab, objPosition, Quaternion.identity);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        lastSpawn += Time.deltaTime;

        if (GameControl.instance.gameOver == false && lastSpawn >= spawnRate)
        {
            lastSpawn = 0;
            float spawnY = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnX, spawnY);
            currentColumn++;

            if (currentColumn >= poolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
