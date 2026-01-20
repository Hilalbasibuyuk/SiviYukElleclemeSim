using UnityEngine;
using UnityEngine.UI;

public class TemperatureController : MonoBehaviour
{
    public Slider temperatureSlider;
    public TankController tank;

    void Start()
    {
        ApplyTemperature(temperatureSlider.value);
        temperatureSlider.onValueChanged.AddListener(ApplyTemperature);
    }

    void ApplyTemperature(float value)
    {
        tank.temperature = value;
    }
}
