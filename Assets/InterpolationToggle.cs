using UnityEngine;
using UnityEngine.UI;

public class InterpolationToggle : MonoBehaviour
{
    [SerializeField] 
    GameObject singleNoiseLine, interpolationNoiseLine;
    [SerializeField]
    private CanvasGroup singleNoiseGroup, interpolationNoiseGroup;
    Toggle toggle;

    void Awake()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(delegate { UpdateInterpolation(); });
    }

    void DisableInterpolationNoise()
    {
        interpolationNoiseLine.gameObject.SetActive(false);
        interpolationNoiseGroup.alpha = 0;
        interpolationNoiseGroup.interactable = false;
        interpolationNoiseGroup.blocksRaycasts = false;
    }
    void DisableSingleNoise()
    {
        singleNoiseLine.gameObject.SetActive(false);
        singleNoiseGroup.alpha = 0;
        singleNoiseGroup.interactable = false;
        singleNoiseGroup.blocksRaycasts = false;
       
        
    }

    void EnableInterpolationNoise()
    {
        interpolationNoiseLine.gameObject.SetActive(true);
        interpolationNoiseGroup.alpha = 1;
        interpolationNoiseGroup.interactable = true;
        interpolationNoiseGroup.blocksRaycasts = true;
    }

    void EnableSingleNoise()
    {
        singleNoiseLine.gameObject.SetActive(true);
        singleNoiseGroup.alpha = 1;
        singleNoiseGroup.interactable = true;
        singleNoiseGroup.blocksRaycasts = true;
    }
    
    

    void UpdateInterpolation()
    {
        if (toggle.isOn)
        {
            DisableSingleNoise();
            EnableInterpolationNoise();
        }
        else
        {
            EnableSingleNoise();
            DisableInterpolationNoise();
        }
    }
}
