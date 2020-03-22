using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotation : MonoBehaviour
{

    private Vector3 rotateVector = Vector3.one;
    float x;
    float y;
    float z;

    // Start is called before the first frame update
    void Start()
    {
        CalculateRotationVector();
    }

    // Update is called once per frame
    void Update()
    {
        Rotateobject();
    }

    private void CalculateRotationVector()
    {
        x = Random.Range(-0.5f, 0.5f);
        y = Random.Range(-0.5f, 0.5f);
        z = Random.Range(-0.5f, 0.5f);

        rotateVector = new Vector3(x, y, z);
    }

    private void Rotateobject()
    {
        transform.Rotate(rotateVector,2f);
        
        //transform.eulerAngles += rotateVector;
    }
}
