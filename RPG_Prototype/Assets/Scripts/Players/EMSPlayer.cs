using System.Linq;
using UnityEngine;

public class EMSPlayer : BasePlayer<IEmsLogic>
{
    public EMSPlayer(IEmsLogic logic, ControllerUtilBase controllerUtilBase) : base(logic,  controllerUtilBase) { }
    public override void Awake()
    {
        base.Awake();
    }
    public override void Initialize()
    {
        base.Initialize();
    }
    public override void OnAttach()
    {
        base.OnAttach();
    }
    public override void OnDetach()
    {
        base.OnDetach();
    }
    public override void AddControllerUtils()
    {
        base.AddControllerUtils();
        
        new ControllerUtilBuilder<EMSControllerUtil, EMSPlayer, IEmsLogic>(this)
            .WithSetup((util, grabber, hand) =>
            {
                util.grabber = grabber;
                util.player = this;
                util.handGrabber = GetComponentsInChildren<HandController>()
                    .FirstOrDefault(h => h.grabber.handSide == hand);
            })
            .Build();
    }
    public override void SetLogic(BaseLogic genericLogic)
    {
        base.SetLogic(genericLogic);
        if (genericLogic == null)
        {
            var emsLogic = this.gameObject.AddComponent<EmsLogic>();
            _logic = emsLogic;
            Logic  = emsLogic.GetComponent<IEmsLogic>();
        }
    }
    public void DoEMS()
    {
        Logic?.PerformEmsAction();
    }
}