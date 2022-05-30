using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectables : MonoBehaviour
{

    public bool canSpawn = false;
    GameObject boat;
    public GameObject Collectable;

    public float spawnRadius = 0.5f;
    public Vector3 spawnPoint;

    float time = 1;
    float timer = 0; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canSpawn)
        {
            spawnPoint = boat.transform.position;
            spawnPoint.y += 0.5f;

            timer += Time.deltaTime;

            if(timer>time)
            {
                timer = 0;
                time = Random.RandomRange(0.5f, 2.0f);

                spawnPoint.x += Random.RandomRange(-spawnRadius, spawnRadius); 
                spawnPoint.z += Random.RandomRange(-spawnRadius, spawnRadius); 
                Instantiate(Collectable);
                Collectable.transform.position = spawnPoint;
            }
        }

    }
    public void startSpawing()
    {
        canSpawn=true;
        boat = GameObject.FindWithTag("Player");
        if(boat == null)
        {
            canSpawn=false;
            Debug.Log("boat not Found");
        }
    }
}
