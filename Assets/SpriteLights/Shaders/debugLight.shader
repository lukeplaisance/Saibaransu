﻿//This shader is only to be used to quickly iterate on the variables and is not optimized for speed. Use for debugging only.
Shader "Lights/Debug"{

    Properties{

        _MainTex ("Texture", 2D) = "white" {}
        [HDR]_FrontColor ("Front Color", Color) = (0.5,0.5,0.5,0.5)
        [HDR]_BackColor ("Back Color", Color) = (0.5,0.5,0.5,0.5)
        [Enum(Teardrop, 0, Round, 1, Egg, 2, Equal, 3)] _Lobe ("Radiation pattern", Float) = 0    
        _Transition ("Transition Degrees", Range(0, 45)) = 10.0
        _Scale ("Scale", FLOAT) = 1.0
        _MinPixelSize ("Minimum screen size", FLOAT) = 5.0
        [Toggle] _TranslateUp ("Translate Up", Float) = 1
        _Attenuation ("Attenuation", Range(0.0, 1)) = 0.37
        _Brightness ("Brightness", Range(0, 1)) = 0
    }	

    SubShader{

        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
        Blend SrcAlpha One
        AlphaTest Greater .01
        ColorMask RGB
        Lighting Off ZWrite Off        
		
        Pass{

            CGPROGRAM
            
            #include "UnityCG.cginc"
            #include "lightFunctions.cginc"

            #pragma vertex vert  
            #pragma fragment frag          
            #pragma multi_compile_fog //Enable fog
            #pragma glsl_no_auto_normalization
          //  #pragma enable_d3d11_debug_symbols //For debugging.
  
            uniform sampler2D _MainTex;   
                 
            float _Scale;
            float _MinPixelSize;
            half4 _FrontColor;
            half4 _BackColor;
            float _Attenuation;
            float _Brightness;
            float _Transition;
            float _Lobe;
            float _TranslateUp;

            //These global variables are set from a Unity script.
            float _ScaleFactor; 
            float _GlobalBrightnessOffset;

            struct vertexInput {

                float4 center : POSITION; //Mesh center position is stored in the position channel (vertices in Unity).
                float4 corner : TANGENT; //Mesh corner is stored in the tangent channel (tangent in Unity).
                float4 normal : NORMAL; //Rotation forward vector is stored in the Normal channel (normals in Unity).
                float2 uvs : TEXCOORD0; //Texture coordinates (uv in Unity).   
            };

            struct vertexOutput{

                float4 pos : SV_POSITION;
                float2 uvs : TEXCOORD0;                
                half4 color : COLOR;

                //This is not a UV coordinate but it is just used to pass some variables
                //from the vertex shader to the fragment shader. x = gain.
                float2 container : TEXCOORD1;

                //Enable fog
                UNITY_FOG_COORDS(2)
            };			

            vertexOutput vert(vertexInput input){

                vertexOutput output;
                float gain;
                float distanceGain;
                float angleGain;
                float dotProduct;
                float3 viewDir;
                float scale;
                float side; 

                //Get a vector from the vertex to the camera and cache the result.
                float3 objSpaceViewDir = ObjSpaceViewDir(input.center);

                //Get the distance between the camera and the light.
                float distance = length(objSpaceViewDir);

                viewDir = normalize(objSpaceViewDir);

                //This is used to determine the light viewing angle.
                dotProduct = dot(viewDir, input.normal); 

                //Make light visible from the backside as well. Use this rather than Cull Off because
                //that can't be switched off using a preprocessor.
                side = sign(dotProduct);

                //Make sure the angle is always positive.
                dotProduct = abs(dotProduct); 

                //Convert from range -1, 1 to 0, 1
                float clampedSide = clamp(side, 0.0f, 1.0f);

                float forwardDotProduct = dot(viewDir, input.normal); 

                if(_Transition <= 0){
                    //No smooth transition.
                    output.color = lerp(_BackColor, _FrontColor, clampedSide);
                }

                else{
                    //Create a smooth transition between the two colors.       
                    output.color = GetVariableDegreeTransition(_Transition, forwardDotProduct, _FrontColor, _BackColor);
                }

                //Use a Phase Function to simulate the light lens shape and its effect it has on the light brightness.  
                if(_Lobe == 0){   
                    angleGain = GetTearDropLobe(dotProduct);
                }

                if(_Lobe == 1){  
                    angleGain = GetRoundLobe(dotProduct);
                }

                if(_Lobe == 2){  
                    angleGain = GetEggLobe(dotProduct);
                }

                if(_Lobe == 3){  
                    angleGain = GetEqualLobe();
                }

                //Calculate the scale. If the light size is smaller then one pixel, scale it up
                //so it remains at least one pixel in size.
                scale = ScaleUp(distance, _ScaleFactor, _Scale, angleGain, _MinPixelSize);

                //Get the vertex offset to shift and scale the light.
                float4 offset = GetOffsetDebug(scale, input.corner * _Scale, _TranslateUp);

                //Rotate the billboard towards the camera.
                output.pos = mul(UNITY_MATRIX_P, mul(UNITY_MATRIX_MV, input.center) + offset);

                //Far away lights should be less bright. Attenuate with the inverse square law.
                distanceGain = Attenuate(distance, _Attenuation);

                //Merge the distance gain (attenuation), angle gain (lens simulation), and light brightness into a single gain value.
                gain = MergeGain(distanceGain, angleGain, _GlobalBrightnessOffset, _Brightness);

                //Send the gain to the fragment shader.
                output.container = float2(gain, 0.0f);

                //UV mapping.
                output.uvs = input.uvs;

                //Enable fog
                UNITY_TRANSFER_FOG(output, output.pos);

                return output;
            }

            half4 frag(vertexOutput input) : COLOR{

                //Compute the final color.
                //Note: input.container.x fetches the gain from the vertex shader. No need to calculate this for each fragment.
				half4 col = 2.0f * input.color * tex2D(_MainTex, input.uvs) * (exp(input.container.x * 5.0f));		
                
                //Enable fog. Use black due to the blend mode used.
				UNITY_APPLY_FOG_COLOR(input.fogCoord, col, half4(0,0,0,0)); 
                	
				return col;
            }

	        ENDCG
        }        
    }
	
    FallBack "Diffuse"
}
