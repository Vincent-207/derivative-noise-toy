using UnityEngine;

public class NoiseLine : MonoBehaviour
{
    ComputeHandler1D computeHandler;
    LineRenderer line;
    SetPosToScreen setPosToScreen;
    RenderToLine renderToLine;

    void Awake()
    {
        computeHandler = GetComponent<ComputeHandler1D>();
        line = GetComponent<LineRenderer>();
        setPosToScreen = GetComponent<SetPosToScreen>();
        renderToLine = GetComponent<RenderToLine>();
    }

    public void UpdateLine()
    {
        computeHandler.DoProcess();
        renderToLine.ApplyToLine();
        setPosToScreen.UpdatePos();
    }
    public void UpdateLine(float period)
    {
        computeHandler.period = period;
        UpdateLine();
    }
}
