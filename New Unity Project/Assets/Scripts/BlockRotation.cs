using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotation : MonoBehaviour
{

    private Vector3 rotateVector = Vector3.one;

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
        float x = Random.Range(-0.5f, 0.5f);
        float y = Random.Range(-0.5f, 0.5f);
        float z = Random.Range(-0.5f, 0.5f);

        rotateVector = new Vector3(x, y, z);
    }

    private void Rotateobject()
    {
        //transform.Rotate(Vector3.up,2f);
        transform.eulerAngles += rotateVector;
    }
}
