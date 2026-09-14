using System;
using UnityEngine;

// Token: 0x02000586 RID: 1414
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/BOL Outline")]
[ExecuteInEditMode]
public class BOL_Outline : MonoBehaviour
{
	// Token: 0x06002449 RID: 9289 RVA: 0x000AD13C File Offset: 0x000AB33C
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

	// Token: 0x0600244A RID: 9290 RVA: 0x00018CAE File Offset: 0x00016EAE
	private static void smethod_1(Material material_0)
	{
		if (material_0)
		{
			global::UnityEngine.Object.DestroyImmediate(material_0);
			material_0 = null;
		}
	}

	// Token: 0x0600244B RID: 9291 RVA: 0x00018CC3 File Offset: 0x00016EC3
	private void OnDisable()
	{
		BOL_Outline.smethod_1(this.m_BOL_Outline_Material);
	}

	// Token: 0x0600244C RID: 9292 RVA: 0x000AD164 File Offset: 0x000AB364
	private void Start()
	{
		if (SystemInfo.supportsImageEffects && SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Depth))
		{
			this.method_0();
			if (this.m_BOL_Outline_Material)
			{
				if (this.m_BOL_Outline_Material.passCount == 6)
				{
					return;
				}
			}
			base.enabled = false;
			return;
		}
		base.enabled = false;
	}

	// Token: 0x0600244D RID: 9293 RVA: 0x00018CD0 File Offset: 0x00016ED0
	private void OnEnable()
	{
		base.camera.depthTextureMode |= DepthTextureMode.DepthNormals;
	}

	// Token: 0x0600244E RID: 9294 RVA: 0x000AD1B4 File Offset: 0x000AB3B4
	private void method_0()
	{
		if (!this.m_BOL_Outline_Material && this.m_BOL_Outline_Shader.isSupported)
		{
			this.m_BOL_Outline_Material = BOL_Outline.smethod_0(this.m_BOL_Outline_Shader);
			this.m_BOL_Outline_Material.SetTexture("_RandomTexture", this.m_RandomTexture);
		}
	}

	// Token: 0x0600244F RID: 9295 RVA: 0x000AD204 File Offset: 0x000AB404
	[ImageEffectOpaque]
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		this.method_0();
		RenderTexture renderTexture;
		RenderTexture renderTexture2;
		if (this.m_AntiAliasSwitch == BOL_Outline.AntiAliasSwitch.AntiAliasingOn)
		{
			renderTexture = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.ARGBHalf);
			renderTexture2 = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.ARGBHalf);
		}
		else
		{
			renderTexture = RenderTexture.GetTemporary(source.width, source.height, 0);
			renderTexture2 = RenderTexture.GetTemporary(source.width, source.height, 0);
		}
		renderTexture.name = "BOL_Outline_rtEC0";
		renderTexture2.name = "BOL_Outline_rtEC1";
		renderTexture.filterMode = FilterMode.Point;
		renderTexture2.filterMode = FilterMode.Point;
		Graphics.Blit(source, renderTexture, this.m_BOL_Outline_Material, 0);
		this.m_BOL_Outline_Material.SetFloat("_Step", 1f);
		this.m_BOL_Outline_Material.SetTexture("_BOL", renderTexture);
		Graphics.Blit(source, renderTexture2, this.m_BOL_Outline_Material, 1);
		this.m_BOL_Outline_Material.SetFloat("_Step", 2f);
		this.m_BOL_Outline_Material.SetTexture("_BOL", renderTexture2);
		Graphics.Blit(source, renderTexture, this.m_BOL_Outline_Material, 1);
		this.m_BOL_Outline_Material.SetFloat("_Step", 4f);
		this.m_BOL_Outline_Material.SetTexture("_BOL", renderTexture);
		Graphics.Blit(source, renderTexture2, this.m_BOL_Outline_Material, 1);
		this.m_BOL_Outline_Material.SetFloat("_Step", 8f);
		this.m_BOL_Outline_Material.SetTexture("_BOL", renderTexture2);
		Graphics.Blit(source, renderTexture, this.m_BOL_Outline_Material, 1);
		this.m_BOL_Outline_Material.SetFloat("_Step", 16f);
		this.m_BOL_Outline_Material.SetTexture("_BOL", renderTexture);
		Graphics.Blit(source, renderTexture2, this.m_BOL_Outline_Material, 1);
		if (this.m_AntiAliasSwitch == BOL_Outline.AntiAliasSwitch.AntiAliasingOn)
		{
			this.m_BOL_Outline_Material.SetTexture("_BOL", renderTexture2);
			Graphics.Blit(source, renderTexture, this.m_BOL_Outline_Material, 2);
			this.m_BOL_Outline_Material.SetTexture("_NoiseTex", this.m_RandomTexture);
			this.m_BOL_Outline_Material.SetTexture("_BOL", renderTexture);
		}
		else
		{
			this.m_BOL_Outline_Material.SetTexture("_NoiseTex", this.m_RandomTexture);
			this.m_BOL_Outline_Material.SetTexture("_BOL", renderTexture2);
		}
		this.m_LineWidth = Mathf.Clamp(this.m_LineWidth, 1f, 3f);
		this.m_LineSoftness = Mathf.Clamp(this.m_LineSoftness, 0f, 2f);
		if (this.m_AntiRimLightingSwitch == BOL_Outline.AntiRimLightingSwitch.AntiRimLighting_OFF)
		{
			this.m_BOL_Outline_Material.SetFloat("_AntiRimParam", 0f);
		}
		else if (this.m_AntiRimLightingSwitch == BOL_Outline.AntiRimLightingSwitch.AntiRimLighting_ON2)
		{
			this.m_BOL_Outline_Material.SetFloat("_AntiRimParam", 2f);
		}
		if (this.m_ArtStyleSwitch == BOL_Outline.ArtStyleSwitch.ArtStyle_BOL)
		{
			this.m_BOL_Outline_Material.SetFloat("_LineWidth", (this.m_LineWidth - 1f) * 0.5f);
			this.m_BOL_Outline_Material.SetFloat("_LineSoftness", this.m_LineSoftness + 1f);
			Graphics.Blit(source, destination, this.m_BOL_Outline_Material, 3);
		}
		else if (this.m_ArtStyleSwitch == BOL_Outline.ArtStyleSwitch.ArtStyle_Lines)
		{
			this.m_BOL_Outline_Material.SetFloat("_LineWidth", (this.m_LineWidth - 1f) * 0.5f);
			this.m_BOL_Outline_Material.SetFloat("_LineSoftness", this.m_LineSoftness + 1f);
			Graphics.Blit(source, destination, this.m_BOL_Outline_Material, 4);
		}
		else if (this.m_ArtStyleSwitch == BOL_Outline.ArtStyleSwitch.ArtStyle_Brush)
		{
			Graphics.Blit(source, destination, this.m_BOL_Outline_Material, 5);
		}
		RenderTexture.ReleaseTemporary(renderTexture);
		RenderTexture.ReleaseTemporary(renderTexture2);
	}

	// Token: 0x04001906 RID: 6406
	public Shader m_BOL_Outline_Shader;

	// Token: 0x04001907 RID: 6407
	private Material m_BOL_Outline_Material;

	// Token: 0x04001908 RID: 6408
	public Texture2D m_RandomTexture;

	// Token: 0x04001909 RID: 6409
	public BOL_Outline.AntiAliasSwitch m_AntiAliasSwitch = BOL_Outline.AntiAliasSwitch.AntiAliasingOn;

	// Token: 0x0400190A RID: 6410
	public BOL_Outline.ArtStyleSwitch m_ArtStyleSwitch;

	// Token: 0x0400190B RID: 6411
	public float m_LineWidth = 1.5f;

	// Token: 0x0400190C RID: 6412
	public float m_LineSoftness = 0.5f;

	// Token: 0x0400190D RID: 6413
	public BOL_Outline.AntiRimLightingSwitch m_AntiRimLightingSwitch = BOL_Outline.AntiRimLightingSwitch.AntiRimLighting_ON2;

	// Token: 0x02000587 RID: 1415
	public enum AntiAliasSwitch
	{
		// Token: 0x0400190F RID: 6415
		AntiAliasingOff,
		// Token: 0x04001910 RID: 6416
		AntiAliasingOn
	}

	// Token: 0x02000588 RID: 1416
	public enum ArtStyleSwitch
	{
		// Token: 0x04001912 RID: 6418
		ArtStyle_BOL,
		// Token: 0x04001913 RID: 6419
		ArtStyle_Lines,
		// Token: 0x04001914 RID: 6420
		ArtStyle_Brush
	}

	// Token: 0x02000589 RID: 1417
	public enum AntiRimLightingSwitch
	{
		// Token: 0x04001916 RID: 6422
		AntiRimLighting_OFF,
		// Token: 0x04001917 RID: 6423
		AntiRimLighting_ON2
	}
}
