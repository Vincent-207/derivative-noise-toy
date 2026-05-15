using UnityEngine;

public class ComputeHandler2D : ComputeHandler1D
{
    public override void SetupRenderTexture()
    {
        rt = new RenderTexture(256, 256, 32);
        rt.enableRandomWrite = true;
        rt.Create();
        rt.filterMode = FilterMode.Point;
    }

    public override void RenderCompute()
    {
        int kernelhandle = compute.FindKernel("CSMain");
        compute.SetTexture(kernelhandle, "Result", rt);
        compute.SetFloat("_Period", period);
        compute.Dispatch(kernelhandle, 256 / 8, 256 / 8, 1);
    }
}
