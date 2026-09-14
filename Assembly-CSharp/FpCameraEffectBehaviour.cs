using System;
using ns0;
using UnityEngine;

// Token: 0x020005A4 RID: 1444
public class FpCameraEffectBehaviour : MonoBehaviour
{
	// Token: 0x060024AB RID: 9387 RVA: 0x00018FB5 File Offset: 0x000171B5
	private void Update()
	{
		MonoSingleton<GraphicsMgr>.Instance.method_24().Update();
	}
}
