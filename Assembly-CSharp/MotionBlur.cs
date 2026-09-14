using System;
using UnityEngine;

// Token: 0x020005B6 RID: 1462
[AddComponentMenu("Image Effects/Blur/Motion Blur (Color Accumulation)")]
[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class MotionBlur : ImageEffectBase
{
	// Token: 0x06002528 RID: 9512 RVA: 0x0001916C File Offset: 0x0001736C
	protected override void Start()
	{
		if (!SystemInfo.supportsRenderTextures)
		{
			base.enabled = false;
			return;
		}
		base.Start();
	}

	// Token: 0x06002529 RID: 9513 RVA: 0x00019442 File Offset: 0x00017642
	protected override void OnDisable()
	{
		base.OnDisable();
		global::UnityEngine.Object.DestroyImmediate(this.accumTexture);
	}

	// Token: 0x0600252A RID: 9514 RVA: 0x000B2AFC File Offset: 0x000B0CFC
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (this.accumTexture == null || this.accumTexture.width != source.width || this.accumTexture.height != source.height)
		{
			global::UnityEngine.Object.DestroyImmediate(this.accumTexture);
			this.accumTexture = new RenderTexture(source.width, source.height, 0);
			this.accumTexture.hideFlags = HideFlags.HideAndDontSave;
			Graphics.Blit(source, this.accumTexture);
		}
		if (this.extraBlur)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
			this.accumTexture.MarkRestoreExpected();
			Graphics.Blit(this.accumTexture, temporary);
			Graphics.Blit(temporary, this.accumTexture);
			RenderTexture.ReleaseTemporary(temporary);
		}
		this.blurAmount = Mathf.Clamp(this.blurAmount, 0f, 0.92f);
		base.Material_0.SetTexture("_MainTex", this.accumTexture);
		base.Material_0.SetFloat("_AccumOrig", 1f - this.blurAmount);
		this.accumTexture.MarkRestoreExpected();
		Graphics.Blit(source, this.accumTexture, base.Material_0);
		Graphics.Blit(this.accumTexture, destination);
	}

	// Token: 0x04001A89 RID: 6793
	public float blurAmount = 0.8f;

	// Token: 0x04001A8A RID: 6794
	public bool extraBlur;

	// Token: 0x04001A8B RID: 6795
	private RenderTexture accumTexture;
}
