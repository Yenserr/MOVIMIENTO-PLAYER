using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20.0f;
    private float spawnPosZ = 20.0f;
    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void SpawnRandomAnimal()
    {
        int side = Random.Range(0, 3); 
        Vector3 spawnPos = Vector3.zero;
        Quaternion rotation = Quaternion.identity;

        if (side == 0) 
        {
            spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            rotation = Quaternion.Euler(0, 180, 0); 
        }
        else if (side == 1) 
        {
            spawnPos = new Vector3(-spawnRangeX, 0, Random.Range(0, 15));
            rotation = Quaternion.Euler(0, 90, 0); 
        }
        else 
        {
            spawnPos = new Vector3(spawnRangeX, 0, Random.Range(0, 15));
            rotation = Quaternion.Euler(0, -90, 0); 
        }

        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos, rotation);
    }
}