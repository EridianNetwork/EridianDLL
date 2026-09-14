using System;
using ns0;
using UnityEngine;

// Token: 0x020005C3 RID: 1475
public class LightRegister : MonoBehaviour
{
	// Token: 0x06002566 RID: 9574 RVA: 0x00019692 File Offset: 0x00017892
	private void Start()
	{
		if (MonoSingleton<GraphicsMgr>.Instance != null && MonoSingleton<GraphicsMgr>.Instance.method_25() != null)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_25().method_0(base.gameObject, this.InitEnalbe, this.Type);
		}
	}

	// Token: 0x06002567 RID: 9575 RVA: 0x000196CE File Offset: 0x000178CE
	private void OnDestroy()
	{
		if (MonoSingleton<GraphicsMgr>.Instance != null && MonoSingleton<GraphicsMgr>.Instance.method_25() != null)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_25().method_1(base.gameObject, this.Type);
		}
	}

	// Token: 0x04001AC8 RID: 6856
	public LightsMgr.LightObjectType Type = LightsMgr.LightObjectType.LT_Unknown;

	// Token: 0x04001AC9 RID: 6857
	public bool InitEnalbe = true;
}
