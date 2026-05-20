using UnityEngine;
using UnityEngine.Serialization;

public class ComputeHandlerPlus2D : MonoBehaviour
{
    [SerializeField] private ComputeShader initial;
    [SerializeField] private ComputeShader final, interpolation;

    [SerializeField] Compute2DHolder compute2DHolder;
    [SerializeField] HeightMapHandler heightMapHandler;
    [Range(1, 256)]
    [SerializeField] private int width, height;

    [SerializeField] private float period = 32f, gain = 0.5f, lacunarity = 2.0f;
    [SerializeField] private int octaves = 8;
    [SerializeField] private Vector2 offset;
    [SerializeField] private float portion;

    [SerializeField] private float amplitude;
    SpriteRenderer spriteRenderer;
    
    
    

    public RenderTexture myRT;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        DoProcess();
    }

    void Start()
    {
        DoProcess();
        /*RenderTexture initalRT = myRT = RenderCompute(initial, SetupRenderTexture());
        spriteRenderer.sprite = Texture2DToSprite(RenderToTexture2D(initalRT));*/
        
    }
    public RenderTexture SetupRenderTexture()
    {
        RenderTexture rt = new RenderTexture(width, height, 0);
        rt.enableRandomWrite = true;
        rt.Create();
        rt.filterMode = FilterMode.Point;
        return rt;

    }

    public RenderTexture RenderCompute(ComputeShader compute, RenderTexture rt)
    {
        int kernelHandle = compute.FindKernel("CSMain");
        
        compute.SetTexture(kernelHandle, "Result", rt);
        
        compute.SetFloat("_Period", period);
        compute.SetVector("_Offset", offset);
        
        compute.SetFloat("_Gain", gain);
        compute.SetFloat("_Lacunarity", lacunarity);
        compute.SetInt("_Octaves", octaves);
        
        compute.Dispatch(kernelHandle, width, height, 1);
        return rt;
    }

    public void DoProcess()
    {
        RenderTexture initalRT = RenderCompute(initial, SetupRenderTexture());
        RenderTexture finalRT = RenderCompute(final, SetupRenderTexture());
        
        RenderTexture outputRT = myRT =  interpolateRT(initalRT, finalRT, portion);
        heightMapHandler.ApplyHeightMap(outputRT);
        Sprite heightSprite = Texture2DToSprite(RenderToTexture2D(outputRT));
        spriteRenderer.sprite = heightSprite;
    }

    Sprite Texture2DToSprite(Texture2D texture2D)
    {
        Sprite output = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
        return output;
    }

    Texture2D RenderToTexture2D(RenderTexture rt)
    {
        Texture2D output = new Texture2D(rt.width, rt.height, TextureFormat.RGBA32, false);
        RenderTexture.active = rt;
        output.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        output.Apply();
        return output;
    }

    public RenderTexture interpolateRT(RenderTexture initial, RenderTexture final, float portion)
    {
        int kernelHandle = interpolation.FindKernel("CSMain");
        RenderTexture output = SetupRenderTexture();
        
        interpolation.SetTexture(kernelHandle, "Result", output);
        interpolation.SetTexture(kernelHandle, "_Initial", initial);
        interpolation.SetTexture(kernelHandle, "_Final", final);
        interpolation.SetFloat("_Portion", portion);
        
        interpolation.Dispatch(kernelHandle, width, height, 1);
        return output;
    }
    
    public void SetWidth(int width)
    {
        this.width = width;
        DoProcess();
    }

    public void SetHeight(int height)
    {
        this.height = height;
        DoProcess();
    }

    public void SetPeriod(float period)
    {
        this.period = period;
        DoProcess();
    }

    public void SetGain(float gain)
    {
        this.gain = gain;
        DoProcess();
    }

    public void SetLacunarity(float lacunarity)
    {
        this.lacunarity = lacunarity;
        DoProcess();
    }

    public void SetOctaves(int octaves)
    {
        this.octaves = octaves;
        DoProcess();
    }

    public void SetPortion(float portion)
    {
        this.portion = portion;
        DoProcess();
    }

    public void SetOffsetX(float offsetX)
    {
        offset.x = offsetX;
        DoProcess();
    }

    public void SetOffsetY(float offsetY)
    {
        offset.y = offsetY;
        DoProcess();
    }

    public void SetNoiseType(NoiseType2D noiseType, int index)
    {
        if (index == 0)
        {
            initial = compute2DHolder.GetCompute(noiseType);
        }
        else
        {
            final = compute2DHolder.GetCompute(noiseType);
        }
        
        DoProcess();
    }
}
