using UnityEngine;

public class WidthSlider : IntValueSlider
{
    internal override void UpdateCompute(int value)
    {
        computeHandler.SetWidth(value);
    }

    internal override void Start()
    {
        valueName = "Width";
        base.Start();
    }
}
