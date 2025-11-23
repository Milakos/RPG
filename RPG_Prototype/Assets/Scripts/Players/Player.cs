using UnityEngine;

public abstract class BasePlayer<TLogic> : MonoBehaviour where TLogic : ILogic
{
    public GameObject rightController;
    public GameObject leftController;
    private ControllerUtilBase controllerUtilBase;
    [HideInInspector] public BaseLogic _logic;
    protected TLogic Logic { get; set; }

    public BasePlayer(TLogic logic, ControllerUtilBase controllerUtil)
    {
        Logic = logic;
        controllerUtilBase = controllerUtil;
    }
    public virtual void Awake()
    {
        SetLogic(_logic);
        controllerUtilBase = FindAnyObjectByType<ControllerUtilBase>();
        Initialize();
    }
    public virtual void Initialize()
    {
        AddControllerUtils();
    }
    public virtual void OnAttach()
    {
        Logic?.Attach();
    }
    public virtual void OnDetach()
    {
        Logic?.Detach();
    }
    public virtual void SetLogic(BaseLogic genericLogic)
    {
        if(genericLogic != null)
            Logic = genericLogic.GetComponent<TLogic>();
    }
    public virtual void AddControllerUtils() { }
}


