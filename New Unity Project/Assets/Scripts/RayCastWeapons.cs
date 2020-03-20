using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapons : Weapon
{
    protected RaycastHit raycastHit;
    public float Range;
    public float DamagePerHit;
    protected Ray ray;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    protected void ApplyDamage(HealthComponent healthComponent)
    {
        healthComponent.ApplyDamage(DamagePerHit);
    }

    public void ShootRay(Vector3 Weaponpos, Vector3 direction)
    {
        ray = new Ray(Weaponpos, direction);
        Physics.Raycast(ray, out raycastHit);

        //if (Physics.Raycast(Weaponpos, transform.forward, out raycastHit, Range))
        //{
        //    HealthComponent health = raycastHit.collider.GetComponent<HealthComponent>();
        //}

        Debug.DrawRay(ray.origin, ray.direction * 15, Color.red,Mathf.Infinity);
    }
}
