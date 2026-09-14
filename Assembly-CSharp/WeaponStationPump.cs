using System;
using Core;
using UnityEngine;

// Token: 0x02000C56 RID: 3158
public class WeaponStationPump : MonoBehaviour
{
	// Token: 0x060052F3 RID: 21235 RVA: 0x00155A10 File Offset: 0x00153C10
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

	// Token: 0x04003D2E RID: 15662
	private bool m_loggedStart;
}
