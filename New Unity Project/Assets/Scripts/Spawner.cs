using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject enemies;
    public float Starttime = 0;
    public float EndTime = 4;
    Vector3 position;
    BoxCollider SpawnArea;
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnArea = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(enemies,RandomPosition(),Quaternion.identity);
    }

    public Vector3 RandomPosition()
    {
        float x = Random.Range(SpawnArea.bounds.min.x,SpawnArea.bounds.max.x);// getting random position of x in spawn area
        float y = Random.Range(SpawnArea.bounds.min.y,SpawnArea.bounds.max.y);
        float z = Random.Range(SpawnArea.bounds.min.z,SpawnArea.bounds.max.z);


        

        return new Vector3(x,y,z);
    }
}
