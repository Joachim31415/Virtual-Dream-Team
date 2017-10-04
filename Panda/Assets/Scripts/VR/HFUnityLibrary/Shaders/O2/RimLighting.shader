﻿Shader "HappyFinish/O2/RimLighting" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      _MainColor ("Main Color", Color) = (1,1,1,1)
      _RimColor ("Rim Color", Color) = (0.26,0.19,0.16,0.0)
      _RimPower ("Rim Power", Range(0.5,8.0)) = 3.0
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      #pragma target 3.0

      struct Input {
          float2 uv_MainTex;
          float3 viewDir;
      };

      sampler2D _MainTex;
      float4 _MainColor;
      float4 _RimColor;
      float _RimPower;

      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb * _MainColor;
          half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));
          o.Emission = _RimColor.rgb * pow (rim, _RimPower);
      }
      ENDCG
    } 
    Fallback "Diffuse"
}
