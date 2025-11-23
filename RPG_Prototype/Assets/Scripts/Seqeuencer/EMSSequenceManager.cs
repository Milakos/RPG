using UnityEngine;

public class EMSSequenceManager : SequencerManager<EMSPlayer, IEmsLogic>
{
    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _player.DoEMS();
        }
    }
    public override void RunSequence()
    {
        base.RunSequence();
        _player.DoEMS();
        Debug.Log("Running EMS sequence");
    }
}