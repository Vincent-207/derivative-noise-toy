using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GainSlider : MonoBehaviour
{
    [SerializeField] private GameObject noiseLine;
    IFBMHandler FBMHandler;
    private Slider slider;
    TMP_Text sliderText;
    public float min, max;
    void Awake()
    {
        FBMHandler = noiseLine.GetComponent<IFBMHandler>();
        slider = GetComponent<Slider>();
        sliderText = slider.GetComponentInChildren<TMP_Text>();
        slider.onValueChanged.AddListener(UpdateGain);
    }

    private void Start()
    {
        UpdateGain();
    }

    void UpdateGain()
    {
        UpdateGain(slider.value);
    }
    void UpdateGain(float portion)
    {
        float gain = min + (max - min) * portion;
        FBMHandler.SetGain(gain);
        sliderText.text = "Gain: " + gain.ToString("F2");
    }
    
    
}
