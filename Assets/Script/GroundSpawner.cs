
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject GroundTile;
    Vector3 NextSpawnPoint;
    
   
    
    public void TileSpawn(bool spawnItems)
    {
        GameObject temp =  Instantiate(GroundTile, NextSpawnPoint, Quaternion.identity);
        NextSpawnPoint = temp.transform.GetChild(1).transform.position;
        

        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCoins();
            
        }
    }

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            if (i < 3)
            {
                TileSpawn(false);
            }
            else 
            {
                TileSpawn(true);

            }



        }

    }


}
