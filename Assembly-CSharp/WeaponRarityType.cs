using System;
using System.Collections.Generic;
using UnityEngine;
using XsdSettings;

// Token: 0x020008E2 RID: 2274
[Serializable]
public class WeaponRarityType
{
	// Token: 0x06003EBE RID: 16062 RVA: 0x0002A44B File Offset: 0x0002864B
	public WeaponRarityType()
	{
	}

	// Token: 0x06003EBF RID: 16063 RVA: 0x0012B028 File Offset: 0x00129228
	public WeaponRarityType(WeaponRarityType weaponRarityType_0)
	{
		this.m_subPartTypes.Clear();
		for (int i = 0; i < weaponRarityType_0.m_subPartTypes.Count; i++)
		{
			this.m_subPartTypes.Add(new SubPartsInRarity(weaponRarityType_0.m_subPartTypes[i]));
		}
	}

	// Token: 0x06003EC0 RID: 16064 RVA: 0x0012B084 File Offset: 0x00129284
	public WeaponRarityType(bool bool_0, WeaponRarity weaponRarity_0)
	{
		this.m_weaponRarity = weaponRarity_0;
		if (bool_0)
		{
			this.m_subPartTypes.Clear();
			for (int i = 0; i < 9; i++)
			{
				this.m_subPartTypes.Add(new SubPartsInRarity(true, (WeaponSubPart)i));
			}
		}
	}

	// Token: 0x06003EC1 RID: 16065 RVA: 0x0012B0D8 File Offset: 0x001292D8
	public void method_0()
	{
		List<SubPartsInRarity> list = new List<SubPartsInRarity>();
		for (int i = 0; i < 9; i++)
		{
			WeaponSubPart weaponSubPart = (WeaponSubPart)i;
			int num = m_subPartTypes.FindIndex((SubPartsInRarity subPartsInRarity_0) => subPartsInRarity_0.m_weaponSubPart == weaponSubPart);
			if (num >= 0)
			{
				list.Add(m_subPartTypes[num]);
			}
			else
			{
				list.Add(new SubPartsInRarity(bool_0: true, weaponSubPart));
			}
		}
		m_subPartTypes = list;
	}
	// Token: 0x04002C20 RID: 11296
	[SerializeField]
	public WeaponRarity m_weaponRarity;

	// Token: 0x04002C21 RID: 11297
	[SerializeField]
	public List<SubPartsInRarity> m_subPartTypes = new List<SubPartsInRarity>();
}
