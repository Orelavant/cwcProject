using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float startDelay = 2;
    public float repeatTime = 2;

    public GameObject food1;
    public GameObject food2;

    private float xBounds = 15f;
    private float yUpperBounds = 34f;
    private float yLowerBounds = 24f;

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
            Random.Range(yLowerBounds, yUpperBounds), -44f);

        Instantiate(food1, spawnRange, food1.transform.rotation);
        Instantiate(food2, spawnRange, food2.transform.rotation);
    }
}
