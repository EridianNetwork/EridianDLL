using System;
using UnityEngine;

// Token: 0x020005B9 RID: 1465
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Screen Space Ambient Occlusion")]
[ExecuteInEditMode]
public class SSAOEffect : MonoBehaviour
{
	// Token: 0x06002535 RID: 9525 RVA: 0x000AD13C File Offset: 0x000AB33C
	private static Material smethod_0(Shader shader_0)
	{
		if (!shader_0)
		{
			return null;
		}
		return new Material(shader_0)
		{
			hideFlags = HideFlags.HideAndDontSave
		};
	}

	// Token: 0x06002536 RID: 9526 RVA: 0x00018CAE File Offset: 0x00016EAE
	private static void smethod_1(Material material_0)
	{
		if (material_0)
		{
			global::UnityEngine.Object.DestroyImmediate(material_0);
			material_0 = null;
		}
	}

	// Token: 0x06002537 RID: 9527 RVA: 0x000194C8 File Offset: 0x000176C8
	private void OnDisable()
	{
		SSAOEffect.smethod_1(this.m_SSAOMaterial);
	}

	// Token: 0x06002538 RID: 9528 RVA: 0x000B2F14 File Offset: 0x000B1114
	private void Start()
	{
		if (SystemInfo.supportsImageEffects && SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Depth))
		{
			this.method_0();
			if (this.m_SSAOMaterial)
			{
				if (this.m_SSAOMaterial.passCount == 5)
				{
					this.m_Supported = true;
					return;
				}
			}
			this.m_Supported = false;
			base.enabled = false;
			return;
		}
		this.m_Supported = false;
		base.enabled = false;
	}

	// Token: 0x06002539 RID: 9529 RVA: 0x00018CD0 File Offset: 0x00016ED0
	private void OnEnable()
	{
		base.camera.depthTextureMode |= DepthTextureMode.DepthNormals;
	}

	// Token: 0x0600253A RID: 9530 RVA: 0x000B2F78 File Offset: 0x000B1178
	private void method_0()
	{
		if (!this.m_SSAOMaterial && this.m_SSAOShader.isSupported)
		{
			this.m_SSAOMaterial = SSAOEffect.smethod_0(this.m_SSAOShader);
			this.m_SSAOMaterial.SetTexture("_RandomTexture", this.m_RandomTexture);
		}
	}

	// Token: 0x0600253B RID: 9531 RVA: 0x000B2FC8 File Offset: 0x000B11C8
	[ImageEffectOpaque]
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (this.m_Supported && this.m_SSAOShader.isSupported)
		{
			this.method_0();
			this.m_Downsampling = Mathf.Clamp(this.m_Downsampling, 1, 6);
			this.m_Radius = Mathf.Clamp(this.m_Radius, 0.05f, 1f);
			this.m_MinZ = Mathf.Clamp(this.m_MinZ, 1E-05f, 0.5f);
			this.m_OcclusionIntensity = Mathf.Clamp(this.m_OcclusionIntensity, 0.5f, 4f);
			this.m_OcclusionAttenuation = Mathf.Clamp(this.m_OcclusionAttenuation, 0.2f, 2f);
			this.m_Blur = Mathf.Clamp(this.m_Blur, 0, 4);
			RenderTexture renderTexture = RenderTexture.GetTemporary(source.width / this.m_Downsampling, source.height / this.m_Downsampling, 0);
			renderTexture.name = "SSAOEffect_rtAO";
			float fieldOfView = base.camera.fieldOfView;
			float farClipPlane = base.camera.farClipPlane;
			float num = Mathf.Tan(fieldOfView * 0.017453292f * 0.5f) * farClipPlane;
			float num2 = num * base.camera.aspect;
			this.m_SSAOMaterial.SetVector("_FarCorner", new Vector3(num2, num, farClipPlane));
			int num3;
			int num4;
			if (this.m_RandomTexture)
			{
				num3 = this.m_RandomTexture.width;
				num4 = this.m_RandomTexture.height;
			}
			else
			{
				num3 = 1;
				num4 = 1;
			}
			this.m_SSAOMaterial.SetVector("_NoiseScale", new Vector3((float)renderTexture.width / (float)num3, (float)renderTexture.height / (float)num4, 0f));
			this.m_SSAOMaterial.SetVector("_Params", new Vector4(this.m_Radius, this.m_MinZ, 1f / this.m_OcclusionAttenuation, this.m_OcclusionIntensity));
			this.m_SSAOMaterial.SetFloat("_NoSsaoDist", this.m_NoSsaoDist);
			bool flag;
			Graphics.Blit((!(flag = this.m_Blur > 0)) ? source : null, renderTexture, this.m_SSAOMaterial, (int)this.m_SampleCount);
			if (flag)
			{
				RenderTexture temporary = RenderTexture.GetTemporary(source.width, source.height, 0);
				temporary.name = "SSAOEffect_rtBlurX";
				this.m_SSAOMaterial.SetVector("_TexelOffsetScale", new Vector4((float)this.m_Blur / (float)source.width, 0f, 0f, 0f));
				this.m_SSAOMaterial.SetTexture("_SSAO", renderTexture);
				Graphics.Blit(null, temporary, this.m_SSAOMaterial, 3);
				RenderTexture.ReleaseTemporary(renderTexture);
				RenderTexture temporary2 = RenderTexture.GetTemporary(source.width, source.height, 0);
				temporary2.name = "SSAOEffect_rtBlurY";
				this.m_SSAOMaterial.SetVector("_TexelOffsetScale", new Vector4(0f, (float)this.m_Blur / (float)source.height, 0f, 0f));
				this.m_SSAOMaterial.SetTexture("_SSAO", temporary);
				Graphics.Blit(source, temporary2, this.m_SSAOMaterial, 3);
				RenderTexture.ReleaseTemporary(temporary);
				renderTexture = temporary2;
			}
			this.m_SSAOMaterial.SetTexture("_SSAO", renderTexture);
			Graphics.Blit(source, destination, this.m_SSAOMaterial, 4);
			RenderTexture.ReleaseTemporary(renderTexture);
			return;
		}
		base.enabled = false;
	}

	// Token: 0x04001A93 RID: 6803
	public float m_Radius = 0.4f;

	// Token: 0x04001A94 RID: 6804
	public SSAOEffect.SSAOSamples m_SampleCount = SSAOEffect.SSAOSamples.Medium;

	// Token: 0x04001A95 RID: 6805
	public float m_OcclusionIntensity = 1.5f;

	// Token: 0x04001A96 RID: 6806
	public int m_Blur = 2;

	// Token: 0x04001A97 RID: 6807
	public int m_Downsampling = 2;

	// Token: 0x04001A98 RID: 6808
	public float m_OcclusionAttenuation = 1f;

	// Token: 0x04001A99 RID: 6809
	public float m_MinZ = 0.01f;

	// Token: 0x04001A9A RID: 6810
	public float m_NoSsaoDist = 50f;

	// Token: 0x04001A9B RID: 6811
	public Shader m_SSAOShader;

	// Token: 0x04001A9C RID: 6812
	private Material m_SSAOMaterial;

	// Token: 0x04001A9D RID: 6813
	public Texture2D m_RandomTexture;

	// Token: 0x04001A9E RID: 6814
	private bool m_Supported;

	// Token: 0x020005BA RID: 1466
	public enum SSAOSamples
	{
		// Token: 0x04001AA0 RID: 6816
		Low,
		// Token: 0x04001AA1 RID: 6817
		Medium,
		// Token: 0x04001AA2 RID: 6818
		High
	}
}
