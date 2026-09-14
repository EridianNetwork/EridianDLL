using System;
using UnityEngine;

// Token: 0x02000C58 RID: 3160
public class WeaponStationPump__0 : MonoBehaviour
{
	// Token: 0x060052F7 RID: 21239 RVA: 0x00155A5C File Offset: 0x00153C5C
	private void Update()
	{
		bool flag = WeaponStationShim.TryForceInstanceReady();
		bool flag2 = WeaponStationShim.TryPatchCraftingStation();
		if (flag && flag2)
		{
			global::UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
