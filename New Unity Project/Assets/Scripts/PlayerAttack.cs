using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Weapon[] weapons;
    int ActiveWeaponindex = -1;
    Weapon ActiveWeapon;

	// Use this for initialization
	void Start ()
    {
        SetActiveWeapon(0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (ActiveWeapon != null)
        {
           if( Input.GetButtonDown("Fire1"))
            {
                ActiveWeapon.Fire(transform.position);
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetActiveWeapon(0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetActiveWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetActiveWeapon(2);
        }


    }


    private void HandleWeaponSwitching()
    {
        
    }

    void SetActiveWeapon(int index)
    {
        if(index != ActiveWeaponindex)
        {
            if(index >= 0 && index <= weapons.Length)
            {
                if (ActiveWeapon)
                    Destroy(ActiveWeapon.gameObject);

                ActiveWeapon = Instantiate(weapons[index], transform);
                ActiveWeaponindex = index;
            }
        }
    }
}
