using UnityEngine;

public class InterpolationLine : MonoBehaviour, INoiseLine
{
    [SerializeField] ComputesHolder computes;
    [SerializeField]
    ComputeHandler1D initialCompute, finalCompute;
    LineRenderer line;
    SetPosToScreen setPosToScreen;
    InterpolationToLine interpolationToLine;
    [Range(0,1f)]
    public float interpolationValue;
    void Awake()
    {
        line = GetComponent<LineRenderer>();
        setPosToScreen = GetComponent<SetPosToScreen>();
        interpolationToLine = GetComponent<InterpolationToLine>();
    }

    void Start()
    {
        UpdateLine();
    }
    public void UpdateLine()
    {
        initialCompute.DoProcess();
        finalCompute.DoProcess();
        interpolationToLine.ApplyToLine(initialCompute.text, finalCompute.text, interpolationValue);
        setPosToScreen.UpdatePos();
    }

    public void SetPeriod(float period)
    {
        initialCompute.period = period; 
        finalCompute.period = period;
        UpdateLine();
    }

    public void SetInterpolation(float t)
    { 
        interpolationValue = t;
        UpdateLine();
    }

    public void UpdateLine(NoiseLineType lineType, int lineIndex)
    {
        if (lineIndex == 0)
        {
            initialCompute.compute =  computes.GetComputeShader(lineType);
        }
        else
        {
            finalCompute.compute = computes.GetComputeShader(lineType);
        }
        UpdateLine();
    }
}
