using System;
using System.Collections.Generic;
using UnityEngine;
using XsdSettings;

// Token: 0x020008E0 RID: 2272
[Serializable]
public class WeaponRarityAttr
{
	// Token: 0x06003EB8 RID: 16056 RVA: 0x0002A428 File Offset: 0x00028628
	public WeaponRarityAttr()
	{
	}

	// Token: 0x06003EB9 RID: 16057 RVA: 0x0012AECC File Offset: 0x001290CC
	public WeaponRarityAttr(WeaponRarityAttr weaponRarityAttr_0)
	{
		this.m_weaponType = weaponRarityAttr_0.m_weaponType;
		this.m_weaponRarityType.Clear();
		for (int i = 0; i < weaponRarityAttr_0.m_weaponRarityType.Count; i++)
		{
			this.m_weaponRarityType.Add(new WeaponRarityType(weaponRarityAttr_0.m_weaponRarityType[i]));
		}
	}

	// Token: 0x06003EBA RID: 16058 RVA: 0x0012AF34 File Offset: 0x00129134
	public WeaponRarityAttr(bool bool_0, WeaponType weaponType_0)
	{
		this.m_weaponType = weaponType_0;
		if (bool_0)
		{
			this.m_weaponRarityType.Clear();
			for (int i = 0; i < 6; i++)
			{
				this.m_weaponRarityType.Add(new WeaponRarityType(true, (WeaponRarity)i));
			}
		}
	}

	// Token: 0x06003EBB RID: 16059 RVA: 0x0012AF88 File Offset: 0x00129188
	public void method_0()
	{
		List<WeaponRarityType> list = new List<WeaponRarityType>();
		for (int i = 0; i < 6; i++)
		{
			WeaponRarity weaponRarity = (WeaponRarity)i;
			int num = m_weaponRarityType.FindIndex((WeaponRarityType weaponRarityType_0) => weaponRarityType_0.m_weaponRarity == weaponRarity);
			if (num >= 0)
			{
				list.Add(m_weaponRarityType[num]);
			}
			else
			{
				list.Add(new WeaponRarityType(bool_0: true, weaponRarity));
			}
		}
		m_weaponRarityType = list;
		for (int j = 0; j < m_weaponRarityType.Count; j++)
		{
			m_weaponRarityType[j].method_0();
		}
	}
	// Token: 0x04002C1D RID: 11293
	[SerializeField]
	public WeaponType m_weaponType;

	// Token: 0x04002C1E RID: 11294
	[SerializeField]
	public List<WeaponRarityType> m_weaponRarityType = new List<WeaponRarityType>();
}
