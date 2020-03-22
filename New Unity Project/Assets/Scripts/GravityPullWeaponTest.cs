using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPullWeaponTest : RayCastWeapons
{
    public float ImpulseAmount = 10;
    public float pullableDistance;
    public Camera Cam;
    public Transform HoldDistance;
    public float AttractSpeed;
    public float MaxForce;
    public float ThrowForce;
    public float MinForce;
    private GameObject IsObjectUsed;

    private Rigidbody objectRB;

    private Vector3 rotateVector = Vector3.one;
    public bool hasObject = false;

    void Start()
    {
        ThrowForce = MinForce;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && hasObject)
        {
            
            Shoot();
            hasObject = false;
        }
        
    }

    public float Distance()
    {
        float distance = Vector3.Distance(raycastHit.transform.position, HoldDistance.transform.position);

        return distance;
    }

    private void CalculateRotationVector()
    {
        float x = Random.Range(0.5f, 0.5f);
        float y = Random.Range(-0.5f, 0.5f);
        float z = Random.Range(-0.5f, 0.5f);

        rotateVector = new Vector3(x, y, z);
    }

    private void Rotateobject()
    {
        raycastHit.transform.Rotate(rotateVector);
    }

    private void DropObject()
    {
        objectRB.constraints = RigidbodyConstraints.None;
        //raycastHit.transform.parent = null;
        hasObject = false;
    }

    IEnumerator MoveObjectToPos()
    {
        float Interpolation = 0;
        
        //Debug.Log(transform.position);
        while(Interpolation <= 1 && HoldDistance.position != raycastHit.collider.transform.position)
        {
            raycastHit.collider.transform.position = Vector3.Lerp(raycastHit.collider.transform.position, HoldDistance.position, Interpolation);
            Interpolation += AttractSpeed * Time.deltaTime;

            print(Interpolation);

            yield return null;
        }
        objectRB.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void Shoot()
    {
        DropObject();
        IsObjectUsed.transform.SetParent(null);
        //ThrowForce = Mathf.Clamp(ThrowForce, MinForce, MaxForce);
        objectRB.AddForce(transform.forward * ThrowForce, ForceMode.Impulse);
        Debug.Log(Cam.transform.forward * ThrowForce);
        ThrowForce = MinForce;
        objectRB.useGravity = true;
        
    }

    public override void Fire(Vector3 FireFromPosition)
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 15, Color.red, Mathf.Infinity);
        //Debug.Log(HoldDistance.position);
        //ray = Cam.ScreenPointToRay(Input.mousePosition);

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
        if (Physics.Raycast(ray,out raycastHit,pullableDistance))
        {
            if(raycastHit.collider.CompareTag("Block"))
            {
                IsObjectUsed = raycastHit.collider.gameObject;

                StartCoroutine(MoveObjectToPos());
                //MoveObjToPosition();
                //CurrentObjectTaken = raycastHit.collider.gameObject;
                raycastHit.collider.transform.SetParent(HoldDistance);

                objectRB = raycastHit.collider.GetComponent<Rigidbody>();
                //objectRB.constraints = RigidbodyConstraints.FreezeAll;
                hasObject = true;

                

                
            }
        }
    }
}
