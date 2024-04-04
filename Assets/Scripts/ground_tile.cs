using UnityEditor;
using UnityEngine;

public class ground_tile : MonoBehaviour
{

    ground_spawner GroundSpawner;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject tallObstaclePreFab;
    [SerializeField] float tallobstacleChance = 0.2f;

    private void Start()
    {
        GroundSpawner = GameObject.FindObjectOfType<ground_spawner>();
        
    }
    private void OnTriggerExit(Collider other)
    {
        GroundSpawner.SpawnTile(true);
        Destroy(gameObject,2);
    }

   
    public void SpawnObstacle()
    {
        //choose which obstacle to spawn
        GameObject obstacletoSpawn = obstaclePrefab;
        float random=Random.Range(0f,1f);
        if(random < tallobstacleChance)
        {
            obstacletoSpawn = tallObstaclePreFab;
        }
        int obstacleSpawnIndex = Random.Range(2, 5); 
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstacletoSpawn, spawnPoint.position,Quaternion.identity,transform);
    }

    

    public void SpawnCoins()
    {
        int coinsToSpawn = 10;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab,transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
        Vector3 GetRandomPointInCollider(Collider collider)
        {
            Vector3 point = new Vector3(
                 Random.Range(collider.bounds.min.x, collider.bounds.max.x),
                 Random.Range(collider.bounds.min.y, collider.bounds.max.y),
                 Random.Range(collider.bounds.min.z, collider.bounds.max.z)
                );
            if(point != collider.ClosestPoint(point))
            {
                point = GetRandomPointInCollider(collider);
            }
            point.y = 1;
            return point;

                
        }

    }
}
