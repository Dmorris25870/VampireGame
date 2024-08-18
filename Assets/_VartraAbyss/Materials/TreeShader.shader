Shader "Unlit/TreeShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _SwayAmount ("Sway Amount", Float) = 0.05
        _SwaySpeed ("Sway Speed", Float) = 1.0
        _WindDirection ("Wind Direction", Vector) = (1, 0, 0, 0)
        _VariationScale ("Variation Scale", Float) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _SwayAmount;
            float _SwaySpeed;
            float4 _WindDirection;
            float _VariationScale;

            v2f vert (appdata v)
            {
                v2f o;

                // Introduce random variation based on world position
                float randomOffset = frac(sin(dot(v.worldPos.xy, float2(12.9898, 78.233))) * 43758.5453) * _VariationScale;

                // Calculate vertical gradient effect
                float gradient = saturate(v.vertex.y);

                // Calculate sway factor with random variation and gradient effect
                float swayFactor = sin(_Time.y * (_SwaySpeed + randomOffset) + v.worldPos.x * 0.1) * (_SwayAmount + randomOffset) * gradient;

                // Apply sway with wind direction
                v.vertex.x += swayFactor * _WindDirection.x;
                v.vertex.z += swayFactor * _WindDirection.z;

                // Convert the modified vertex position to clip space
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return tex2D(_MainTex, i.uv);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}