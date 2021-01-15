/*	
*/
Shader "Snapshot/Pride"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_ColorA("Colour 1", Color) = (0.90, 0.00, 0.00, 1)
		_ColorB("Colour 2", Color) = (1.00, 0.55, 0.00, 1)
		_ColorC("Colour 3", Color) = (1.00, 0.94, 0.00, 1)
		_ColorD("Colour 4", Color) = (0.00, 0.51, 0.12, 1)
		_ColorE("Colour 5", Color) = (0.00, 0.27, 1.00, 1)
		_ColorF("Colour 6", Color) = (0.46, 0.00, 0.54, 1)
		_MixAmount("Mix Amount", Float) = 0.25
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4    _MainTex_ST;

			float4 _ColorA;
			float4 _ColorB;
			float4 _ColorC;
			float4 _ColorD;
			float4 _ColorE;
			float4 _ColorF;
			float _MixAmount;

            fixed4 frag (v2f_img i) : SV_Target
            {
				fixed4 tex = tex2D(_MainTex, i.uv);
				fixed4 col = tex;

				if (i.uv.y < 1.0 / 6.0)
				{
					col = lerp(tex, _ColorF, _MixAmount);
				}
				else if (i.uv.y < 2.0 / 6.0)
				{
					col = lerp(tex, _ColorE, _MixAmount);
				}
				else if (i.uv.y < 3.0 / 6.0)
				{
					col = lerp(tex, _ColorD, _MixAmount);
				}
				else if (i.uv.y < 4.0 / 6.0)
				{
					col = lerp(tex, _ColorC, _MixAmount);
				}
				else if (i.uv.y < 5.0 / 6.0)
				{
					col = lerp(tex, _ColorB, _MixAmount);
				}
				else
				{
					col = lerp(tex, _ColorA, _MixAmount);
				}

				return col;
            }
            ENDCG
        }
    }
}
