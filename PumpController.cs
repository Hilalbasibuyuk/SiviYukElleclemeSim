using UnityEngine;
using System;

public class PumpController : MonoBehaviour
{
    [Header("Pump State")]
    public bool isRunning = true;

    [Header("Pump Settings")]
    public float maxFlowRate = 1f; // %100 debi

    public event Action<float> OnFlowProduced;

    void Update()
    {
        float flow = isRunning ? maxFlowRate : 0f;
        OnFlowProduced?.Invoke(flow);
    }

    public void StartPump() => isRunning = true;
    public void StopPump() => isRunning = false;
}
