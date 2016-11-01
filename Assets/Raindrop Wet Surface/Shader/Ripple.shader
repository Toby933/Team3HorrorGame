Shader "Raindrop Wet Surface/Ripple" {
	Properties {
		_MainTex ("Main", 2D) = "white" {}
		_RainIntensity ("Rain Intensity", Range(0, 1)) = 1
		_RainTime ("Rain Time", Vector) = (0, 0, 0, 0)
	}
	CGINCLUDE
		#include "UnityCG.cginc"
		#define PI 3.141592653
		
		uniform sampler2D _MainTex;
		uniform float _RainIntensity;
		uniform float4 _RainTime;
		
		float3 ComputeRipple (float2 uv, float t, float w)
		{
			float4 ripple = tex2D(_MainTex, uv);
			ripple.yz = ripple.yz * 2.0 - 1.0;
            
			float dropFrac = frac(ripple.w + t);
			float timeFrac = dropFrac - 1.0 + ripple.x;
			float dropFactor = saturate(0.2 + w * 0.8 - dropFrac);
			float final = dropFactor * ripple.x * sin(clamp(timeFrac * 9.0, 0.0, 3.0) * PI);
			return float3(ripple.yz * final * 0.35, 1.0);
		}
		float4 frag (v2f_img i) : SV_TARGET
		{
			float4 weight = _RainIntensity.xxxx - float4(0, 0.25, 0.5, 0.75);
			weight = saturate(weight * 4);   
   
			float3 ripple1 = ComputeRipple(i.uv + float2( 0.25f,0.0f), _RainTime.x, weight.x);
			float3 ripple2 = ComputeRipple(i.uv + float2(-0.55f,0.3f), _RainTime.y, weight.y);
			float3 ripple3 = ComputeRipple(i.uv + float2(0.6f, 0.85f), _RainTime.z, weight.z);
			float3 ripple4 = ComputeRipple(i.uv + float2(0.5f,-0.75f), _RainTime.w, weight.w);

			float4 Z = lerp(1, float4(ripple1.z, ripple2.z, ripple3.z, ripple4.z), weight);
			float3 N = float3(
				weight.x * ripple1.xy +
				weight.y * ripple2.xy + 
				weight.z * ripple3.xy + 
				weight.w * ripple4.xy, 
				Z.x * Z.y * Z.z * Z.w);
			return float4(normalize(N) * 0.5 + 0.5, 1.0); 
		}
	ENDCG
	SubShader {
		ZTest Always Cull Off ZWrite Off
		Pass {
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			ENDCG
		}
	}
	FallBack Off
}