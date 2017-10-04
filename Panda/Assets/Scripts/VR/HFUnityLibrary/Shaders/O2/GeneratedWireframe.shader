// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "HappyFinish/O2/Generated Wireframe" 
{
	// GameObjects using this "Generated Wireframe" should also include the WireframeMeshConditioner script
	Properties
	{
		_LineColor("Line Color", Color) = (1,1,1,1)
		_BackgroundColor("Background Color", Color) = (1,1,1,1)
		_LineWidth("Line Width", Range(0.0, 1.0)) = 0.1
	}

	SubShader 
	{
	    Pass 
	    {
	        CGPROGRAM
	        #pragma vertex vert
	        #pragma fragment frag

	        // vertex input: position, UV
	        struct appdata 
	        {
	            float4 vertex : POSITION;
	            float4 texcoord : TEXCOORD0;
	            float4 texcoord1 : TEXCOORD1;
	        };

	        struct v2f 
	        {
	            float4 pos : SV_POSITION;
	            float4 uv : TEXCOORD0;
	            float4 uv1 : TEXCOORD1;
	        };
	        
	        v2f vert (appdata v) 
	        {
	            v2f o;
	            o.pos = UnityObjectToClipPos( v.vertex );
	            o.uv = float4( v.texcoord.xy, 0, 0 );
	            o.uv1 = float4(v.texcoord1.xy, 0, 0);
	            return o;
	        }

	        uniform float4 _LineColor;
	        uniform float4 _BackgroundColor;
	        uniform float _LineWidth;
	        
	        half4 frag( v2f i ) : SV_Target 
	        {
	        	if((i.uv1.x < _LineWidth) || (i.uv1.y < _LineWidth))
	        	{
	        		return _LineColor;
	        	}
				if ((1.0 - i.uv1.x) < _LineWidth || (1.0 - i.uv1.y) < _LineWidth)
				{
					return _LineColor;
				}
				if(((i.uv1.x - i.uv1.y) < _LineWidth) && ((i.uv1.y - i.uv1.x) < _LineWidth))
				{
					return _LineColor;
				}
	            return _BackgroundColor;
	        }
	        ENDCG
	    }
	}
}

