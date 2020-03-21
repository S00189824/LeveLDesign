using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPullWeaponTest : RayCastWeapons
{
    public float ImpulseAmount = 10;
    LayerMask objecttobepulled;
    public float pullableDistance;
    public Camera Cam;
    public Transform HoldDistance;
    public float AttractSpeed;
    private GameObject CurrentObjectTaken;
    public float MaxForce;
    public float ThrowForce;
    public float MinForce;

    private Rigidbody objectRB;

    private Vector3 rotateVector = Vector3.one;
    private bool hasObject = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float Distance()
    {
        float distance = Vector3.Distance(CurrentObjectTaken.transform.position, HoldDistance.transform.position);

        return distance;
    }

    private void MoveObjToPosition()
    {
        CurrentObjectTaken.transform.position = Vector3.Lerp(CurrentObjectTaken.transform.position, HoldDistance.position, AttractSpeed * Time.deltaTime);
    }

    private void DropObject()
    {
        objectRB.constraints = RigidbodyConstraints.None;
        CurrentObjectTaken.transform.parent = null;
        CurrentObjectTaken = null;
        hasObject = false;
    }

    private void Shoot()
    {
        ThrowForce = Mathf.Clamp(ThrowForce, MinForce, MaxForce);
        objectRB.AddForce(Cam.transform.forward * ThrowForce, ForceMode.Impulse);
        ThrowForce = MinForce;
        DropObject();
    }

    public override void Fire(Vector3 FireFromPosition)
    {
        ShootRay(transform.position, transform.forward);
       
        ray = Cam.ScreenPointToRay(Input.mousePosition);

        //if (raycastHit.collider.CompareTag("Block"))
        //{
        //    if (Vector3.Distance(transform.position, raycastHit.collider.transform.position) <= pullableDistance)
        //    {
        //        if (raycastHit.collider.GetComponent<Rigidbody>())
        //        {
        //            raycastHit.collider.GetComponent<Rigidbody>().AddForce(ray.direction * ImpulseAmount, ForceMode.Impulse);
        //        }
        //    }

        //}


        if(Physics.Raycast(ray,out raycastHit,pullableDistance))
        {
            if(raycastHit.collider.CompareTag("Block"))
            {
                CurrentObjectTaken = raycastHit.collider.gameObject;
                CurrentObjectTaken.transform.SetParent(HoldDistance);

                objectRB = CurrentObjectTaken.GetComponent<Rigidbody>();
                objectRB.constraints = RigidbodyConstraints.FreezeAll;

                hasObject = true;
            }
        }
    }

    
}
