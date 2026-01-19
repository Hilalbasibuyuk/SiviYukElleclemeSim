public class OilBehavior : ILiquidBehavior
{
    public float Density => 0.9f;
    public float Viscosity => 3.0f; // daha koyu

    public float ModifyFlow(float baseFlow)
    {
        // Viskozite arttıkça akış düşer
        return baseFlow / Viscosity;
    }

    public void ApplyTemperature(float temperature)
    {
        // Sıcaklık arttıkça akış kolaylaşır
        // (ileride genişletilecek)
    }
}
