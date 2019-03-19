Shader "Custom/ToonShader"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", Vector) = (1,1,1,1)
    }
	SubShader{
		Pass {
		Tags
		{
			"LightMode" = "ForwardBase"
			"PassFlags" = "OnlyDirectional"
		}
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc" // required for v2f_img
			

			// Properties
			sampler2D _MainTex;
			float _Size;
			float3 _Normal: NORMAL;

			struct appdata
			{
				float4 vertex : POSITION;
				float4 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
				float3 worldNormal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				return o;
			}

			float4 frag(v2f input) : COLOR {
				// sample texture for color

				float2 uv = input.uv;
				uv.x = ceil(uv.x / _Size) * _Size;
				uv.y = ceil(uv.y / _Size) * _Size;

				float4 base = tex2D(_MainTex, uv);
				float4 normal = float4(input.worldNormal, 1);

				return base * normal;
			}
		ENDCG
	}
	}
}
