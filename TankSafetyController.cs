using UnityEngine;


public class TankSafetyController : MonoBehaviour
{
    public TankController tank;
    public PumpController pump;

    void OnEnable()
    {
        tank.OnOverflow += HandleOverflow;
        tank.OnUnderflow += HandleUnderflow;
    }

    void OnDisable()
    {
        tank.OnOverflow -= HandleOverflow;
        tank.OnUnderflow -= HandleUnderflow;
    }

    void HandleOverflow()
    {
        Debug.Log("🚨 TANK OVERFLOW → Inflow kesiliyor");
        tank.SetInflow(0f);
    }

    void HandleUnderflow()
    {
        Debug.Log("🚨 TANK UNDERFLOW → Outflow kesiliyor");
        tank.SetOutflow(0f);

        if (pump != null)
            pump.StopPump();
    }
}
