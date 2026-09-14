using System;
using UnityEngine;

// Token: 0x020005C0 RID: 1472
[AddComponentMenu("Image Effects/TransferEffect")]
[ExecuteInEditMode]
public class TransferImageEffect : ImageEffectBase
{
	// Token: 0x06002557 RID: 9559 RVA: 0x000195FF File Offset: 0x000177FF
	public void method_0(float float_0)
	{
		if (base.Material_0)
		{
			base.Material_0.SetFloat("_BlendPara", float_0);
		}
	}

	// Token: 0x06002558 RID: 9560 RVA: 0x0001916C File Offset: 0x0001736C
	protected override void Start()
	{
		if (!SystemInfo.supportsRenderTextures)
		{
			base.enabled = false;
			return;
		}
		base.Start();
	}

	// Token: 0x06002559 RID: 9561 RVA: 0x0001949A File Offset: 0x0001769A
	protected override void OnDisable()
	{
		base.OnDisable();
	}

	// Token: 0x0600255A RID: 9562 RVA: 0x0001961F File Offset: 0x0001781F
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, base.Material_0, 0);
	}

	// Token: 0x04001ABF RID: 6847
	public int statIndex;
}
