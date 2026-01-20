using UnityEngine;
using TMPro;

public class SystemUIController : MonoBehaviour
{
    [Header("Tanks")]
    public TankController tankA;
    public TankController tankB;

    [Header("System")]
    public SystemManager systemManager;

    [Header("Pump")]
    public PumpController pump;

    [Header("UI Texts")]
    public TextMeshProUGUI tankAText;
    public TextMeshProUGUI tankBText;
    public TextMeshProUGUI tankATempText;
    public TextMeshProUGUI tankBTempText;
    public TextMeshProUGUI pumpFlowText;
    public TextMeshProUGUI systemStateText;

    void OnEnable()
    {
        // Tank level
        tankA.OnTankLevelChanged += UpdateTankALevel;
        tankB.OnTankLevelChanged += UpdateTankBLevel;

        // Temperature
        tankA.OnTemperatureChanged += UpdateTankATemp;
        tankB.OnTemperatureChanged += UpdateTankBTemp;

        // Flow
        pump.OnFlowRateChanged += UpdateFlowRate;

        // System state
        systemManager.OnSystemStateChanged += UpdateSystemState;
    }

    void OnDisable()
    {
        tankA.OnTankLevelChanged -= UpdateTankALevel;
        tankB.OnTankLevelChanged -= UpdateTankBLevel;

        tankA.OnTemperatureChanged -= UpdateTankATemp;
        tankB.OnTemperatureChanged -= UpdateTankBTemp;

        pump.OnFlowRateChanged -= UpdateFlowRate;

        systemManager.OnSystemStateChanged -= UpdateSystemState;
    }

    void UpdateTankALevel(float level)
    {
        tankAText.text = $"Tank A Level: {(level * 100f):F1}%";
    }

    void UpdateTankBLevel(float level)
    {
        tankBText.text = $"Tank B Level: {(level * 100f):F1}%";
    }

    void UpdateTankATemp(float temp)
    {
        tankATempText.text = $"Tank A Temp: {temp:F1} °C";
    }

    void UpdateTankBTemp(float temp)
    {
        tankBTempText.text = $"Tank B Temp: {temp:F1} °C";
    }

    void UpdateFlowRate(float flow)
    {
        pumpFlowText.text = $"Flow Rate: {flow:F2}";
    }

    void UpdateSystemState(SystemState state)
    {
        systemStateText.text = $"System State: {state}";
    }
}
