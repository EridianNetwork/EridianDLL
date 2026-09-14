using System;
using UnityEngine;

// Token: 0x020005B2 RID: 1458
[AddComponentMenu("Image Effects/Font Outline")]
[ExecuteInEditMode]
public class FontOutline : PostEffectsBase
{
	// Token: 0x06002510 RID: 9488 RVA: 0x00019266 File Offset: 0x00017466
	private void OnDestroy()
	{
		global::UnityEngine.Object.Destroy(this.edgeDetectMaterial);
		global::UnityEngine.Object.Destroy(this.screenBlendMaterial);
		global::UnityEngine.Object.Destroy(this.separableBlurMaterial);
	}

	// Token: 0x06002511 RID: 9489 RVA: 0x000B202C File Offset: 0x000B022C
	private void OnDisable()
	{
		if (this.edgeDetectMaterial)
		{
			global::UnityEngine.Object.DestroyImmediate(this.edgeDetectMaterial);
		}
		if (this.screenBlendMaterial)
		{
			global::UnityEngine.Object.DestroyImmediate(this.screenBlendMaterial);
		}
		if (this.separableBlurMaterial)
		{
			global::UnityEngine.Object.DestroyImmediate(this.separableBlurMaterial);
		}
	}

	// Token: 0x06002512 RID: 9490 RVA: 0x000B2084 File Offset: 0x000B0284
	public override bool CheckResources()
	{
		this.CheckSupport(true);
		this.edgeDetectMaterial = this.CheckShaderAndCreateMaterial(this.edgeDetectShader, this.edgeDetectMaterial);
		this.screenBlendMaterial = this.CheckShaderAndCreateMaterial(this.screenBlendShader, this.screenBlendMaterial);
		this.separableBlurMaterial = this.CheckShaderAndCreateMaterial(this.separableBlurShader, this.separableBlurMaterial);
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x06002513 RID: 9491 RVA: 0x00019289 File Offset: 0x00017489
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources())
		{
			Graphics.Blit(source, destination);
			return;
		}
		this.method_0(source, destination);
	}

	// Token: 0x06002514 RID: 9492 RVA: 0x000B20F8 File Offset: 0x000B02F8
	protected void method_0(RenderTexture renderTexture_0, RenderTexture renderTexture_1)
	{
		this.edgeDetectMaterial.SetFloat("_SampleDistance", this.sampleDist);
		this.edgeDetectMaterial.SetFloat("_Exponent", this.edgeExp);
		this.edgeDetectMaterial.SetColor("_OutlineColor", this.edgeColor);
		this.edgeDetectMaterial.SetFloat("_BgFade", this.edgesOnly);
		this.edgeDetectMaterial.SetVector("_BgFadeColor", this.edgesOnlyBgColor);
		RenderTexture renderTexture = RenderTexture.GetTemporary(renderTexture_0.width, renderTexture_0.height, 0, renderTexture_0.format);
		renderTexture.filterMode = FilterMode.Bilinear;
		Graphics.Blit(renderTexture_0, renderTexture, this.edgeDetectMaterial, 0);
		float num = 1f / (1f * (float)(1 << this.downsample));
		this.edgeDetectMaterial.SetFloat("_Parameter", this.blursize * num);
		RenderTexture renderTexture2 = renderTexture;
		int num2 = renderTexture2.width >> this.downsample;
		int num3 = renderTexture2.height >> this.downsample;
		renderTexture = RenderTexture.GetTemporary(num2, num3, 0, renderTexture_0.format);
		renderTexture.filterMode = FilterMode.Bilinear;
		renderTexture2.filterMode = FilterMode.Bilinear;
		Graphics.Blit(renderTexture2, renderTexture, this.edgeDetectMaterial, 1);
		RenderTexture.ReleaseTemporary(renderTexture2);
		for (int i = 0; i < this.fontBlurIterations; i++)
		{
			float num4 = (float)i * 1f;
			this.edgeDetectMaterial.SetFloat("_Parameter", this.blursize * num + num4);
			RenderTexture renderTexture3 = RenderTexture.GetTemporary(num2, num3, 0, renderTexture_0.format);
			renderTexture3.filterMode = FilterMode.Bilinear;
			Graphics.Blit(renderTexture, renderTexture3, this.edgeDetectMaterial, 2);
			RenderTexture.ReleaseTemporary(renderTexture);
			renderTexture = renderTexture3;
			renderTexture3 = RenderTexture.GetTemporary(num2, num3, 0, renderTexture_0.format);
			renderTexture3.filterMode = FilterMode.Bilinear;
			Graphics.Blit(renderTexture, renderTexture3, this.edgeDetectMaterial, 3);
			RenderTexture.ReleaseTemporary(renderTexture);
			renderTexture = renderTexture3;
		}
		if (this.outBloomIterations > 0)
		{
			RenderTexture temporary = RenderTexture.GetTemporary((int)(0.5 * (double)renderTexture_0.width), (int)(0.5 * (double)renderTexture_0.height), 0, renderTexture_0.format);
			RenderTexture temporary2 = RenderTexture.GetTemporary((int)(0.25 * (double)renderTexture_0.width), (int)(0.25 * (double)renderTexture_0.height), 0, renderTexture_0.format);
			RenderTexture temporary3 = RenderTexture.GetTemporary((int)(0.25 * (double)renderTexture_0.width), (int)(0.25 * (double)renderTexture_0.height), 0, renderTexture_0.format);
			float num5 = 1f * (float)renderTexture_0.width / (1f * (float)renderTexture_0.height);
			float num6 = 0.001953125f;
			Graphics.Blit(renderTexture_0, temporary, this.screenBlendMaterial, 2);
			Graphics.Blit(temporary, temporary2, this.screenBlendMaterial, 2);
			Graphics.Blit(renderTexture, temporary2);
			for (int j = 0; j < this.outBloomIterations; j++)
			{
				float num7 = (1f + (float)j * 0.5f) * this.outSpeBlurSpread;
				this.separableBlurMaterial.SetVector("offsets", new Vector4(0f, num7 * num6, 0f, 0f));
				Graphics.Blit(temporary2, temporary3, this.separableBlurMaterial);
				this.separableBlurMaterial.SetVector("offsets", new Vector4(num7 / num5 * num6, 0f, 0f, 0f));
				Graphics.Blit(temporary3, temporary2, this.separableBlurMaterial);
			}
			this.edgeDetectMaterial.SetFloat("_Intensity", this.bloomIntensity);
			this.edgeDetectMaterial.SetTexture("_OriTex", renderTexture_0);
			Graphics.Blit(temporary2, renderTexture_1, this.edgeDetectMaterial, 5);
			RenderTexture.ReleaseTemporary(temporary);
			RenderTexture.ReleaseTemporary(temporary2);
			RenderTexture.ReleaseTemporary(temporary3);
		}
		else
		{
			this.edgeDetectMaterial.SetTexture("_OriTex", renderTexture_0);
			Graphics.Blit(renderTexture, renderTexture_1, this.edgeDetectMaterial, 4);
		}
		RenderTexture.ReleaseTemporary(renderTexture);
	}

	// Token: 0x04001A5F RID: 6751
	public float sampleDist = 1f;

	// Token: 0x04001A60 RID: 6752
	public Shader edgeDetectShader;

	// Token: 0x04001A61 RID: 6753
	public Shader screenBlendShader;

	// Token: 0x04001A62 RID: 6754
	public Shader separableBlurShader;

	// Token: 0x04001A63 RID: 6755
	public float edgeExp = 1f;

	// Token: 0x04001A64 RID: 6756
	public Color edgeColor = Color.black;

	// Token: 0x04001A65 RID: 6757
	[Range(0f, 2f)]
	public int downsample = 1;

	// Token: 0x04001A66 RID: 6758
	[Range(0f, 10f)]
	public float blursize = 3f;

	// Token: 0x04001A67 RID: 6759
	[Range(0f, 4f)]
	public int fontBlurIterations = 2;

	// Token: 0x04001A68 RID: 6760
	[Range(0f, 6f)]
	public int outBloomIterations;

	// Token: 0x04001A69 RID: 6761
	public float bloomIntensity = 1f;

	// Token: 0x04001A6A RID: 6762
	[Range(0.1f, 10f)]
	public float outSpeBlurSpread = 1.5f;

	// Token: 0x04001A6B RID: 6763
	[Range(0f, 1f)]
	public float edgesOnly;

	// Token: 0x04001A6C RID: 6764
	public Color edgesOnlyBgColor = Color.white;

	// Token: 0x04001A6D RID: 6765
	protected Material edgeDetectMaterial;

	// Token: 0x04001A6E RID: 6766
	protected Material screenBlendMaterial;

	// Token: 0x04001A6F RID: 6767
	protected Material separableBlurMaterial;
}
