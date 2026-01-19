using UnityEngine;


public class ChemicalBehavior : ILiquidBehavior
{
    private float viscosity = 2.0f;

    public float Density => 1.2f;
    public float Viscosity => viscosity;

    public float ModifyFlow(float baseFlow)
    {
        return baseFlow / viscosity;
    }

    public void ApplyTemperature(float temperature)
    {
        // Kimyasal sıcaklığa çok duyarlı
        viscosity = Mathf.Clamp(3.0f - temperature * 0.05f, 0.5f, 3.0f);
    }
}
