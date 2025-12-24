using UnityEngine;
using System;

public class TankController : MonoBehaviour
{
    [Header("Tank State")]
    [Range(0f, 1f)]
    public float liquidLevel = 0f;

    [Header("Capacity Settings")]
    public float capacity = 100f;

    [Header("Flow Settings")]
    public float maxFillRate = 0.2f;

    [Header("Flow")]
    public float inflowRate = 0f;    // litre / saniye
    public float outflowRate = 0f;

    public event Action OnOverflow;
    public event Action OnUnderflow;


    private float currentFlowRate = 0f;

    // 🔔 EVENT
    public event Action<float> OnTankLevelChanged;

    

    void Update()
    {

        float netFlow = inflowRate - outflowRate;

        liquidLevel += (netFlow / capacity) * Time.deltaTime;
        liquidLevel = Mathf.Clamp01(liquidLevel);

        // 🔔 UI / başka sistemlere haber ver
        OnTankLevelChanged?.Invoke(liquidLevel);
        Debug.Log($"INFLOW: {inflowRate} | OUTFLOW: {outflowRate}");

        if (liquidLevel >= 1f)
        OnOverflow?.Invoke();

    if (liquidLevel <= 0f)
        OnUnderflow?.Invoke();


    }

    // Valve burayı çağırıyor (AYNI)
    public void SetFlowFromValve(float valveMultiplier)
    {
        currentFlowRate = valveMultiplier * maxFillRate;
    }

    public void ReceiveFlow(float flow)
    {
        currentFlowRate = flow;
    }
    public void ApplyFlow(float flow)
    {
        SetInflow(flow);
    }

    public void SetInflow(float value)
    {
        inflowRate = Mathf.Max(0f, value);
    }

    public void SetOutflow(float value)
    {
        outflowRate = Mathf.Max(0f, value);
    }

    public float GetFillPercent()
    {
        return liquidLevel;
    }

    public bool IsEmpty()
    {
        return liquidLevel <= 0f;
    }

    public bool IsFull()
    {
        return liquidLevel >= 1f;
    }
}
