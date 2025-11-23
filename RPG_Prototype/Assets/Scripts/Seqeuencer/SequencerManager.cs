using System;
using UnityEngine;

public abstract class SequencerManager<TPlayer, TLogic> : MonoBehaviour 
    where TPlayer : BasePlayer<TLogic> 
    where TLogic : ILogic
{
    protected TPlayer _player;

    public virtual void Awake()
    {
        if (_player == null)
            _player = FindAnyObjectByType<TPlayer>();

        RunSequence();
    }

    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _player.OnAttach();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _player.OnDetach();
        }
    }

    public virtual void RunSequence() { }

}