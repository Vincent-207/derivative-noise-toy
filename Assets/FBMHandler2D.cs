using UnityEngine;

public class FBMHandler2D : ComputeHandler2D
{
    [Range(0, 3)]
    public float Lacunarity = 2f;
    [Range(0, 3)]
    public float Gain = 0.5f;
    [Range(0, 12)]
    public int octaves = 8;
    
    public override void RenderCompute()
    {
        int kernelhandle = compute.FindKernel("CSMain");
        compute.SetTexture(kernelhandle, "Result", rt);
        compute.SetFloat("_Period", period);
        
        compute.SetFloat("_Lacunarity", Lacunarity);
        compute.SetFloat("_Gain", Gain);
        compute.SetInt("_Octaves", octaves);
        compute.Dispatch(kernelhandle, 256 / 8, 256 / 8, 1);
    }
}
