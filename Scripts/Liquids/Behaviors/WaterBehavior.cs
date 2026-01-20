using UnityEngine;

public class WaterBehavior : ILiquidBehavior
{
    public float Density => 1.0f;     // referans
    public float Viscosity => 1.0f;   // düşük

    public float ModifyFlow(float baseFlow)
    {
        // Su → akışı fazla kısıtlama
        return baseFlow / Viscosity;
    }

    public void ApplyTemperature(float temperature)
    {
        // Su için şimdilik etkisiz
    }

    public float GetViscosity(float temperature)
    {
        return Mathf.Lerp(1.2f, 0.8f, temperature / 100f);
    }

}
