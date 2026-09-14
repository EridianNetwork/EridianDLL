using System;
using ns0;
using UnityEngine;

// Token: 0x020005E2 RID: 1506
public class TexPostEffectLogic : MonoBehaviour
{
	// Token: 0x0600261A RID: 9754 RVA: 0x00019D29 File Offset: 0x00017F29
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination);
		MonoSingleton<GraphicsMgr>.Instance.method_23().method_5();
	}
}
