using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LacunaritySlider : MonoBehaviour
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
        slider.onValueChanged.AddListener(UpdateLacunarity);
    }

    private void Start()
    {
        UpdateLacunarity();
    }

    void UpdateLacunarity()
    {
        UpdateLacunarity(slider.value);
    }
    void UpdateLacunarity(float portion)
    {
        float lacunarity = min + (max - min) * portion;
        FBMHandler.SetGain(lacunarity);
        sliderText.text = "Lacunarity: " + lacunarity.ToString("F2");
    }
}
