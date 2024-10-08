using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public GameObject coinPrefab;
    GroundSpawner groundSpawner;
    public GameObject obstaclePrefab;
    private coin Coin;
    [SerializeField] GameObject tallObstaclePrefab;
    [SerializeField] float spawnTallObstacleChance = 0.2f;

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        
        
    }
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.TileSpawn(true);
        Destroy(gameObject, 2);
    }

    public void SpawnObstacle()
    {
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        if(random < spawnTallObstacleChance)
        {
            obstacleToSpawn = tallObstaclePrefab;
        }


        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);

    }
   

    public void SpawnCoins()
    {
        int coinsToSpawn = 10;
        for (int i = 0; i < coinsToSpawn; i++)
        {
           GameObject temp =  Instantiate(coinPrefab, transform);
           temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }
        point.y = 1;
        return point;
    }


    
   
}
