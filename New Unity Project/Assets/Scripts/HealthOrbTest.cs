using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrbTest : MonoBehaviour
{
    float Health = 15f;
    Chest_test _Test;
    public float TotalHp = 100;
    public float currenthp = 0;

    // Start is called before the first frame update
    void Start()
    {
        _Test = GetComponent<Chest_test>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            currenthp += Health;

        }
    }
}
