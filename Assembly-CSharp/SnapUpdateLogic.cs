using System;
using ns0;
using UnityEngine;

// Token: 0x020005E0 RID: 1504
public class SnapUpdateLogic : MonoBehaviour
{
	// Token: 0x06002615 RID: 9749 RVA: 0x00019CD6 File Offset: 0x00017ED6
	private void FixedUpdate()
	{
		MonoSingleton<GraphicsMgr>.Instance.method_19().method_4();
	}

	// Token: 0x06002616 RID: 9750 RVA: 0x00019CE7 File Offset: 0x00017EE7
	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		Graphics.Blit(src, dest);
	}
}
