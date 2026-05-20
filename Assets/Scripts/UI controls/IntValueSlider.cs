using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IntValueSlider : MonoBehaviour
{
    [SerializeField]
    internal int min = 1, max = 256;
    Slider slider;
    internal String valueName;
    TMP_Text text;
    [SerializeField] internal ComputeHandlerPlus2D computeHandler;

    void Awake()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(UpdateValue);
        text = GetComponentInChildren<TMP_Text>();
    }

    internal virtual void Start()
    {
        UpdateValue(slider.value);
    }

    void UpdateValue(float value)
    {
        int val = (int) (min + value * (max - min));
        text.text = valueName + ": " +  val.ToString();
        UpdateCompute(val);
    }

    internal virtual void UpdateCompute(int value)
    {
        computeHandler.SetWidth(value);
    }
}
