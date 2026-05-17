using UnityEngine;

public class NoiseLine : MonoBehaviour, INoiseLine, IFBMHandler
{
    public ComputesHolder computes;
    ComputeHandler1D computeHandler;
    LineRenderer line;
    SetPosToScreen setPosToScreen;
    RenderToLine renderToLine;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
        setPosToScreen = GetComponent<SetPosToScreen>();
        computeHandler = GetComponent<ComputeHandler1D>();
        renderToLine = GetComponent<RenderToLine>();
    }

    void Start()
    {
        UpdateLine();
    }

    public void UpdateLine()
    {
        computeHandler.DoProcess();
        renderToLine.ApplyToLine();
        setPosToScreen.UpdatePos();
    }
    public void SetPeriod(float period)
    {
        computeHandler.period = period;
        UpdateLine();
    }

    public void UpdateLine(NoiseLineType lineType, int lineIndex)
    {
        computeHandler.compute = computes.GetComputeShader(lineType);
        UpdateLine();
    }

    public void SetLacunarity(float lacunarity)
    {
        computeHandler.SetLacunarity(lacunarity);
        UpdateLine();
    }

    public void SetGain(float gain)
    {
        computeHandler.SetGain(gain);
        UpdateLine();
    }

    public void SetOctaves(int octaves)
    {
        computeHandler.SetOctaves(octaves);
        UpdateLine();
    }
}



public interface INoiseLine
{
    public void SetPeriod(float period);
    public void UpdateLine();
    public void UpdateLine(NoiseLineType lineType, int lineIndex);
}

public interface IFBMHandler
{
    void SetLacunarity(float lacunarity);
    void SetGain(float gain);
    void SetOctaves(int octaves);
}