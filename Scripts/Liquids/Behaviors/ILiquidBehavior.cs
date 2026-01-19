public interface ILiquidBehavior
{
    float ModifyFlow(float baseFlow);

    float Density { get; }

    float Viscosity { get; }

    void ApplyTemperature(float temperature);
}
