using UnityEngine;

public class TransferController : MonoBehaviour
{
    [Header("Tanks")]
    public TankController sourceTank;
    public TankController targetTank;

    [Header("Transfer Settings")]
    public float transferRate = 10f; // litre / saniye
    public bool isTransferring = true;
    private float currentFlow;
    private float effectiveFlow;

    [Header("Future Multi Tank")]
    public TankController[] sourceTanks;
    public TankController[] targetTanks;



    void Update()
    {
        Debug.Log($"VALVE FLOW → {currentFlow} | EFFECTIVE → {effectiveFlow}");
        Debug.Log($"TRANSFER → Source: {sourceTank.name} | Target: {targetTank.name}");

        if (!isTransferring) return;
        // if (sourceTank == null || targetTank == null) return;

        // Güvenlik kontrolleri
        if (sourceTank.IsEmpty() || targetTank.IsFull())
        {
            StopTransfer();
            return;
        }

        effectiveFlow = Mathf.Min(currentFlow, transferRate);

        sourceTank.SetOutflow(effectiveFlow);
        targetTank.SetInflow(effectiveFlow);

        



        // Kaynaktan çıkan
        // sourceTank.SetOutflow(transferRate);

        // // Hedefe giren
        // targetTank.SetInflow(transferRate);
    }

    public void StopTransfer()
    {
        isTransferring = false;

        sourceTank.SetOutflow(0f);
        targetTank.SetInflow(0f);
    }

    public void SetIncomingFlow(float flow)
    {
        currentFlow = flow;
        Debug.Log("TRANSFER FLOW SET: " + flow);
    }

}
