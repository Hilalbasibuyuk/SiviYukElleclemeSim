using TMPro;
using UnityEngine;

public class DebugUIController : MonoBehaviour
{
    public TextMeshProUGUI debugText;
    public TankController tank;
    public LevelSensorController levelSensor;

    void Update()
    {

        debugText.text =
            "Liquid Level: " + (tank.liquidLevel * 100f).ToString("F1") + "%";

        if (levelSensor == null) return;

        debugText.text =
            "Tank Level: " +
            (levelSensor.currentLevel * 100f).ToString("F1") + "%";
    }
}
