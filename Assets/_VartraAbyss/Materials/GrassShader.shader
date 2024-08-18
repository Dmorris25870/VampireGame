Shader "Unlit/GrassShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _PartStrength ("Part Strength", Range(0, 1)) = 0.5
        _PartRadius ("Part Radius", Range(0, 5)) = 1
        _PlayerPos ("Player Position", Vector) = (0,0,0,0)
    }
    SubShader
    {
        Tags {"Queue" = "Transparent" }
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
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _PartStrength;
            float _PartRadius;
            float4 _PlayerPos;

            v2f vert (appdata v)
            {
                v2f o;
                float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;

                float3 toPlayer = worldPos - _PlayerPos.xyz;
                float distance = length(toPlayer);

                float proximityEffect = saturate(1.0 - distance / _PartRadius);

                float3 partDirection = normalize(toPlayer) * _PartStrength * proximityEffect;

                v.vertex.xyz += partDirection * (v.vertex.y / _PartRadius);

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
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