﻿Shader "EffectShader" {
	Properties{
	  _MainTex("Texture", 2D) = "white" {}
	  _Size("Pixel Size", float) = 0.25
	}

		SubShader{
			Pass {

				CGPROGRAM
				#pragma vertex vert_img
				#pragma fragment frag
				#include "UnityCG.cginc" // required for v2f_img

				// Properties
				sampler2D _MainTex;
				float _Size;

				float4 frag(v2f_img input) : COLOR {
					// sample texture for color

					float2 uv = input.uv;

					float4 base = tex2D(_MainTex, uv);
						
					return base;
				}
			ENDCG
		}
	  }
}