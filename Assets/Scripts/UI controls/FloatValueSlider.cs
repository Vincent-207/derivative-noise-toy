using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloatValueSlider : MonoBehaviour
{
    [SerializeField] internal float max, min;
    private Slider slider;
    internal TMP_Text text;
    [SerializeField]
    internal ComputeHandlerPlus2D computeHandler;
    internal string valueName = "Value";
    void Awake()
    {
        slider = GetComponent<Slider>();
        text = GetComponentInChildren<TMP_Text>();
        slider.onValueChanged.AddListener(UpdateValue);
    }

    internal virtual void Start()
    {
        UpdateValue(slider.value);
    }

    void UpdateValue(float value)
    {
        float val = min + value * (max - min);
        UpdateCompute(val);
    }

    internal virtual void UpdateCompute(float value)
    {
        text.text = valueName + ": " + value.ToString("F2");
        //computeHandler.SetPeriod(value);
    }
    
    
}
