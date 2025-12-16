using UnityEngine;

public class AlarmPumpLinker : MonoBehaviour
{
    public LevelSensorController levelSensor;
    public PumpController pump;

    void Start()
    {
        if (levelSensor != null)
        {
            levelSensor.OnHighLevelAlarm += HandleHighLevelAlarm;
        }
    }

    void HandleHighLevelAlarm()
    {
        if (pump != null)
        {
            Debug.Log("🚨 Alarm geldi → Pompa durduruluyor");
            pump.StopPump();
        }
    }
}
