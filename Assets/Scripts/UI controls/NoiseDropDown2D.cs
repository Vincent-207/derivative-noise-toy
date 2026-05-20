using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class NoiseDropDown2D : MonoBehaviour
{
    TMP_Dropdown dropdown;
    public NoiseType2D noiseType;
    public int index;
    [SerializeField]
    ComputeHandlerPlus2D computeHandler;
    void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        SetupOptions();
        dropdown.onValueChanged.AddListener(UpdateNoiseType);
    }

    void Start()
    {
        dropdown.value = (int)noiseType;
        UpdateNoiseType(dropdown.value);
    }
    void SetupOptions()
    {
        dropdown.ClearOptions();
        List<String> options = new List<String>();
        options.AddRange(Enum.GetNames(typeof(NoiseType2D)));
        dropdown.AddOptions(options);
    }

    void UpdateNoiseType(int value)
    {
        noiseType = (NoiseType2D)value;
        computeHandler.SetNoiseType(noiseType, index);
    }
    
    
}

