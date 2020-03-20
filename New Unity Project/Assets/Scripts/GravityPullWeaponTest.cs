using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPullWeaponTest : RayCastWeapons
{
    public float ImpulseAmount = 10;
    LayerMask objecttobepulled;
    public float pullableDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Fire(Vector3 FireFromPosition)
    {
        

        ShootRay(transform.position, transform.forward);

        

        if (Vector3.Distance(transform.position, raycastHit.collider.transform.position) <= pullableDistance)
        {
            if (raycastHit.collider.GetComponent<Rigidbody>())
            {
                raycastHit.collider.GetComponent<Rigidbody>().AddForce (ray.direction * ImpulseAmount,ForceMode.Impulse);
            }
        }
    }

    
}
