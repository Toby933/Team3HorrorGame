Shader "Custom/RainShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_NormalTex ("Normal Texture (RGB), Specular Texture (A)", 2D) = "White" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface RainSurface Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		half4 _Color;
		sampler2D _MainTex;
		sampler2D _NormalTex;

		struct Input {
			float2 uv_MainTex;
		};

		half4 LightningHalfLambert(SurfaceOutput o,)

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		void RainSurface (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			half4 diffuseValue = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = diffuseValue.rgb * _Color;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = diffuseValue.a;

			half3 normalValue = UnpackNormal ( tex2D(_NormalTex, IN.uv_MainTex));
			o.Normal = normalValue.rgb;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
