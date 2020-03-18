using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject enemies;
    public float ElaspedTime = 0;
    public float SpawnTime = 4;
    Vector3 position;
    BoxCollider SpawnArea;
    public int enemyCounter;
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnArea = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCounter = GameObject.FindGameObjectsWithTag("enemy").Length;
        Spawner4Enemies();
    }

    public Vector3 RandomPosition()
    {
        float x = Random.Range(SpawnArea.bounds.min.x,SpawnArea.bounds.max.x);// getting random position of x in spawn area
        float y = Random.Range(SpawnArea.bounds.min.y,SpawnArea.bounds.max.y);
        float z = Random.Range(SpawnArea.bounds.min.z,SpawnArea.bounds.max.z);


        

        return new Vector3(x,y,z);
    }

    public void Spawner4Enemies()
    {
        
        ElaspedTime += Time.deltaTime;      //timer
        if (ElaspedTime > SpawnTime)
        {
            Instantiate(enemies, RandomPosition(), Quaternion.identity);
            ElaspedTime = 0;
        }
        else if(enemyCounter >= 5)
        {

            enemyCounter = 0;
            
        }
    }
}
