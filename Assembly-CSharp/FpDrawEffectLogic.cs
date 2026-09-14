using System;
using ns0;
using UnityEngine;

// Token: 0x020005A6 RID: 1446
public class FpDrawEffectLogic : MonoBehaviour
{
	// Token: 0x060024BC RID: 9404 RVA: 0x00019018 File Offset: 0x00017218
	private void Update()
	{
		MonoSingleton<GraphicsMgr>.Instance.method_20().method_12();
	}

	// Token: 0x060024BD RID: 9405 RVA: 0x00019029 File Offset: 0x00017229
	private void OnRenderObject()
	{
		MonoSingleton<GraphicsMgr>.Instance.method_20().method_13();
	}
}
