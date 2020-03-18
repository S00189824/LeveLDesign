using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OntriggerExit : MonoBehaviour
{

    EnemyMoveOnTrigger enemyTrigger;

    private void Start()
    {
        enemyTrigger = GetComponentInParent<EnemyMoveOnTrigger>();
    }

    public void OnTriggerEnter(Collider other)
    {

        //Debug.Log(other.tag);

        if (other.gameObject.CompareTag("Player"))
        {
            enemyTrigger.SetShouldMove(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.tag);

        if (other.gameObject.CompareTag("Player"))
        {
            enemyTrigger.SetShouldMove(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyTrigger.SetShouldMove(true);
        }
    }
}
