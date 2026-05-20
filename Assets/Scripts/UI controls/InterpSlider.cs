using UnityEngine;

public class InterpSlider : FloatValueSlider
{
    override internal void Start()
    {
        valueName = "%";
        base.Start();
        valueName = "%";
    }

    internal override void UpdateCompute(float value)
    {
        
        base.UpdateCompute(value);
        computeHandler.SetPortion(value);
    }
}
