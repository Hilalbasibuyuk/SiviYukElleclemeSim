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
        if (!isTransferring) return;
        if (sourceTank == null || targetTank == null) return;

        // Güvenlik
        if (sourceTank.IsEmpty() || targetTank.IsFull())
        {
            StopTransfer();
            return;
        }

        // 1️⃣ Valf + pompadan gelen ham akış
        effectiveFlow = Mathf.Min(currentFlow, transferRate);

        // 2️⃣ FİZİK BURADA → TEK YER
        float viscosity = sourceTank.GetViscosity();
        effectiveFlow /= viscosity;

        // 3️⃣ KÜTLE KORUNUMU
        sourceTank.SetOutflow(effectiveFlow);
        targetTank.SetInflow(effectiveFlow);

        Debug.Log(
            $"TRANSFER | RAW: {currentFlow:F2} | VISC: {viscosity:F2} | FINAL: {effectiveFlow:F2}"
        );
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
