using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OctavesSlider : MonoBehaviour
{
    [SerializeField] 
    private GameObject NoiseLineObj;
    IFBMHandler FBMHandler;
    Slider slider;
    TMP_Text text;
    [SerializeField] private int max, min;
    void Awake()
    {
        FBMHandler = NoiseLineObj.GetComponent<IFBMHandler>();
        slider = GetComponent<Slider>();
        text = GetComponentInChildren<TMP_Text>();
        slider.onValueChanged.AddListener(UpdateOctaves);
    }

    void Start()
    {
        UpdateOctaves(slider.value);
    }

    void UpdateOctaves(float portion)
    {
        int octaves = Mathf.RoundToInt(min + (portion * (max - min)));
        FBMHandler.SetOctaves(octaves);
        text.text = "Octaves: " + octaves;

    }
}
