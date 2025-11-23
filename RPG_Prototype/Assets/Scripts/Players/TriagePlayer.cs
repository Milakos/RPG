using UnityEngine;

public class TriagePlayer : BasePlayer<ITriageLogic>
{
    public TriagePlayer(ITriageLogic logic, TriageControllerUtil controllerUtilBase) 
        : base(logic, controllerUtilBase) { }
    
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
    public override void SetLogic(BaseLogic genericLogic)
    {
        base.SetLogic(genericLogic);
        if (genericLogic == null)
        {
            var triageLogic = this.gameObject.AddComponent<TriageLogic>();
            _logic = triageLogic;
            Logic  = triageLogic.GetComponent<ITriageLogic>();
        }
    }
    public override void AddControllerUtils()
    {
        base.AddControllerUtils();
        IControllerUtilBuilder<TriageControllerUtil, TriagePlayer, ITriageLogic> builder =
            new ControllerUtilBuilder<TriageControllerUtil, TriagePlayer, ITriageLogic>(this);

        builder.WithSetup((util, grabber, hand) =>
            {
                util.grabber = grabber;
                util.player = this;
            })
            .Build();

        Debug.Log($"{GetType().Name} using {typeof(ITriageLogic).Name} On AddControllerUtils");
    }
    public void DoTriage()
    {
        Logic?.PerformTriageAction();
    }
}
