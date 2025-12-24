using UnityEngine;

public class FlowBinder : MonoBehaviour
{
    public ValveController valve;
    public TransferController transfer;

    public PumpController pump;

    void OnEnable()
    {
        pump.OnFlowProduced += valve.OnPumpFlow;
        valve.OnValveChanged += transfer.SetIncomingFlow;
    }

    void OnDisable()
    {
        pump.OnFlowProduced -= valve.OnPumpFlow;
        valve.OnValveChanged -= transfer.SetIncomingFlow;
    }

}
