using UnityEngine;

public class OffsetXSlider : FloatValueSlider
{
    override internal void Start()
    {
        valueName = "Offset X";
        base.Start();
        valueName = "Offset X";
    }

    internal override void UpdateCompute(float value)
    {
        base.UpdateCompute(value);
        computeHandler.SetOffsetX(value);
    }
}
