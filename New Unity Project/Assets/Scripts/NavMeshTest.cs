using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshTest : MonoBehaviour
{

    GameObject Player;
    Vector3 position;
    NavMeshAgent agent;
    public Color debuglinecolor = Color.red;


    // Use this for initialization
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        agent.SetDestination(Player.transform.position);
	}

    private void OnDrawGizmos()
    {
        if(agent != null)
        {
            if(agent.pathStatus != NavMeshPathStatus.PathInvalid)
            {
                for (int i = 0; i < agent.path.corners.Length; i++)
                {
                    if(i + 1 < agent.path.corners.Length)
                    {
                        Gizmos.color = debuglinecolor;
                        Gizmos.DrawLine(agent.path.corners[i], agent.path.corners[i + 1]);
                        Debug.DrawLine(agent.path.corners[i], agent.path.corners[i + 1]);
                        //print("test");
                    }
                }
            }
        }
    }
}
