using UnityEngine;

public class InterpolationLine : MonoBehaviour, INoiseLine, IFBMHandler
{
    [SerializeField] ComputesHolder computes;
    [SerializeField]
    ComputeHandler1D initialCompute, finalCompute;
    LineRenderer line;
    SetPosToScreen setPosToScreen;
    [SerializeField]
    InterpolationToLine interpolationToLine;
    [Range(0,1f)]
    public float interpolationValue;

    [SerializeField] private float lacunarity, gain;
    [SerializeField] private int octaves;
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
        initialCompute.SetGain(gain);
        initialCompute.SetLacunarity(lacunarity);
        initialCompute.SetOctaves(octaves);
        
        finalCompute.SetLacunarity(lacunarity);
        finalCompute.SetGain(gain);
        finalCompute.SetOctaves(octaves);
        
        initialCompute.DoProcess();
        finalCompute.DoProcess();
        if(interpolationToLine == null) Debug.LogWarning("InterpolationToLine has not been set");
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

    public void SetLacunarity(float lacunarity)
    {
        this.lacunarity = lacunarity;
        UpdateLine();
    }

    public void SetGain(float gain)
    {
        this.gain = gain;
        UpdateLine();
    }

    public void SetOctaves(int octaves)
    {
        this.octaves = octaves;
        UpdateLine();
    }
}
