using System;
using UnityEngine;

// Token: 0x02000C57 RID: 3159
public class RVReadyPump : MonoBehaviour
{
	// Token: 0x060052F5 RID: 21237 RVA: 0x00155A5C File Offset: 0x00153C5C
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
