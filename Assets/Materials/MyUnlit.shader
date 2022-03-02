Shader "MyUnlit"
{
    Properties
    {
        _Color ( "My color", Color) = (1, 1, 1, 1)
        _Power (" Color power", Range(0, 1)) = 0.5
        _MainTex ("Main Texture", 2D) = "white"{}
        _MyVector ("My vector", Vector) = (0.2, 0.3, 0.4, 1) 
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            float4 _Color;

            struct appdata
            {
                float4 vertex : POSITION;
                float4 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 normalizedInWord : NORMAL;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.normalizedInWord = normalize(UnityObjectToWorldNormal(v.normal));
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return _Color * dot (i.normalizedInWord, _WorldSpaceLightPos0);
            }
            ENDCG
        }
    }
}
