using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInRangeOfChest : MonoBehaviour
{
    public bool IsInPlayerInRange;

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Player"))
        {
            IsInPlayerInRange = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            IsInPlayerInRange = false;

        }
    }
}
