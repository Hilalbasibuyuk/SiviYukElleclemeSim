using UnityEngine;
using UnityEngine.UI;

public class TemperatureUIController : MonoBehaviour
{
    public Slider slider;
    public TankController tank;

    void Start()
    {
        slider.onValueChanged.AddListener(OnTemperatureChanged);
    }

    void OnTemperatureChanged(float value)
    {
        tank.SetTemperature(value);
    }
}
