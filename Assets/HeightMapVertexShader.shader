Shader "Custom/NewUnlitUniversalRenderPipelineShader"
{
    Properties
    {
        [MainColor] _BaseColor("Base Color", Color) = (1, 1, 1, 1)
        [MainTexture] _BaseMap("Base Map", 2D) = "white" {}
        _HeightMap ("Height Map", 2D) = "White" {}
        _Amplitude ("Amplitude", Range(1, 128)) = 1.0
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" }

        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);
            TEXTURE2D(_HeightMap);
            SAMPLER(sampler_HeightMap);
            
            CBUFFER_START(UnityPerMaterial)
                half4 _BaseColor;
                float4 _BaseMap_ST;
                float4 _HeightMap_ST;
                float _Amplitude;
            CBUFFER_END

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                float4 texSample = SAMPLE_TEXTURE2D_LOD(_HeightMap, sampler_HeightMap, IN.uv, 0);
                float height = texSample.r * _Amplitude;
                float4 displacedVertex = IN.vertex + float4(0, 0, height, 0);
                OUT.pos = TransformObjectToHClip(displacedVertex.xyz); 
                OUT.uv = TRANSFORM_TEX(IN.uv, _BaseMap);
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                half4 color = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.uv) * _BaseColor;
                return color;
            }
            ENDHLSL
        }
    }
}
