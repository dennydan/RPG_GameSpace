Shader "Custom/Hole"
{
	SubShader
	{
		Tags { "RenderType" = "Opaque" "ForceNoShadowCasting"="True"}
		LOD 200

		ColorMask 0
		ZTest LEqual
		ZWrite On

		pass{}
    }
    FallBack "Diffuse"
}
