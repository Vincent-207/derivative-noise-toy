using UnityEngine;

[CreateAssetMenu(fileName = "ComputesHolder", menuName = "Scriptable Objects/ComputesHolder")]
public class ComputesHolder : ScriptableObject
{
    [SerializeField]
    ComputeShader[] computes;
    
    public ComputeShader GetComputeShader(int index)
    {
        return computes[index];
    }

    public ComputeShader GetComputeShader(NoiseLineType lineType)
    {
        return computes[(int)lineType];
    }
}

public enum NoiseLineType
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
}