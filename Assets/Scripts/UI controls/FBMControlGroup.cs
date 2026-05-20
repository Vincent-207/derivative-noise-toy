using System;
using UnityEngine;

public class FBMControlGroup : MonoBehaviour
{
    [SerializeField] NoiseTypeDropdown[] dropdowns;
    CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void UpdateControls()
    {
        foreach(NoiseTypeDropdown dropdown in dropdowns)
        {
            if (dropdown.isFBMNoise())
            {
                ShowFBMControls();
                return;
            }
        }
        
        HideFBMControls();
        return;
    }

    void ShowFBMControls()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }
    
    void HideFBMControls()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }
}
