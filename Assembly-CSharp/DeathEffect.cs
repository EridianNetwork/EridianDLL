using System;
using ns0;
using UnityEngine;

// Token: 0x020005AF RID: 1455
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/DeathEffect")]
public class DeathEffect : ImageEffectBase
{
	// Token: 0x06002505 RID: 9477 RVA: 0x0001916C File Offset: 0x0001736C
	protected override void Start()
	{
		if (!SystemInfo.supportsRenderTextures)
		{
			base.enabled = false;
			return;
		}
		base.Start();
	}

	// Token: 0x06002506 RID: 9478 RVA: 0x000191CA File Offset: 0x000173CA
	protected override void OnDisable()
	{
		base.OnDisable();
		global::UnityEngine.Object.DestroyImmediate(this.accumTexture);
	}

	// Token: 0x06002507 RID: 9479 RVA: 0x000B1A34 File Offset: 0x000AFC34
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (this.statIndex == 0)
		{
			base.Material_0.SetFloat("_Saturation", this.saturation);
			Graphics.Blit(source, destination, base.Material_0, 0);
		}
		else if (this.statIndex == 1)
		{
			if (!MonoSingleton<GraphicsMgr>.Instance.method_0())
			{
				if (this.accumTexture == null || this.accumTexture.width != source.width || this.accumTexture.height != source.height)
				{
					global::UnityEngine.Object.DestroyImmediate(this.accumTexture);
					this.accumTexture = new RenderTexture(source.width, source.height, 0);
					this.accumTexture.name = "DeathEffect_accumTexture";
					this.accumTexture.hideFlags = HideFlags.HideAndDontSave;
					base.Material_0.SetFloat("_LumOffset", 1f);
					Graphics.Blit(this.accumTexture, base.Material_0, 3);
				}
				if (this.extraBlur)
				{
					RenderTexture temporary = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
					temporary.name = "DeathEffect_blurbuffer";
					Graphics.Blit(this.accumTexture, temporary);
					Graphics.Blit(temporary, this.accumTexture);
					RenderTexture.ReleaseTemporary(temporary);
				}
				base.Material_0.SetFloat("_AccumOrig", 1f - this.blurAmount);
				base.Material_0.SetFloat("_LumScenePara", this.lumScenePara);
				base.Material_0.SetFloat("_LumFpsPara", this.lumFpsPara);
				base.Material_0.SetFloat("_LumOffset", this.lumOffset);
				Graphics.Blit(source, this.accumTexture, base.Material_0, 1);
				Graphics.Blit(this.accumTexture, destination);
			}
			else
			{
				base.Material_0.SetFloat("_AccumOrig", 1f - this.blurAmount);
				base.Material_0.SetFloat("_LumScenePara", this.lumScenePara);
				base.Material_0.SetFloat("_LumFpsPara", this.lumFpsPara);
				base.Material_0.SetFloat("_LumOffset", this.lumOffset);
				Graphics.Blit(source, destination, base.Material_0, 1);
			}
		}
	}

	// Token: 0x04001A49 RID: 6729
	public float saturation = 1f;

	// Token: 0x04001A4A RID: 6730
	public int statIndex;

	// Token: 0x04001A4B RID: 6731
	public float lumOffset;

	// Token: 0x04001A4C RID: 6732
	public float whiteRadius;

	// Token: 0x04001A4D RID: 6733
	public float blurAmount = 0.8f;

	// Token: 0x04001A4E RID: 6734
	public bool extraBlur;

	// Token: 0x04001A4F RID: 6735
	public float lumScenePara = 3f;

	// Token: 0x04001A50 RID: 6736
	public float lumFpsPara = 1f;

	// Token: 0x04001A51 RID: 6737
	private RenderTexture accumTexture;
}
