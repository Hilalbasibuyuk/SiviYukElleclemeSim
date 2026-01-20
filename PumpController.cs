using UnityEngine;
using System;

public class PumpController : MonoBehaviour
{
    [Header("Pump State")]
    public bool isRunning = true;

    [Header("Pump Settings")]
    public float maxFlowRate = 1f; // %100 debi
    [Header("Protection")]
    public float minSafeFlow = 0.05f;



    public TankController targetTank;

    public TankController sourceTank;
    public PumpFault fault = PumpFault.None;


    public event Action<float> OnFlowProduced;

    void Update()
    {
        if (!isRunning)
        {
            OnFlowProduced?.Invoke(0f);
            return;
        }

        if (sourceTank != null && sourceTank.IsEmpty())
        {
            fault = PumpFault.DryRun;
            StopPump();
            Debug.Log("❌ Pump Dry Run");
            OnFlowProduced?.Invoke(0f);
            return;
        }

        float flow = maxFlowRate;
        OnFlowProduced?.Invoke(flow);

        float viscosity = sourceTank.GetViscosity();
        float adjustedFlow = maxFlowRate / viscosity;
        OnFlowProduced?.Invoke(adjustedFlow);

    }


    // void Update()
    // {
    //     float flow = isRunning ? maxFlowRate : 0f;
    //     if (targetTank != null)
    //         targetTank.SetInflow(flow);

    //     OnFlowProduced?.Invoke(flow);
    // }

    public enum PumpFault
    {
        None,
        DryRun,
        DeadHead
    }


    public void StartPump() => isRunning = true;
    public void StopPump() => isRunning = false;

    void LateUpdate()
    {
        if (!isRunning) return;

        // Valve kapalı → debi yok → dead head
        if (fault == PumpFault.None && maxFlowRate < minSafeFlow)
        {
            fault = PumpFault.DeadHead;
            Debug.Log("❌ DEAD HEAD → Pompa durduruldu");
            StopPump();
        }
    }

}
