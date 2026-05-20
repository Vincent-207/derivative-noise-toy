using UnityEngine;

public class OctavesSlider1 : IntValueSlider
{
    internal override void UpdateCompute(int value)
    {
        computeHandler.SetOctaves(value);
    }

    internal override void Start()
    {
        
        valueName = "Octaves";
        base.Start();
    }
}
