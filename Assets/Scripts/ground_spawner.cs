using System.Collections;
using UnityEngine;
using UnityEditor;


public class ground_spawner : MonoBehaviour
{
    [SerializeField] GameObject GroundTile;
    Vector3 nextspawnpoint;

    public void SpawnTile(bool spawnItems)
    {
        GameObject temp=  Instantiate(GroundTile,nextspawnpoint,Quaternion.identity);
        nextspawnpoint=temp.transform.GetChild(1).transform.position;
        if(spawnItems)
        {
            temp.GetComponent<ground_tile>().SpawnObstacle();
            temp.GetComponent <ground_tile>().SpawnCoins();
        }
    }
    private void Start()
    {
        for(int i = 0; i < 15; i++)
        {
            if (i < 3)
            {
                SpawnTile(false);
            }
            else
            {
                SpawnTile(true);
            }
            SpawnTile(true);
        }
        
    }

  
}
