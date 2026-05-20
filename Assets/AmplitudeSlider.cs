using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmplitudeSlider : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObj;

    [SerializeField] private Material mat;
    [SerializeField] private float min, max;
    private Slider slider;
    
    private TMP_Text valueText;

    void Awake()
    {
        mat = targetObj.GetComponent<Renderer>().material;
        slider = GetComponent<Slider>();
        valueText = GetComponentInChildren<TMP_Text>();
        slider.onValueChanged.AddListener(UpdateAmplitude);
    }

    void Start()
    {
        UpdateAmplitude(slider.value);
    }

    void UpdateAmplitude(float sliderVal)
    {
        float amp = min +  sliderVal * (max - min);
        mat.SetFloat("_Amplitude", amp);
        valueText.text = "Amplitude: " + amp;
    }
}
