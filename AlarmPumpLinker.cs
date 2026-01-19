using UnityEngine;

public class AlarmPumpLinker : MonoBehaviour
{
    public LevelSensorController levelSensor;
    public PumpController pump;
    public TransferController transfer;
    public ValveController valve;

    void Start()
    {
        if (levelSensor != null)
        {
            levelSensor.OnHighLevelAlarm += HandleHighLevelAlarm;
        }
    }

    void HandleHighLevelAlarm()
    {
        Debug.Log("🚨 ALARM LINKER ÇALIŞTI");
        if (pump != null && pump.targetTank != null)
        {
            pump.targetTank.SetInflow(0f);
            pump.targetTank.SetOutflow(0f);
        }

        if (transfer != null)
        {
            Debug.Log("🚨 Alarm → Transfer durduruluyor");
            transfer.StopTransfer();
        }
        
        if (valve != null)
        {
            Debug.Log("🚨 Alarm → Valve kapatılıyor");
            valve.CloseValve();
        }

    }
}
