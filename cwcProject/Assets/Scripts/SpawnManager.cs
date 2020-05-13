using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float startDelay = 2;
    public float repeatTime = 2;

    public GameObject[] food;

    private float xBounds = 15f;
    private float yUpperBounds = 16f;
    private float yLowerBounds = 6f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFood", startDelay, repeatTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnFood() {
        Vector3 spawnRange = new Vector3(Random.Range(-xBounds, xBounds), 
            Random.Range(yLowerBounds, yUpperBounds), -0.6f);
        int randInt = Random.Range(0, food.Length);

        Instantiate(food[randInt], spawnRange, food[randInt].transform.rotation);
    }
}
