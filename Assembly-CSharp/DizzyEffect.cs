using System;
using UnityEngine;

// Token: 0x020005B0 RID: 1456
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Dizzy")]
public class DizzyEffect : MonoBehaviour
{
	// Token: 0x06002509 RID: 9481 RVA: 0x000B1C5C File Offset: 0x000AFE5C
	private void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			this.m_bSupported = false;
			base.enabled = false;
			return;
		}
		if (this.BlurShader == null)
		{
			this.m_bSupported = false;
			base.enabled = false;
			return;
		}
		this.m_blurMaterial = new Material(this.BlurShader);
		if (this.m_blurMaterial == null)
		{
			this.m_bSupported = false;
			base.enabled = false;
			return;
		}
		this.m_blurMaterial.hideFlags = HideFlags.HideAndDontSave;
		this.m_bSupported = true;
		this.m_currentTime = 0f;
	}

	// Token: 0x0600250A RID: 9482 RVA: 0x00019214 File Offset: 0x00017414
	private void Update()
	{
		this.m_currentTime += Time.deltaTime;
		if (this.m_currentTime > this.TotalDuration)
		{
			base.enabled = false;
		}
	}

	// Token: 0x0600250B RID: 9483 RVA: 0x0001923D File Offset: 0x0001743D
	private void method_0()
	{
		global::UnityEngine.Object.DestroyImmediate(this.m_blurMaterial);
		this.m_blurMaterial = null;
	}

	// Token: 0x0600250C RID: 9484 RVA: 0x00019251 File Offset: 0x00017451
	private void OnDestroy()
	{
		this.method_0();
	}

	// Token: 0x0600250D RID: 9485 RVA: 0x00019259 File Offset: 0x00017459
	private void OnEnable()
	{
		this.m_currentTime = 0f;
	}

	// Token: 0x0600250E RID: 9486 RVA: 0x000B1CEC File Offset: 0x000AFEEC
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (this.m_bSupported && this.BlurShader.isSupported)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(source.width / 2, source.height / 2, 0);
			RenderTexture temporary2 = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
			RenderTexture temporary3 = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
			RenderTexture temporary4 = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
			float num = 1f * (float)source.width / (1f * (float)source.height);
			float num2 = 0.001953125f;
			if (this.BlurQualityValue > DizzyEffect.BlurQuality.Cheap)
			{
				Graphics.Blit(source, temporary, this.m_blurMaterial, 5);
				Graphics.Blit(temporary, temporary3, this.m_blurMaterial, 5);
				Graphics.Blit(temporary3, temporary2, this.m_blurMaterial, 6);
			}
			else
			{
				Graphics.Blit(source, temporary);
				Graphics.Blit(temporary, temporary2, this.m_blurMaterial, 6);
			}
			this.BlurIterations = Mathf.Clamp(this.BlurIterations, 1, 10);
			this.BlurPass = Mathf.Clamp(this.BlurPass, 0, 4);
			for (int i = 0; i < this.BlurIterations; i++)
			{
				float num3 = (1f + (float)i * 0.25f) * this.SepBlurSpread;
				this.m_blurMaterial.SetVector("_Offsets", new Vector4(0f, num3 * num2, 0f, 0f));
				Graphics.Blit(temporary3, temporary4, this.m_blurMaterial, this.BlurPass);
				if (this.BlurQualityValue > DizzyEffect.BlurQuality.Cheap)
				{
					this.m_blurMaterial.SetVector("_Offsets", new Vector4(num3 / num * num2, 0f, 0f, 0f));
					Graphics.Blit(temporary4, temporary3, this.m_blurMaterial, this.BlurPass);
					if (i == 0)
					{
						Graphics.Blit(temporary3, temporary2);
					}
					else
					{
						Graphics.Blit(temporary3, temporary2, this.m_blurMaterial, 7);
					}
				}
				else
				{
					this.m_blurMaterial.SetVector("_Offsets", new Vector4(num3 / num * num2, 0f, 0f, 0f));
					Graphics.Blit(temporary4, temporary3, this.m_blurMaterial, this.BlurPass);
				}
			}
			float num4 = this.m_currentTime / this.TotalDuration;
			float num5 = Mathf.Clamp(this.BlurIntensityCurve.Evaluate(num4), 0f, 1f);
			this.m_blurMaterial.SetFloat("_BlurIntensity", 1f - num5);
			this.m_blurMaterial.SetTexture("_ColorBuffer", source);
			if (this.BlurQualityValue > DizzyEffect.BlurQuality.Cheap)
			{
				Graphics.Blit(temporary3, temporary);
				Graphics.Blit(temporary, destination, this.m_blurMaterial, 8);
			}
			else
			{
				Graphics.Blit(temporary3, destination, this.m_blurMaterial, 8);
			}
			RenderTexture.ReleaseTemporary(temporary);
			RenderTexture.ReleaseTemporary(temporary2);
			RenderTexture.ReleaseTemporary(temporary3);
			RenderTexture.ReleaseTemporary(temporary4);
			return;
		}
		base.enabled = false;
	}

	// Token: 0x04001A52 RID: 6738
	public Shader BlurShader;

	// Token: 0x04001A53 RID: 6739
	public AnimationCurve BlurIntensityCurve = new AnimationCurve();

	// Token: 0x04001A54 RID: 6740
	public float TotalDuration = 1f;

	// Token: 0x04001A55 RID: 6741
	public float SepBlurSpread = 2.5f;

	// Token: 0x04001A56 RID: 6742
	public int BlurIterations = 2;

	// Token: 0x04001A57 RID: 6743
	public int BlurPass = 5;

	// Token: 0x04001A58 RID: 6744
	public DizzyEffect.BlurQuality BlurQualityValue;

	// Token: 0x04001A59 RID: 6745
	private Material m_blurMaterial;

	// Token: 0x04001A5A RID: 6746
	private bool m_bSupported;

	// Token: 0x04001A5B RID: 6747
	private float m_currentTime;

	// Token: 0x020005B1 RID: 1457
	public enum BlurQuality
	{
		// Token: 0x04001A5D RID: 6749
		Cheap,
		// Token: 0x04001A5E RID: 6750
		High
	}
}
