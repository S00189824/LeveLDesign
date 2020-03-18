using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveWithinDistance : NavMeshMover
{
    public string tagToTrack = "Player";
    GameObject trackedPlayer;
    public float TrackingDistance = 4;

    public override void Start()
    {
        trackedPlayer = GameObject.FindGameObjectWithTag(tagToTrack);

        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (trackedPlayer != null)// Note to self -> if using this for multiple ememies i will need to implement this a different way instead of having to much in the update
        {
            if (Vector3.Distance(transform.position, trackedPlayer.transform.position) <= TrackingDistance)
            {
                Resume();
                MoveTo(trackedPlayer);
            }
            else
            {
                MoveTo(transform.position);
                Stop();
            }
        }
    }

    public override void OnDrawGizmos()
    {
        Gizmos.color = DebugLineColor;
        Gizmos.DrawWireSphere(transform.position, TrackingDistance);
        base.OnDrawGizmos();
    }
}
