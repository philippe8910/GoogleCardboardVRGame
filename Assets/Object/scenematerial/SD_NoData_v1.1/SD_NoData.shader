Shader "SD-NoData/SD-NoData"
{
    Properties
    {
        _LineCount("Line Count", int) = 50
        _Alpha("Alpha", Range(0,1)) = 1.0
        _NoiseFactor("Noise Factor", Range(0,1)) = 0.15

    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            ZWrite OFF
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"


            float random (fixed2 p) 
            { 
                return frac(sin(dot(p, fixed2(12.9898,78.233))) * 43758.5453);
            }

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float3 worldPos : WORLD_POS;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Alpha;
            float _NoiseFactor;
            int _LineCount;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col;
                float2 screenPosNorm  = i.vertex.xy / _ScreenParams.xy;                 // 正規化されたスクリーン上の位置
                float cameraToObjLength = length(_WorldSpaceCameraPos - i.worldPos);    // カメラと描画する頂点の距離
                
                col = sin((screenPosNorm.y)*2.0f*UNITY_PI*_LineCount) * 0.1 + 0.1;                      // 2πf * Ampltitude + offset
                col = col*(1-_NoiseFactor) + random(cameraToObjLength*screenPosNorm)*_NoiseFactor;      // ノイズ付与
                col = col*float4(1,1,1,0) + float4(0,0,0,_Alpha);                                       // Alpha値設定

                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
