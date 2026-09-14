using System;
using UnityEngine;

// Token: 0x020005BC RID: 1468
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Second Wind Effect")]
[ExecuteInEditMode]
public class SecondWindEffect : MonoBehaviour
{
	// Token: 0x06002545 RID: 9541 RVA: 0x000B337C File Offset: 0x000B157C
	private void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			this.m_bSupported = false;
			base.enabled = false;
			return;
		}
		if (this.SecondWindShader == null)
		{
			this.m_bSupported = false;
			base.enabled = false;
			return;
		}
		this.m_secondWindMaterial = new Material(this.SecondWindShader);
		if (this.m_secondWindMaterial == null)
		{
			this.m_bSupported = false;
			base.enabled = false;
			return;
		}
		this.m_secondWindMaterial.hideFlags = HideFlags.HideAndDontSave;
		this.m_bSupported = true;
		this.m_currentTime = 0f;
		this.m_currentStage = SecondWindEffect.VFXStage.FirstStage;
		if (this.StageDuration.Length != 3)
		{
			this.StageDuration = new float[3];
			this.StageDuration[0] = 0.5f;
			this.StageDuration[1] = 0.5f;
			this.StageDuration[2] = 5f;
		}
	}

	// Token: 0x06002546 RID: 9542 RVA: 0x00019571 File Offset: 0x00017771
	private void Update()
	{
		this.method_0();
	}

	// Token: 0x06002547 RID: 9543 RVA: 0x000B3450 File Offset: 0x000B1650
	protected void method_0()
	{
		if (this.m_currentStage == SecondWindEffect.VFXStage.FirstStage)
		{
			this.m_currentTime += Time.deltaTime;
			if (this.StageDuration.Length > 0 && this.m_currentTime > this.StageDuration[0])
			{
				this.m_currentStage = SecondWindEffect.VFXStage.SecondStage;
				this.m_currentTime = 0f;
			}
		}
		else if (this.m_currentStage == SecondWindEffect.VFXStage.SecondStage)
		{
			this.m_currentTime += Time.deltaTime;
			if (this.StageDuration.Length > 1 && this.m_currentTime > this.StageDuration[1])
			{
				this.m_currentStage = SecondWindEffect.VFXStage.ThirdStage;
				this.m_currentTime = 0f;
			}
		}
		else if (this.m_currentStage == SecondWindEffect.VFXStage.ThirdStage)
		{
			this.m_currentTime += Time.deltaTime;
		}
	}

	// Token: 0x06002548 RID: 9544 RVA: 0x00019579 File Offset: 0x00017779
	private void method_1()
	{
		global::UnityEngine.Object.DestroyImmediate(this.m_secondWindMaterial);
		this.m_secondWindMaterial = null;
	}

	// Token: 0x06002549 RID: 9545 RVA: 0x0001958D File Offset: 0x0001778D
	private void OnDestroy()
	{
		this.method_1();
	}

	// Token: 0x0600254A RID: 9546 RVA: 0x00019595 File Offset: 0x00017795
	private void OnEnable()
	{
		this.m_currentTime = 0f;
		this.m_currentStage = SecondWindEffect.VFXStage.FirstStage;
	}

	// Token: 0x0600254B RID: 9547 RVA: 0x000B3510 File Offset: 0x000B1710
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (this.m_bSupported && this.SecondWindShader.isSupported)
		{
			if (this.m_currentStage == SecondWindEffect.VFXStage.FirstStage)
			{
				this.OnRenderImageOfFirstStage(source, destination);
			}
			else if (this.m_currentStage == SecondWindEffect.VFXStage.SecondStage)
			{
				this.OnRenderImageOfSecondStage(source, destination);
			}
			else if (this.m_currentStage == SecondWindEffect.VFXStage.ThirdStage)
			{
				this.OnRenderImageOfThirdStage(source, destination);
			}
			return;
		}
		base.enabled = false;
	}

	// Token: 0x0600254C RID: 9548 RVA: 0x000195A9 File Offset: 0x000177A9
	protected void OnRenderImageOfFirstStage(RenderTexture source, RenderTexture destination)
	{
		this.m_secondWindMaterial.SetFloat("_FlashScale", this.FlashScale);
		Graphics.Blit(source, destination, this.m_secondWindMaterial, 11);
	}

	// Token: 0x0600254D RID: 9549 RVA: 0x000B3570 File Offset: 0x000B1770
	protected void OnRenderImageOfSecondStage(RenderTexture source, RenderTexture destination)
	{
		float num = this.m_currentTime / ((this.StageDuration.Length <= 1) ? 1f : this.StageDuration[1]);
		float num2 = (this.FlashScale - 1f) * Mathf.Clamp(1f - num, 0f, 1f) + 1f;
		this.m_secondWindMaterial.SetFloat("_FlashScale", num2);
		Graphics.Blit(source, destination, this.m_secondWindMaterial, 11);
	}

	// Token: 0x0600254E RID: 9550 RVA: 0x000B35EC File Offset: 0x000B17EC
	protected void OnRenderImageOfThirdStage(RenderTexture source, RenderTexture destination)
	{
		RenderTexture temporary = RenderTexture.GetTemporary(source.width / 2, source.height / 2, 0);
		RenderTexture temporary2 = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
		RenderTexture temporary3 = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
		RenderTexture temporary4 = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
		float num = 1f * (float)source.width / (1f * (float)source.height);
		float num2 = 0.001953125f;
		if (this.BlurQualityValue > SecondWindEffect.BlurQuality.Cheap)
		{
			Graphics.Blit(source, temporary, this.m_secondWindMaterial, 5);
			Graphics.Blit(temporary, temporary3, this.m_secondWindMaterial, 5);
			Graphics.Blit(temporary3, temporary2, this.m_secondWindMaterial, 6);
		}
		else
		{
			Graphics.Blit(source, temporary);
			Graphics.Blit(temporary, temporary2, this.m_secondWindMaterial, 6);
		}
		this.BlurIterations = Mathf.Clamp(this.BlurIterations, 1, 10);
		this.BlurPass = Mathf.Clamp(this.BlurPass, 0, 4);
		for (int i = 0; i < this.BlurIterations; i++)
		{
			float num3 = (1f + (float)i * 0.25f) * this.SepBlurSpread;
			this.m_secondWindMaterial.SetVector("_Offsets", new Vector4(0f, num3 * num2, 0f, 0f));
			Graphics.Blit(temporary3, temporary4, this.m_secondWindMaterial, this.BlurPass);
			if (this.BlurQualityValue > SecondWindEffect.BlurQuality.Cheap)
			{
				this.m_secondWindMaterial.SetVector("_Offsets", new Vector4(num3 / num * num2, 0f, 0f, 0f));
				Graphics.Blit(temporary4, temporary3, this.m_secondWindMaterial, this.BlurPass);
				if (i == 0)
				{
					Graphics.Blit(temporary3, temporary2);
				}
				else
				{
					Graphics.Blit(temporary3, temporary2, this.m_secondWindMaterial, 7);
				}
			}
			else
			{
				this.m_secondWindMaterial.SetVector("_Offsets", new Vector4(num3 / num * num2, 0f, 0f, 0f));
				Graphics.Blit(temporary4, temporary3, this.m_secondWindMaterial, this.BlurPass);
			}
		}
		float num4 = Mathf.Clamp(this.BlurIntensityCurve.Evaluate(this.CurrentVignettePercentage), 0f, 1f);
		float num5 = Mathf.Clamp(this.SaturateCurve.Evaluate(this.CurrentVignettePercentage), 0f, 1f);
		float num6 = Mathf.Clamp(this.FadeOutCurve.Evaluate(this.CurrentVignettePercentage), 0f, 1f);
		this.m_secondWindMaterial.SetFloat("_BlurIntensity", num4);
		this.m_secondWindMaterial.SetFloat("_Saturation", num5);
		this.m_secondWindMaterial.SetFloat("_FadeOut", num6);
		this.m_secondWindMaterial.SetTexture("_ColorBuffer", source);
		float num7 = this.StartVignetteScale + (this.EndVignetteScale - this.StartVignetteScale) * this.CurrentVignettePercentage;
		this.m_secondWindMaterial.SetFloat("_VignetteScale", num7);
		Graphics.Blit(temporary3, temporary);
		Graphics.Blit(temporary, destination, this.m_secondWindMaterial, 10);
		RenderTexture.ReleaseTemporary(temporary);
		RenderTexture.ReleaseTemporary(temporary2);
		RenderTexture.ReleaseTemporary(temporary3);
		RenderTexture.ReleaseTemporary(temporary4);
	}

	// Token: 0x04001AA5 RID: 6821
	public Shader SecondWindShader;

	// Token: 0x04001AA6 RID: 6822
	public AnimationCurve BlurIntensityCurve = new AnimationCurve();

	// Token: 0x04001AA7 RID: 6823
	public AnimationCurve SaturateCurve = new AnimationCurve();

	// Token: 0x04001AA8 RID: 6824
	public AnimationCurve FadeOutCurve = new AnimationCurve();

	// Token: 0x04001AA9 RID: 6825
	public float[] StageDuration;

	// Token: 0x04001AAA RID: 6826
	public float FlashScale = 1f;

	// Token: 0x04001AAB RID: 6827
	public float SepBlurSpread = 2.5f;

	// Token: 0x04001AAC RID: 6828
	public int BlurIterations = 2;

	// Token: 0x04001AAD RID: 6829
	public int BlurPass = 5;

	// Token: 0x04001AAE RID: 6830
	public SecondWindEffect.BlurQuality BlurQualityValue;

	// Token: 0x04001AAF RID: 6831
	public float StartVignetteScale = 1f;

	// Token: 0x04001AB0 RID: 6832
	public float EndVignetteScale = 6f;

	// Token: 0x04001AB1 RID: 6833
	public float CurrentVignettePercentage;

	// Token: 0x04001AB2 RID: 6834
	private Material m_secondWindMaterial;

	// Token: 0x04001AB3 RID: 6835
	private bool m_bSupported;

	// Token: 0x04001AB4 RID: 6836
	private float m_currentTime;

	// Token: 0x04001AB5 RID: 6837
	private SecondWindEffect.VFXStage m_currentStage;

	// Token: 0x020005BD RID: 1469
	public enum BlurQuality
	{
		// Token: 0x04001AB7 RID: 6839
		Cheap,
		// Token: 0x04001AB8 RID: 6840
		High
	}

	// Token: 0x020005BE RID: 1470
	private enum VFXStage
	{
		// Token: 0x04001ABA RID: 6842
		FirstStage,
		// Token: 0x04001ABB RID: 6843
		SecondStage,
		// Token: 0x04001ABC RID: 6844
		ThirdStage
	}
}
