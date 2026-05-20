using UnityEngine;

public class GainSlider1 : FloatValueSlider
{
    override internal void Start()
    {
        valueName = "Gain";
        base.Start();
        valueName = "Gain";
    }

    internal override void UpdateCompute(float value)
    {
        base.UpdateCompute(value);
        computeHandler.SetGain(value);
    }
}
