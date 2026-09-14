using System;
using System.Collections.Generic;
using Core;

// Token: 0x02000900 RID: 2304
public class AttributeScaleSortComparer : IComparer<AttributeScale>
{
	// Token: 0x06003F7E RID: 16254 RVA: 0x0012C2AC File Offset: 0x0012A4AC
	public int Compare(AttributeScale attr1, AttributeScale attr2)
	{
		if (attr1.m_scale > attr2.m_scale)
		{
			return 1;
		}
		if (attr1.m_scale < attr2.m_scale)
		{
			return -1;
		}
		int num = WeaponStore.weaponStore.AttributePriority.Length;
		int num2 = WeaponStore.weaponStore.AttributePriority.Length;
		for (int i = 0; i < WeaponStore.weaponStore.AttributePriority.Length; i++)
		{
			if (attr1.m_attribute == WeaponStore.weaponStore.AttributePriority[i])
			{
				num = i;
			}
			else if (attr2.m_attribute == WeaponStore.weaponStore.AttributePriority[i])
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
		DebugUtils.LogError(LogCategory.Gamelogic, "AttributeScale have same m_attribute and scale, this is not right");
		return 0;
	}
}
