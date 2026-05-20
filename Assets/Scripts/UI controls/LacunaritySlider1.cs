using UnityEngine;

public class LacunaritySlider1 : FloatValueSlider
{
    override internal void Start()
    {
        valueName = "Lacunarity";
        base.Start();
        valueName = "Lacunarity";
    }

    internal override void UpdateCompute(float value)
    {
        base.UpdateCompute(value);
        computeHandler.SetLacunarity(value);
    }
}
