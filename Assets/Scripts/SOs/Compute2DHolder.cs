using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Compute2DHolder", menuName = "Scriptable Objects/Compute2DHolder")]
public class Compute2DHolder : ScriptableObject
{
    public ComputeShader[] computes;
    
    public ComputeShader GetCompute(NoiseType2D type)
    {
        return computes[(int)type];
    }
    
    public ComputeShader GetCompute(int type)
    {
        return GetCompute((NoiseType2D)type);
    }
}

public enum NoiseType2D
{
    ValueLinear,
    ValueHermite,
    ValueQuintic,
    GradientLinear,
    GradientHermite,
    GradientQuintic,
    ValueFBMLinear,
    ValueFBMHermite,
    ValueFBMQuintic,
    GradientFBMLinear,
    GradientFBMHermite,
    GradientFBMQuintic,
    ValueFBMDerivativeQuintic,
    GradientFBMDerivativeLinear,
    GradientFBMDerivativeHermite,
    GradientFBMDerivativeQuintic,
    
}