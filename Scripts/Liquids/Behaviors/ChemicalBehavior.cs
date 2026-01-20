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

    public float GetViscosity(float temperature)
    {
        // Kimyasal sıvı: sıcaklığa daha agresif tepki verir
        return Mathf.Clamp(3.5f - temperature * 0.06f, 0.4f, 3.5f);
    }

}
