using System;
using UnityEditor;
using UnityEngine;
[ExecuteInEditMode]
public class Draw2DVarWidth : MonoBehaviour
{
    public ComputeShader computeShader;
    public RenderTexture[] rt;
    public int maxHeight = 256;
    public float period = 64f;
    void Start()
    {
        SetupRenderTextures();
        DoRender();
        
    }

    public Sprite[]  GetSprites()
    {
        Texture2D[] textures = new Texture2D[maxHeight];
        Sprite [] sprites = new Sprite[maxHeight];
        for (int i = 1; i < maxHeight; i++)
        {
            textures[i] = new Texture2D(256, i);
            RenderTexture.active = rt[i];
            textures[i].ReadPixels(new Rect(0, 0, 256, i), 0, 0);
            textures[i].Apply();
            
            sprites[i] = Sprite.Create(textures[i], new Rect(0, 0, 256, i), Vector2.zero);
        }
        return sprites;
    }
    void SetupRenderTextures()
    {
        rt = new RenderTexture[maxHeight];
        for (int i = 1; i < maxHeight; i++)
        {
            rt[i] = CreateRenderTexture(i);
            
        }
    }

    RenderTexture CreateRenderTexture(int height)
    {
        RenderTexture renderTexture = new RenderTexture(256, height, 24);
        renderTexture.enableRandomWrite = true;
        renderTexture.Create();
        return renderTexture;
    }

    void DoRender()
    {
        for(int i = 1; i < maxHeight; i++)
        {
            int kernelIndex = computeShader.FindKernel("CSMain");
            computeShader.SetTexture(kernelIndex, "Result", rt[i]);
            computeShader.SetFloat("_Period", period);
            computeShader.Dispatch(kernelIndex, 256 /8, Mathf.Max(i/8, 0) + 1, 1);
        }
    }

    void Update()
    {
        
    }
}
