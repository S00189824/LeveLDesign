using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveOnTrigger : NavMeshMover
{
    public string tagToTrack = "Player";
    GameObject trackedPlayer;
    bool ShouldMove;

    public override void Start()
    {
        trackedPlayer = GameObject.FindGameObjectWithTag(tagToTrack);

        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
       
    } 

    public void SetShouldMove(bool value)
    {
        ShouldMove = value;

        if (trackedPlayer != null)
        {
            if (ShouldMove)
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
}
