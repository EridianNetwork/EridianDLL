using System;
using System.Collections.Generic;
using Core;
using XsdSettings;

// Token: 0x020008FF RID: 2303
public class RedlineSubpartSortComparer : IComparer<WeaponSubPart>
{
	// Token: 0x06003F7C RID: 16252 RVA: 0x0012C230 File Offset: 0x0012A430
	public int Compare(WeaponSubPart part1, WeaponSubPart part2)
	{
		int num = WeaponStore.weaponStore.SubpartPriority.Length;
		int num2 = WeaponStore.weaponStore.SubpartPriority.Length;
		for (int i = 0; i < WeaponStore.weaponStore.SubpartPriority.Length; i++)
		{
			if (part1 == WeaponStore.weaponStore.SubpartPriority[i])
			{
				num = i;
			}
			else if (part2 == WeaponStore.weaponStore.SubpartPriority[i])
			{
				num2 = i;
			}
		}
		if (num < num2)
		{
			return 1;
		}
		if (num > num2)
		{
			return -1;
		}
		DebugUtils.LogError(LogCategory.Gamelogic, "Same weaponSubPart type in list? this is not right");
		return 0;
	}
}
