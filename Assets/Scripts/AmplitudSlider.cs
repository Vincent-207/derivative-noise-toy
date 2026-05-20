using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmplitudSlider : MonoBehaviour
{
    [SerializeField] private Material mat;
    private float min, max;
    Slider slider;
    private TMP_Text text;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    
    void UpdateAmplitude(float val)
    {
        float amplitude = min + (max - min) * val;
        mat.SetFloat("_Amplitude", amplitude);
        text.text = "Amplitude: " + amplitude.ToString("F2");
    }
}
