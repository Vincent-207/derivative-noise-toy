using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PeriodSlider : MonoBehaviour
{
    private Slider slider;
    public float maxPeriod, basePeriod;
    public NoiseLine noiseLine;
    void Awake()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(UpdatePeriod);
    }

    void Start()
    {
        UpdatePeriod(slider.value);
    }
    public void UpdatePeriod(float a)
    {
        float period = slider.value * (maxPeriod - basePeriod) + basePeriod;
        noiseLine.UpdateLine(period);
        
    }

}
