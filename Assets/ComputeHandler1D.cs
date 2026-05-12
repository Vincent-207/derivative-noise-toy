using UnityEngine;

[ExecuteInEditMode]
public class ComputeHandler1D : MonoBehaviour
{
    [SerializeField] ComputeShader compute;
    [SerializeField] RenderTexture rt;
    [SerializeField] Texture2D text;

    void Start()
    {
        SetupRenderTexture();
        RenderCompute();
        text = RenderToTexture2D(rt);

    }

    void Update()
    {
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
        compute.Dispatch(kernelhandle, 256, 1, 1);
    }

    Texture2D RenderToTexture2D(RenderTexture renderTexture)
    {
        Texture2D output = new(renderTexture.width, renderTexture.height);
        RenderTexture.active = renderTexture;
        output.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        output.Apply();

        return output;

    }
}