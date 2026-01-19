using UnityEngine;

public class LiquidController : MonoBehaviour
{
    public TankController tank;
    public float tankHeight = 1f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.localPosition;

        // 🔔 EVENT’E ABONE OL
        tank.OnTankLevelChanged += OnTankLevelChanged;
    }

    void OnDestroy()
    {
        tank.OnTankLevelChanged -= OnTankLevelChanged;
    }

    void OnTankLevelChanged(float fillPercent)
    {
        float liquidHeight = fillPercent * tankHeight;

        transform.localScale = new Vector3(
            transform.localScale.x,
            liquidHeight,
            transform.localScale.z
        );

        transform.localPosition = initialPosition;
    }
}
