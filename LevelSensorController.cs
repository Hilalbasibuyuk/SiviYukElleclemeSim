using UnityEngine;
using System;

public class LevelSensorController : MonoBehaviour
{
    [Header("Sensor Source")]
    public TankController tank;

    [Header("Sensor Output")]
    [Range(0f, 1f)]
    public float currentLevel;

    [Header("Alarm Settings")]
    public float highLevelThreshold = 0.9f;
    public bool alarmTriggered = false;

    public event Action OnHighLevelAlarm;



    public event Action<float> OnLevelChanged;

    void Update()
    {
        if (tank == null) return;

        currentLevel = tank.GetFillPercent();
        OnLevelChanged?.Invoke(currentLevel);

        if (currentLevel >= highLevelThreshold && !alarmTriggered)
        {
            alarmTriggered = true;
            Debug.Log("⚠️ HIGH LEVEL ALARM");

            OnHighLevelAlarm?.Invoke();
        }
    }

    

}
