using System;
using Core;
using UnityEngine;

// Token: 0x02000C59 RID: 3161
public class WeaponStationPump__1 : MonoBehaviour
{
	// Token: 0x060052F9 RID: 21241 RVA: 0x00155A84 File Offset: 0x00153C84
	private void Update()
	{
		if (!this.m_loggedStart)
		{
			this.m_loggedStart = true;
			DebugUtils.LogWarning(LogCategory.Framework, "[SHIM] WeaponStationPump: ticking");
		}
		bool flag = WeaponStationShim.TryForceInstanceReady();
		bool flag2 = WeaponStationShim.TryPatchCraftingStation();
		if (flag && flag2)
		{
			DebugUtils.LogWarning(LogCategory.Framework, "[SHIM] WeaponStationPump: done, destroying self");
			global::UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04003D2F RID: 15663
	private bool m_loggedStart;
}
