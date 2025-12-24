using UnityEngine;
using System;

public class ValveController : MonoBehaviour
{
    [Header("Valve State")]
    [Range(0f, 1f)]
    public float openness = 1f;

    public bool isOpen = true;
    public TankController tank;
    public PumpController pump;

    public event Action<float> OnValveChanged;
    
    public event Action<float> OnFlowProduced;

    void Start()
    {
        NotifyTank();

        if (pump != null)
            pump.OnFlowProduced += OnPumpFlow;
    }
    public void OnSliderValueChanged(float value)
    {
        SetOpenness(value);
    }

    public float GetFlowMultiplier()
    {
        if (!isOpen)
            return 0f;

        return openness;
    }

    public void HandlePumpFlow(float pumpFlow)
    {
        float resultFlow = pumpFlow * openness;
        OnValveChanged?.Invoke(resultFlow);
    }

    public void SetOpenness(float value)
    {
        openness = Mathf.Clamp01(value);
        NotifyTank();
    }

    public void OpenValve()
    {
        isOpen = true;
        NotifyTank();
    }

    public void CloseValve()
    {
        isOpen = false;
        NotifyTank();
    }

    private void NotifyTank()
    {
        OnValveChanged?.Invoke(GetFlowMultiplier());
    }

    // public void OnPumpFlow(float pumpFlow)
    // {
    //     float finalFlow = pumpFlow * GetFlowMultiplier();
    //     tank.SetFlowFromValve(finalFlow);
    // }

    public void OnPumpFlow(float pumpFlow)
    {
        float finalFlow = isOpen ? pumpFlow * openness : 0f;
        OnValveChanged?.Invoke(finalFlow);
    }



    

}
