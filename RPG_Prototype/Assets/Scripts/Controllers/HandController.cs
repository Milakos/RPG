using System;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [HideInInspector] public Grabber grabber;

    private void Awake()
    {
        grabber = GetComponent<Grabber>();
    }
}