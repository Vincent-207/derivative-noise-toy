using UnityEngine;

public class PeriodSlider1 : FloatValueSlider
{
    override internal void Start()
    {
        valueName = "Period";
        base.Start();
        valueName = "Period";
    }

    internal override void UpdateCompute(float value)
    {
        base.UpdateCompute(value);
        computeHandler.SetPeriod(value);
    }
}
