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

    [Header("Liquid Settings")]
    public LiquidType liquidType = LiquidType.Water;

    [Header("Thermal State")]
    public float temperature = 20f;



    [Header("Flow")]
    public float inflowRate = 0f;    // litre / saniye
    public float outflowRate = 0f;

    public event Action OnOverflow;
    public event Action OnUnderflow;

    public event System.Action<float> OnTemperatureChanged;




    private float currentFlowRate = 0f;

    private ILiquidBehavior liquidBehavior;


    // 🔔 EVENT
    public event Action<float> OnTankLevelChanged;

    void Start()
    {
        liquidLevel = Mathf.Clamp01(liquidLevel);
        InitializeLiquidBehavior();
    }


    void Update()
    {
        // ApplyCurrentFlow();

        if (liquidLevel >= 1f)
        {
            inflowRate = 0f;
            currentFlowRate = 0f;
        }

        if (liquidLevel <= 0f)
        {
            outflowRate = 0f;
        }

        if (liquidBehavior != null)
        {
            liquidBehavior.ApplyTemperature(temperature);
        }


        float modifiedInflow = inflowRate;

        if (liquidBehavior != null)
        {
            OnTemperatureChanged?.Invoke(temperature);

        }



        float netFlow = modifiedInflow - outflowRate;


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

    public void ApplyCurrentFlow()
    {
        // Valve veya Transfer’den gelen akış burada tanka işlenir
        SetInflow(currentFlowRate);
    }

    public void SetTemperature(float value)
    {
        temperature = value;
    }
    public float GetViscosity()
    {
        return liquidBehavior.GetViscosity(temperature);
    }




    void InitializeLiquidBehavior()
    {
        switch (liquidType)
        {
            case LiquidType.Water:
                liquidBehavior = new WaterBehavior();
                break;

            case LiquidType.Oil:
                liquidBehavior = new OilBehavior();
                break;

            case LiquidType.Chemical:
                liquidBehavior = new ChemicalBehavior();
                break;
        }

        liquidBehavior.ApplyTemperature(temperature);
    }

    void OnEnable()
    {
        SystemManager.Instance.OnSystemStateChanged += HandleSystemState;
    }

    void OnDisable()
    {
        SystemManager.Instance.OnSystemStateChanged -= HandleSystemState;
    }

    void HandleSystemState(SystemState state)
    {
        if (state != SystemState.Running)
        {
            SetInflow(0f);
            SetOutflow(0f);
        }
    }

}
