using System;
using UnityEngine;

public static class Utils
{
     // public static void AddControllerUtils<TUtil, TPlayer, TLogic>(
     //     TPlayer player,
     //     Action<TUtil, Grabber, ControllerHand> extraSetup = null)
     //     where TUtil : ControllerUtilBase
     //     where TPlayer : BasePlayer<TLogic>
     //     where TLogic : ILogic
     // {
     //     // Right hand
     //     var grabberR = player.rightController.GetComponentInChildren<Grabber>();
     //     var utilR = grabberR.gameObject.AddComponent<TUtil>();
     //     utilR.grabber = grabberR;
     //     extraSetup?.Invoke(utilR, grabberR, ControllerHand.Right);
     //
     //     // Left hand
     //     var grabberL = player.leftController.GetComponentInChildren<Grabber>();
     //     var utilL = grabberL.gameObject.AddComponent<TUtil>();
     //     utilL.grabber = grabberL;
     //     extraSetup?.Invoke(utilL, grabberL, ControllerHand.Left);
     // }
}
public interface IControllerUtilBuilder<TUtil, TPlayer, TLogic>
    where TUtil : ControllerUtilBase
    where TPlayer : BasePlayer<TLogic>
    where TLogic : ILogic
{
    IControllerUtilBuilder<TUtil, TPlayer, TLogic> WithSetup(Action<TUtil, Grabber, ControllerHand> setup);
    void Build();
}
public class ControllerUtilBuilder<TUtil, TPlayer, TLogic> : IControllerUtilBuilder<TUtil, TPlayer, TLogic>
    where TUtil : ControllerUtilBase
    where TPlayer : BasePlayer<TLogic>
    where TLogic : ILogic
{
    private readonly TPlayer _player;
    private Action<TUtil, Grabber, ControllerHand> _extraSetup;
    public ControllerUtilBuilder(TPlayer player)
    {
        _player = player;
    }
    public IControllerUtilBuilder<TUtil, TPlayer, TLogic> WithSetup(Action<TUtil, Grabber, ControllerHand> setup)
    {
        _extraSetup = setup;
        return this;
    }
    public void Build()
    {
        var grabberR = _player.rightController.GetComponentInChildren<Grabber>();
        var utilR = grabberR.gameObject.AddComponent<TUtil>();
        utilR.grabber = grabberR;
        _extraSetup?.Invoke(utilR, grabberR, ControllerHand.Right);
        
        var grabberL = _player.leftController.GetComponentInChildren<Grabber>();
        var utilL = grabberL.gameObject.AddComponent<TUtil>();
        utilL.grabber = grabberL;
        _extraSetup?.Invoke(utilL, grabberL, ControllerHand.Left);
    }
}