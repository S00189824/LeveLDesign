using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chest_test : MonoBehaviour
{
    [SerializeField]
    public List<ChestState> targetangles = new List<ChestState>();
    public Transform top;
    public float acceptLeeway = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChestState state = targetangles[0];
            top.transform.localRotation = Quaternion.Slerp(top.transform.localRotation, Quaternion.Euler(state.angle), state.speed * 0.5f * Time.deltaTime);
        }
    }

    public void OnMouseDown()
    {
        float dot = Vector3.Dot(transform.right.normalized, (Camera.main.transform.position - transform.position).normalized);
        if(targetangles != null && targetangles.Count > 0)
        {
            
            
            targetangles.Add(targetangles[0]);
            targetangles.RemoveAt(0);
        }
    }
}

public class ChestState
{
    public Vector3 angle;
    public float speed;
}
