using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoiseTypeDropdown : MonoBehaviour
{
    private TMP_Dropdown _dropdown;
    [SerializeField] private GameObject LineObj;
    [SerializeField]
    INoiseLine noiseLine;
    
    [SerializeField]
    FBMControlGroup FBMGroup;
    NoiseLineType noiseLineType;
    public int lineIndex;
    void Awake()
    {
        _dropdown = GetComponent<TMP_Dropdown>();
        SetupOptions();
        _dropdown.onValueChanged.AddListener(UpdateLine);
        noiseLine =  LineObj.GetComponent<INoiseLine>();
    }

    void Start()
    {
        UpdateLine();
    }

    void UpdateLine()
    {
        UpdateLine(_dropdown.value);
    }

    void UpdateLine(int value)
    {
        if (LineObj.activeSelf == false) return;
        noiseLineType = (NoiseLineType) value;
        noiseLine.UpdateLine(noiseLineType, lineIndex);
        Debug.Log("Changing type: " + Enum.GetName(typeof(NoiseLineType), noiseLineType));
        FBMGroup.UpdateControls();
    }

    public bool isFBMNoise()
    {
        return isFBMNoise(noiseLineType);
    }
    bool isFBMNoise(NoiseLineType noiseLineType)
    {
        if((int) noiseLineType >= 6) return true;
        return false;
    }

    void SetupOptions()
    {
        _dropdown.ClearOptions();
        List<String> options = new();
        String[] optionNames = Enum.GetNames(typeof(NoiseLineType));
        options.AddRange(optionNames);
        _dropdown.AddOptions(options);
    }
}
