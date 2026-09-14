using System;
using System.Collections.Generic;
using UnityEngine;
using XsdSettings;

// Token: 0x020008E6 RID: 2278
[Serializable]
public class SubPartsInRarity
{
	// Token: 0x06003EC6 RID: 16070 RVA: 0x0002A489 File Offset: 0x00028689
	public SubPartsInRarity()
	{
	}

	// Token: 0x06003EC7 RID: 16071 RVA: 0x0012B150 File Offset: 0x00129350
	public SubPartsInRarity(SubPartsInRarity subPartsInRarity_0)
	{
		this.m_subParts.Clear();
		for (int i = 0; i < subPartsInRarity_0.m_subParts.Count; i++)
		{
			this.m_subParts.Add(subPartsInRarity_0.m_subParts[i]);
		}
	}

	// Token: 0x06003EC8 RID: 16072 RVA: 0x0002A49C File Offset: 0x0002869C
	public SubPartsInRarity(bool bool_0, WeaponSubPart weaponSubPart_0)
	{
		this.m_weaponSubPart = weaponSubPart_0;
		if (bool_0)
		{
			this.m_subParts.Clear();
		}
	}

	// Token: 0x04002C2A RID: 11306
	[SerializeField]
	public WeaponSubPart m_weaponSubPart;

	// Token: 0x04002C2B RID: 11307
	[SerializeField]
	public List<SubpartChoice> m_subParts = new List<SubpartChoice>();
}
