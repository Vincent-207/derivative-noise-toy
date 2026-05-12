using UnityEngine;

[ExecuteInEditMode]
public class ComputeHandler1D : MonoBehaviour,ITextureHolder
{
    [SerializeField] ComputeShader compute;
    [SerializeField] public RenderTexture rt;
    [SerializeField] Texture2D text;
    [SerializeField] private float period;
    void Start()
    {
        DoProcess();

    }

    void DoProcess()
    {
        SetupRenderTexture();
        RenderCompute();
        text = RenderToTexture2D(rt);
    }
    void SetupRenderTexture()
    {
        rt = new RenderTexture(256, 1, 0);
        rt.enableRandomWrite = true;
        rt.Create();
        rt.filterMode = FilterMode.Point;
    }

    void RenderCompute()
    {
        int kernelhandle = compute.FindKernel("CSMain");
        compute.SetTexture(kernelhandle, "Result", rt);
        compute.SetFloat("_Period", period);
        compute.Dispatch(kernelhandle, 1, 1, 1);
    }

    Texture2D RenderToTexture2D(RenderTexture renderTexture)
    {
        Texture2D output = new(renderTexture.width, renderTexture.height);
        RenderTexture.active = renderTexture;
        output.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        output.Apply();

        return output;

    }

    public Texture2D GetTexture2D()
    {
        DoProcess();
        return RenderToTexture2D(rt);
    }
    public float GetPeriod()
    {
        return period;
    }
}

public interface ITextureHolder
{
    public Texture2D GetTexture2D();
    public float GetPeriod();
}