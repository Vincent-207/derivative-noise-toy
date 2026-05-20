using UnityEngine;

public class HeightSlider : IntValueSlider
{
    internal override void UpdateCompute(int value)
    {
        computeHandler.SetHeight(value);
    }

    internal override void Start()
    {
        valueName = "Height";
        base.Start();
    }
}
