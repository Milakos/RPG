using UnityEngine;

public class EmsLogic :  BaseLogic, IEmsLogic
{
    public void Attach() => UnityEngine.Debug.Log("EMS attached");
    public void Detach() => UnityEngine.Debug.Log("EMS detached");
    public void PerformEmsAction() => UnityEngine.Debug.Log("Performing EMS action");
}