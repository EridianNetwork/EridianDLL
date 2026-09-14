using System;
using ns0;
using UnityEngine;

// Token: 0x020005E3 RID: 1507
public class TexPostEffectLogicStart : MonoBehaviour
{
	// Token: 0x0600261C RID: 9756 RVA: 0x000B7F78 File Offset: 0x000B6178
	[ImageEffectOpaque]
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Texture2D texture2D = MonoSingleton<GraphicsMgr>.Instance.method_23().method_0();
		Graphics.Blit(texture2D, destination);
	}
}
