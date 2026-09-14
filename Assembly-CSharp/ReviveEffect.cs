using System;
using UnityEngine;

// Token: 0x020005B8 RID: 1464
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/DeathEffect")]
public class ReviveEffect : ImageEffectBase
{
	// Token: 0x06002531 RID: 9521 RVA: 0x0001916C File Offset: 0x0001736C
	protected override void Start()
	{
		if (!SystemInfo.supportsRenderTextures)
		{
			base.enabled = false;
			return;
		}
		base.Start();
	}

	// Token: 0x06002532 RID: 9522 RVA: 0x0001949A File Offset: 0x0001769A
	protected override void OnDisable()
	{
		base.OnDisable();
	}

	// Token: 0x06002533 RID: 9523 RVA: 0x000194A2 File Offset: 0x000176A2
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.Material_0.SetFloat("_LerpVal", this.mLerpVal);
		Graphics.Blit(source, destination, base.Material_0, 0);
	}

	// Token: 0x04001A92 RID: 6802
	public float mLerpVal;
}
