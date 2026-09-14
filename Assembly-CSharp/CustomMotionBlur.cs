using System;
using UnityEngine;

// Token: 0x020005AE RID: 1454
public class CustomMotionBlur : ImageEffectBase
{
	// Token: 0x06002501 RID: 9473 RVA: 0x0001916C File Offset: 0x0001736C
	protected override void Start()
	{
		if (!SystemInfo.supportsRenderTextures)
		{
			base.enabled = false;
			return;
		}
		base.Start();
	}

	// Token: 0x06002502 RID: 9474 RVA: 0x00019183 File Offset: 0x00017383
	protected override void OnDisable()
	{
		base.OnDisable();
		global::UnityEngine.Object.DestroyImmediate(this.accumTexture);
	}

	// Token: 0x06002503 RID: 9475 RVA: 0x000B18C4 File Offset: 0x000AFAC4
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (this.accumTexture == null || this.accumTexture.width != source.width || this.accumTexture.height != source.height)
		{
			global::UnityEngine.Object.DestroyImmediate(this.accumTexture);
			this.accumTexture = new RenderTexture(source.width, source.height, 0);
			this.accumTexture.name = "CustomMotionBlur_accumTexture";
			this.accumTexture.hideFlags = HideFlags.HideAndDontSave;
			Graphics.Blit(source, this.accumTexture);
		}
		if (this.extraBlur)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
			temporary.name = "CustomMotionBlur_blurbuffer";
			this.accumTexture.MarkRestoreExpected();
			Graphics.Blit(this.accumTexture, temporary);
			Graphics.Blit(temporary, this.accumTexture);
			RenderTexture.ReleaseTemporary(temporary);
		}
		this.blurAmount = Mathf.Clamp(this.blurAmount, 0f, 0.92f);
		base.Material_0.SetTexture("_MainTex", this.accumTexture);
		base.Material_0.SetFloat("_AccumOrig", 1f - this.blurAmount);
		base.Material_0.SetTexture("_MaskTex", this.mBlurMaskTex);
		this.accumTexture.MarkRestoreExpected();
		Graphics.Blit(source, this.accumTexture, base.Material_0, 0);
		Graphics.Blit(this.accumTexture, destination);
	}

	// Token: 0x04001A44 RID: 6724
	public float blurAmount = 0.8f;

	// Token: 0x04001A45 RID: 6725
	public bool extraBlur;

	// Token: 0x04001A46 RID: 6726
	public float mBlurRadius = 1f;

	// Token: 0x04001A47 RID: 6727
	public Texture mBlurMaskTex;

	// Token: 0x04001A48 RID: 6728
	private RenderTexture accumTexture;
}
