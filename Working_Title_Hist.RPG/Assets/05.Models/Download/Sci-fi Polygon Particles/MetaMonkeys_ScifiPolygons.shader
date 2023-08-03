// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "MetaMonkeys/ScifiPolygons v0.2"
{
	Properties
	{
		[HDR]_maincolor("main color", Color) = (0,0.1661559,1.765406,0)
		_fresnelscale("fresnel scale", Float) = 1
		_flicker("flicker", Range( 0 , 1)) = 0.4893474
		_flickerspeed("flicker speed", Float) = 1.03
		_dissolvetexture("dissolve texture", 2D) = "black" {}
		_dissolveedgewidth("dissolve edge width", Range( 0 , 1)) = 0
		_dissolveedgeintensity("dissolve edge intensity", Float) = 0
		_scrollingemissionvelocity("scrolling emission velocity", Float) = 0
		_scrollingemissionpow("scrolling emission pow", Float) = 0
		_scrollingemissionHz("scrolling emission Hz", Float) = 0
		[KeywordEnum(X,Y,Z)] _scrollingdir("scrolling dir", Float) = 0
		[Toggle(_SCROLLINGWAVEDIR_ON)] _scrollingwavedir("scrolling wave dir", Float) = 0
		[HideInInspector] _texcoord2( "", 2D ) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		ZWrite On
		Blend SrcAlpha OneMinusSrcAlpha
		
		CGINCLUDE
		#include "UnityShaderVariables.cginc"
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 3.0
		#pragma shader_feature_local _SCROLLINGWAVEDIR_ON
		#pragma shader_feature_local _SCROLLINGDIR_X _SCROLLINGDIR_Y _SCROLLINGDIR_Z
		struct Input
		{
			float3 worldPos;
			half3 worldNormal;
			float2 uv_texcoord;
			float2 uv2_texcoord2;
			float4 vertexColor : COLOR;
		};

		uniform half _fresnelscale;
		uniform half4 _maincolor;
		uniform half _scrollingemissionHz;
		uniform half _scrollingemissionvelocity;
		uniform half _scrollingemissionpow;
		uniform half _dissolveedgewidth;
		uniform sampler2D _dissolvetexture;
		uniform half4 _dissolvetexture_ST;
		uniform half _dissolveedgeintensity;
		uniform half _flickerspeed;
		uniform half _flicker;


		float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }

		float snoise( float2 v )
		{
			const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
			float2 i = floor( v + dot( v, C.yy ) );
			float2 x0 = v - i + dot( i, C.xx );
			float2 i1;
			i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
			float4 x12 = x0.xyxy + C.xxzz;
			x12.xy -= i1;
			i = mod2D289( i );
			float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
			float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
			m = m * m;
			m = m * m;
			float3 x = 2.0 * frac( p * C.www ) - 1.0;
			float3 h = abs( x ) - 0.5;
			float3 ox = floor( x + 0.5 );
			float3 a0 = x - ox;
			m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
			float3 g;
			g.x = a0.x * x0.x + h.x * x0.y;
			g.yz = a0.yz * x12.xz + h.yz * x12.yw;
			return 130.0 * dot( m, g );
		}


		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float3 ase_worldPos = i.worldPos;
			half3 ase_worldViewDir = normalize( UnityWorldSpaceViewDir( ase_worldPos ) );
			half3 ase_worldNormal = i.worldNormal;
			half fresnelNdotV1 = dot( ase_worldNormal, ase_worldViewDir );
			half fresnelNode1 = ( 0.0 + _fresnelscale * pow( max( 1.0 - fresnelNdotV1 , 0.0001 ), 5.0 ) );
			float3 ase_vertex3Pos = mul( unity_WorldToObject, float4( i.worldPos , 1 ) );
			#if defined(_SCROLLINGDIR_X)
				half staticSwitch61 = ase_vertex3Pos.x;
			#elif defined(_SCROLLINGDIR_Y)
				half staticSwitch61 = ase_vertex3Pos.y;
			#elif defined(_SCROLLINGDIR_Z)
				half staticSwitch61 = ase_vertex3Pos.z;
			#else
				half staticSwitch61 = ase_vertex3Pos.x;
			#endif
			half mulTime29 = _Time.y * _scrollingemissionvelocity;
			half temp_output_31_0 = ( ( staticSwitch61 * _scrollingemissionHz ) + mulTime29 );
			#ifdef _SCROLLINGWAVEDIR_ON
				half staticSwitch54 = -temp_output_31_0;
			#else
				half staticSwitch54 = temp_output_31_0;
			#endif
			float2 uv_dissolvetexture = i.uv_texcoord * _dissolvetexture_ST.xy + _dissolvetexture_ST.zw;
			half4 tex2DNode21 = tex2D( _dissolvetexture, uv_dissolvetexture );
			half smoothstepResult40 = smoothstep( tex2DNode21.r , 1.0 , i.uv2_texcoord2.x);
			half temp_output_3_0_g1 = ( _dissolveedgewidth - smoothstepResult40 );
			half mulTime6 = _Time.y * _flickerspeed;
			half2 temp_cast_0 = (mulTime6).xx;
			half simplePerlin2D7 = snoise( temp_cast_0*2.0 );
			simplePerlin2D7 = simplePerlin2D7*0.5 + 0.5;
			half lerpResult8 = lerp( 1.0 , simplePerlin2D7 , _flicker);
			half flicker11 = lerpResult8;
			o.Emission = ( ( ( saturate( fresnelNode1 ) * _maincolor ) + ( _maincolor * pow( frac( staticSwitch54 ) , _scrollingemissionpow ) ) + ( _maincolor * saturate( ( temp_output_3_0_g1 / fwidth( temp_output_3_0_g1 ) ) ) * _dissolveedgeintensity ) ) * flicker11 ).rgb;
			half temp_output_3_0_g2 = ( i.uv2_texcoord2.x - tex2DNode21.r );
			o.Alpha = ( i.vertexColor.a * saturate( ( temp_output_3_0_g2 / fwidth( temp_output_3_0_g2 ) ) ) );
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf Unlit keepalpha fullforwardshadows 

		ENDCG
		Pass
		{
			Name "ShadowCaster"
			Tags{ "LightMode" = "ShadowCaster" }
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#pragma multi_compile_shadowcaster
			#pragma multi_compile UNITY_PASS_SHADOWCASTER
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			#include "HLSLSupport.cginc"
			#if ( SHADER_API_D3D11 || SHADER_API_GLCORE || SHADER_API_GLES || SHADER_API_GLES3 || SHADER_API_METAL || SHADER_API_VULKAN )
				#define CAN_SKIP_VPOS
			#endif
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "UnityPBSLighting.cginc"
			sampler3D _DitherMaskLOD;
			struct v2f
			{
				V2F_SHADOW_CASTER;
				float4 customPack1 : TEXCOORD1;
				float3 worldPos : TEXCOORD2;
				float3 worldNormal : TEXCOORD3;
				half4 color : COLOR0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};
			v2f vert( appdata_full v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_INITIALIZE_OUTPUT( v2f, o );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				Input customInputData;
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				o.worldNormal = worldNormal;
				o.customPack1.xy = customInputData.uv_texcoord;
				o.customPack1.xy = v.texcoord;
				o.customPack1.zw = customInputData.uv2_texcoord2;
				o.customPack1.zw = v.texcoord1;
				o.worldPos = worldPos;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				o.color = v.color;
				return o;
			}
			half4 frag( v2f IN
			#if !defined( CAN_SKIP_VPOS )
			, UNITY_VPOS_TYPE vpos : VPOS
			#endif
			) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				Input surfIN;
				UNITY_INITIALIZE_OUTPUT( Input, surfIN );
				surfIN.uv_texcoord = IN.customPack1.xy;
				surfIN.uv2_texcoord2 = IN.customPack1.zw;
				float3 worldPos = IN.worldPos;
				half3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				surfIN.worldPos = worldPos;
				surfIN.worldNormal = IN.worldNormal;
				surfIN.vertexColor = IN.color;
				SurfaceOutput o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutput, o )
				surf( surfIN, o );
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				half alphaRef = tex3D( _DitherMaskLOD, float3( vpos.xy * 0.25, o.Alpha * 0.9375 ) ).a;
				clip( alphaRef - 0.01 );
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18800
208;92;1173;565;2267.833;567.3334;1.640696;True;False
Node;AmplifyShaderEditor.CommentaryNode;33;-1272.395,-247.2675;Inherit;False;1498.401;529.2573;Comment;12;35;30;36;54;53;31;29;39;57;58;61;66;;1,1,1,1;0;0
Node;AmplifyShaderEditor.PosVertexDataNode;66;-1220.415,-202.1801;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StaticSwitch;61;-981.6619,-206.7456;Inherit;False;Property;_scrollingdir;scrolling dir;13;0;Create;True;0;0;0;False;0;False;0;0;1;True;;KeywordEnum;3;X;Y;Z;Create;True;True;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;58;-1105.849,107.0766;Inherit;False;Property;_scrollingemissionHz;scrolling emission Hz;12;0;Create;True;0;0;0;False;0;False;0;0.33;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;39;-1198.125,-45.57155;Inherit;False;Property;_scrollingemissionvelocity;scrolling emission velocity;10;0;Create;True;0;0;0;False;0;False;0;-0.58;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;29;-961.1312,-54.8611;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;57;-882.0137,44.74269;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;31;-765.7971,-194.5254;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;10;-849.9385,279.8203;Inherit;False;993.92;429.439;Comment;6;9;8;7;6;5;11;;1,1,1,1;0;0
Node;AmplifyShaderEditor.NegateNode;53;-698.9848,-81.52258;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;5;-775.0106,452.5217;Inherit;False;Property;_flickerspeed;flicker speed;6;0;Create;True;0;0;0;False;0;False;1.03;2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;27;-510.0332,-1014.768;Inherit;False;1103.73;744.6034;Comment;7;4;1;12;15;2;3;18;;1,1,1,1;0;0
Node;AmplifyShaderEditor.SamplerNode;21;220.1625,237.7079;Inherit;True;Property;_dissolvetexture;dissolve texture;7;0;Create;True;0;0;0;False;0;False;-1;None;479ebba02d3867341b2ab72448f17e5f;True;0;False;black;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;4;-461.4387,-718.3172;Inherit;False;Property;_fresnelscale;fresnel scale;4;0;Create;True;0;0;0;False;0;False;1;3.35;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;54;-534.8854,-179.0361;Inherit;False;Property;_scrollingwavedir;scrolling wave dir;14;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TexCoordVertexDataNode;23;250.7946,469.6605;Inherit;False;1;2;0;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleTimeNode;6;-799.9385,359.7281;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;7;-584.5736,329.8203;Inherit;True;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.FractNode;30;-280.432,-179.482;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;36;-303.6888,46.09864;Inherit;False;Property;_scrollingemissionpow;scrolling emission pow;11;0;Create;True;0;0;0;False;0;False;0;12.62;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;9;-673.2238,560.47;Inherit;False;Property;_flicker;flicker;5;0;Create;True;0;0;0;False;0;False;0.4893474;0.223;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;40;553.8332,281.5107;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;43;519.9197,512.5057;Inherit;False;Property;_dissolveedgewidth;dissolve edge width;8;0;Create;True;0;0;0;False;0;False;0;0.166;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.FresnelNode;1;-257.3756,-779.9767;Inherit;False;Standard;WorldNormal;ViewDir;True;True;5;0;FLOAT3;0,0,1;False;4;FLOAT3;0,0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;5;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;48;863.5469,292.1252;Inherit;True;Step Antialiasing;-1;;1;2a825e80dfb3290468194f83380797bd;0;2;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;35;-100.6134,-96.5627;Inherit;False;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;15;-27.62679,-740.5435;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;50;79.33264,37.81828;Inherit;False;Property;_dissolveedgeintensity;dissolve edge intensity;9;0;Create;True;0;0;0;False;0;False;0;7.97;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;8;-322.1324,329.7076;Inherit;True;3;0;FLOAT;1;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;2;-264.3942,-567.9514;Inherit;False;Property;_maincolor;main color;1;1;[HDR];Create;True;0;0;0;False;0;False;0,0.1661559,1.765406,0;0,1.166552,4.701352,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;11;-75.47209,590.3599;Inherit;False;flicker;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3;126.0329,-783.888;Inherit;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;49;346.606,-264.26;Inherit;True;3;3;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;32;64.00632,-197.2676;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode;51;632.5084,73.44727;Inherit;True;Step Antialiasing;-1;;2;2a825e80dfb3290468194f83380797bd;0;2;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;18;464.8745,-692.5376;Inherit;True;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;12;402.3916,-385.2016;Inherit;False;11;flicker;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;59;370.8297,3.766777;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;55;672.3659,-574.1728;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;17;574.5375,-109.0088;Inherit;False;Property;_metalic;metalic;2;0;Create;True;0;0;0;False;0;False;0;0.456;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;60;881.8976,29.48088;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;16;606.5375,-23.00881;Inherit;False;Property;_smoothness;smoothness;3;0;Create;True;0;0;0;False;0;False;0;0.781;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;1054.816,-257.7999;Half;False;True;-1;2;ASEMaterialInspector;0;0;Unlit;MetaMonkeys/ScifiPolygons v0.2;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;1;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;True;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;61;1;66;1
WireConnection;61;0;66;2
WireConnection;61;2;66;3
WireConnection;29;0;39;0
WireConnection;57;0;61;0
WireConnection;57;1;58;0
WireConnection;31;0;57;0
WireConnection;31;1;29;0
WireConnection;53;0;31;0
WireConnection;54;1;31;0
WireConnection;54;0;53;0
WireConnection;6;0;5;0
WireConnection;7;0;6;0
WireConnection;30;0;54;0
WireConnection;40;0;23;1
WireConnection;40;1;21;1
WireConnection;1;2;4;0
WireConnection;48;1;40;0
WireConnection;48;2;43;0
WireConnection;35;0;30;0
WireConnection;35;1;36;0
WireConnection;15;0;1;0
WireConnection;8;1;7;0
WireConnection;8;2;9;0
WireConnection;11;0;8;0
WireConnection;3;0;15;0
WireConnection;3;1;2;0
WireConnection;49;0;2;0
WireConnection;49;1;48;0
WireConnection;49;2;50;0
WireConnection;32;0;2;0
WireConnection;32;1;35;0
WireConnection;51;1;21;1
WireConnection;51;2;23;1
WireConnection;18;0;3;0
WireConnection;18;1;32;0
WireConnection;18;2;49;0
WireConnection;55;0;18;0
WireConnection;55;1;12;0
WireConnection;60;0;59;4
WireConnection;60;1;51;0
WireConnection;0;2;55;0
WireConnection;0;9;60;0
ASEEND*/
//CHKSM=B6FA25C909BBA7F0BC72D585B01B756126BD35A3