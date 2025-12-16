using UnityEngine;
using System;

public class TankController : MonoBehaviour
{
    [Header("Tank State")]
    [Range(0f, 1f)]
    public float liquidLevel = 0f;

    [Header("Flow Settings")]
    public float maxFillRate = 0.2f;

    private float currentFlowRate = 0f;

    // 🔔 EVENT
    public event Action<float> OnTankLevelChanged;

    void Update()
    {
        liquidLevel += currentFlowRate * maxFillRate* Time.deltaTime;
        liquidLevel = Mathf.Clamp01(liquidLevel);

        // 🔔 UI / başka sistemlere haber ver
        OnTankLevelChanged?.Invoke(liquidLevel);
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

    public float GetFillPercent()
    {
        return liquidLevel;
    }
}
