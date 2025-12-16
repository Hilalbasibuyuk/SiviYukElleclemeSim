using UnityEngine;
using System;

public class LevelSensor : MonoBehaviour
{
    public TankController tank;
    public event Action<float> OnLevelMeasured;

    void Update()
    {
        OnLevelMeasured?.Invoke(tank.GetFillPercent());
    }
}
