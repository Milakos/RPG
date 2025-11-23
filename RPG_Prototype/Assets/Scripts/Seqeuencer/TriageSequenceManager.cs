using System;
using UnityEngine;

public class TriageSequenceManager : SequencerManager<TriagePlayer, ITriageLogic>
{
    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _player.DoTriage();
        }
    }

    public override void RunSequence()
    {
        base.RunSequence();
        Debug.Log("Running Triage sequence");
    }
    
}