// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Morphing" 
{
	Properties
	{ 
		_MainTex ("SrcTexture", 2D) = "white" { }
		_DestinyTex ("DstTexture", 2D) = "white" { }
		_Speed  ("Speed" , Float) = 0.05
	}

	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
 
			sampler2D _MainTex;
			sampler2D _DestinyTex;
			float  _Speed;
			 
			struct v2f
			{
				float4 pos : POSITION;
				float2 uv: TEXCOORD0;
			};
 
			v2f vert (appdata_base v) 
			{
				v2f o;
 				o.pos = UnityObjectToClipPos( v.vertex );
				o.uv = v.texcoord;
 				return o;
		   }
 
		   fixed4 frag (v2f i) : COLOR
		   {
			  fixed4 src = tex2D(_MainTex, i.uv);
			  fixed4 dst = tex2D(_DestinyTex, i.uv);
			  float s = sin(_Time.y * _Speed) + 0.5;
			  s = s < 0 ? 0 : s;
			  s = s > 1 ? 1 : s;
			  fixed4 color = lerp(src, dst, s);
			  return color;
		   }
 
			ENDCG
		}
	}
}
