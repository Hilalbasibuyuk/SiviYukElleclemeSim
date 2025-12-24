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


    void Update()
    {
        if (!isTransferring) return;
        // if (sourceTank == null || targetTank == null) return;

        // Güvenlik kontrolleri
        if (sourceTank.IsEmpty() || targetTank.IsFull())
        {
            StopTransfer();
            return;
        }

        // Kaynaktan çıkan
        sourceTank.SetOutflow(transferRate);

        // Hedefe giren
        targetTank.SetInflow(transferRate);
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
    }

}
