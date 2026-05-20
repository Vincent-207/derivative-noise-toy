using UnityEngine;
using UnityEngine.UI;

public class InterpolationSlider : MonoBehaviour
{
    [SerializeField] InterpolationLine line;
    Slider slider;
    void Awake()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(line.SetInterpolation);
    }
}
