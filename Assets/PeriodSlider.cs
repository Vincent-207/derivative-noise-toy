using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PeriodSlider : MonoBehaviour
{
    private Slider slider;
    public float maxPeriod, basePeriod;
    [SerializeField] private GameObject singleNoiseObj, interpolationNoiseObj;
    public INoiseLine singleNoiseLine, interpolationNoiseLine;
    TMP_Text periodText;
    void Awake()
    {
        singleNoiseLine = singleNoiseObj.GetComponent<INoiseLine>();
        interpolationNoiseLine = interpolationNoiseObj.GetComponent<INoiseLine>();
        
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { UpdatePeriod(slider.value); });
        periodText = GetComponentInChildren<TMP_Text>();
        Debug.Log("End of awake!");
    }

    void Start()
    {
        UpdatePeriod(slider.value);
    }
    public void UpdatePeriod(float a)
    {
        Debug.Log("Starting update!");
        float period = slider.value * (maxPeriod - basePeriod) + basePeriod;
        if(singleNoiseObj.activeSelf) singleNoiseLine.SetPeriod(period);
        interpolationNoiseLine.SetPeriod(period);
        periodText.text = "Period: " + Mathf.RoundToInt(period);
    }

}
