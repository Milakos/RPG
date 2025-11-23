using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class ControllerUtilBase : MonoBehaviour
{
    public Grabber grabber;

}
public class TriageControllerUtil : ControllerUtilBase
{
    public TriagePlayer player;
}
public class EMSControllerUtil : ControllerUtilBase
{
    public EMSPlayer player;

    public HandController handGrabber;
    
}

