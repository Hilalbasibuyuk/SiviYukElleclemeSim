using UnityEngine;

public class FlowBinder : MonoBehaviour
{
    public ValveController valve;
    public TankController tank;

    void OnEnable()
    {
        valve.OnValveChanged += tank.SetFlowFromValve;
    }

    void OnDisable()
    {
        valve.OnValveChanged -= tank.SetFlowFromValve;
    }
}
