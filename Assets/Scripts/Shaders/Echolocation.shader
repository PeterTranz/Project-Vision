Shader "Hidden/Echolocation" {

	Properties{
		EchoBaseColor("Base Color",  Color) = (0.1, 0.1, 0.1, 0)
		EchoWaveColor("Wave Color",  Color) = (1.0, 0.1, 0.1, 0)
		EchoWaveParams("Wave Params", Vector) = (1, 20, 20, 10)
		EchoWaveVector("Wave Vector", Vector) = (0, 0, 1, 0)
		EchoAddColor("Add Color",   Color) = (0, 0, 0, 0)
	}

		SubShader{
		Tags{ "RenderType" = "Opaque" }

		CGPROGRAM

#pragma surface surf Lambert
#pragma multi_compile SONAR_SPHERICAL

		struct Input {
		float3 worldPos;
	};

	float3 EchoBaseColor;
	float3 EchoWaveColor;
	float4 EchoWaveParams; // Amp, Exp, Interval, Speed
	float3 EchoWaveVector;
	float3 EchoAddColor;

	void surf(Input IN, inout SurfaceOutput o) {

		float w = length(IN.worldPos - EchoWaveVector);

		// Moving wave.
		w -= _Time.y * EchoWaveParams.w;

		// Get modulo (w % params.z / params.z)
		w /= EchoWaveParams.z;
		w = w - floor(w);

		// Make the gradient steeper.
		float p = EchoWaveParams.y;
		w = (pow(w, p) + pow(1 - w, p * 4)) * 0.5;

		// Amplify.
		w *= EchoWaveParams.x;

		// Apply to the surface.
		o.Albedo = EchoBaseColor;
		o.Emission = EchoWaveColor * w + EchoAddColor;
	}
	ENDCG
	}
	Fallback "Diffuse"
}