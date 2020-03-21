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
    private GameObject CurrentObjectTaken;
    public float MaxForce;
    public float ThrowForce;
    public float MinForce;

    private Rigidbody objectRB;

    private Vector3 rotateVector = Vector3.one;
    public bool hasObject = false;

    // Start is called before the first frame update
    void Start()
    {
        ThrowForce = MinForce;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && hasObject)
        {
            ThrowForce += 0.1f;
            Shoot();
        }

        if(Input.GetMouseButton(1) && hasObject)
        {
            //Shoot();
            Debug.Log(ThrowForce);
        }
        if(hasObject)
        {
            
            Rotateobject();

            
        }
    }

    public float Distance()
    {
        float distance = Vector3.Distance(CurrentObjectTaken.transform.position, HoldDistance.transform.position);

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
        raycastHit.transform.parent = null;
        //CurrentObjectTaken = null;
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

            yield return null;
        }
        objectRB.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void Shoot()
    {
        ThrowForce = Mathf.Clamp(ThrowForce, MinForce, MaxForce);
        objectRB.AddForce(Cam.transform.forward * ThrowForce, ForceMode.Impulse);
        ThrowForce = MinForce;
        DropObject();
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
                StartCoroutine(MoveObjectToPos());
                //MoveObjToPosition();
                //CurrentObjectTaken = raycastHit.collider.gameObject;
                raycastHit.collider.transform.SetParent(HoldDistance);

                objectRB = raycastHit.collider.GetComponent<Rigidbody>();
                //objectRB.constraints = RigidbodyConstraints.FreezeAll;
                hasObject = true;

                CalculateRotationVector();
            }
        }
    }
}
