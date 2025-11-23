using UnityEngine;

public interface ILogic
{
    void Attach();
    void Detach();
}

public interface ITriageLogic : ILogic
{
    void PerformTriageAction();
}

public interface IEmsLogic : ILogic
{
    void PerformEmsAction();
}