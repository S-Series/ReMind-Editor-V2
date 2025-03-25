Shader "Custom/ScreenCrack"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" { }
        _CrackTex ("Crack Texture", 2D) = "black" { }
        _Distortion ("Distortion", Range(0, 1)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            sampler2D _CrackTex;
            float _Distortion;

            struct appdata_t {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert(appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                half4 baseColor = tex2D(_MainTex, i.uv);
                half4 crack = tex2D(_CrackTex, i.uv);
                baseColor.rgb += crack.rgb * _Distortion;
                return baseColor;
            }
            ENDCG
        }
    }
}
