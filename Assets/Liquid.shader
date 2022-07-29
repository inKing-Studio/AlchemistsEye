Shader "Unlit/LiquidShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Filling ("Filling", Range(0, 100)) = 0
        _Empty ("Empty Height", float) = 0
        _Full ("Full Height", float) = 0
        _Color ("Color", Color) = (1, 0, 0, 0)

        //[Toggle(UNITY_UI_ALPHACLIP)]  _UseUIAlphaClip ("Use Alpha Clip", Float) = 0.000000
    }
    SubShader
    {
        Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" "CanUseSpriteAtlas"="true" "PreviewType"="Plane" }

        Pass
        {
            Name "Default"
            Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" "CanUseSpriteAtlas"="true" "PreviewType"="Plane" }
            ZWrite Off
            Cull Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            uniform float _Filling;
            uniform float _Empty;
            uniform float _Full;

            float4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color;
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float distance = _Full - _Empty;

                float height = (i.uv.y - _Empty) / distance * 100;
                if (height > _Filling)
                    discard;

                fixed4 col = tex2D(_MainTex, i.uv);

                return col * i.color * _Color;
            }
            ENDCG
        }
    }
}
