using UnityEngine;

public class OffsetYSlider : FloatValueSlider
{
    override internal void Start()
    {
        valueName = "Offset Y";
        base.Start();
        valueName = "Offset Y";
    }

    internal override void UpdateCompute(float value)
    {
        base.UpdateCompute(value);
        computeHandler.SetOffsetY(value);
    }
}
