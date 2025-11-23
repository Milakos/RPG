using UnityEngine;

public class TriageLogic : BaseLogic, ITriageLogic
{
    public void Attach() => UnityEngine.Debug.Log("Triage attached");
    public void Detach() => UnityEngine.Debug.Log("Triage detached");
    public void PerformTriageAction() => UnityEngine.Debug.Log("Performing triage action");
}
public class BaseLogic : MonoBehaviour { }