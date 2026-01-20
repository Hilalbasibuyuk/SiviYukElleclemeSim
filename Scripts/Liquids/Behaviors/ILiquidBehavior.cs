public interface ILiquidBehavior
{
    float ModifyFlow(float baseFlow);

    float Density { get; }

    float Viscosity { get; }

    float GetViscosity(float temperature);


    void ApplyTemperature(float temperature);
}
