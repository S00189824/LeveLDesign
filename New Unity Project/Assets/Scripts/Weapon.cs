using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public int MaxReserves;
    public int Reserves;

    public int MaxMagazine;
    public int Magazine;

    public int AmmoUsedPerShot;
    public bool IsAutomatic;

	// Use this for initialization
	void Start ()
    {
        Magazine = MaxMagazine;
        Reserves = MaxReserves;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public virtual void Fire(Vector3 FireFromPosition)
    {
        if(HasAmmo())
        {
            Magazine -= AmmoUsedPerShot;
        }
        else
        {
            Reload();
        }
    }

    public bool HasAmmo()
    {
        return Magazine >= AmmoUsedPerShot;
    }

    public void Reload()
    {

        if(Reserves >= MaxMagazine)
        {
            Magazine = MaxMagazine;
            Reserves -= MaxMagazine;
        }
        else if(Reserves > 0)
        {
            Magazine += Reserves;
            Reserves -= Reserves;
        }
        else
        {
            System.Console.WriteLine("no ammo");
        }

    }
}
