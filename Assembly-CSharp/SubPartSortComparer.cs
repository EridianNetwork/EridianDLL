using System;
using System.Collections.Generic;
using XsdSettings;

// Token: 0x020008F7 RID: 2295
public class SubPartSortComparer : IComparer<SubPartWpn>
{
	// Token: 0x06003F62 RID: 16226 RVA: 0x0012BCAC File Offset: 0x00129EAC
	public int Compare(SubPartWpn part1, SubPartWpn part2)
	{
		if (part1 == null && part2 == null)
		{
			return 0;
		}
		if (part1 != null && part2 == null)
		{
			return 1;
		}
		if (part1 == null && part2 != null)
		{
			return -1;
		}
		if (part1.m_weaponType > part2.m_weaponType)
		{
			return 1;
		}
		if (part1.m_weaponType < part2.m_weaponType)
		{
			return -1;
		}
		if (part1.m_partType > part2.m_partType)
		{
			return 1;
		}
		if (part1.m_partType < part2.m_partType)
		{
			return -1;
		}
		if (part1.m_Index > part2.m_Index)
		{
			return 1;
		}
		if (part1.m_Index < part2.m_Index)
		{
			return -1;
		}
		if (part1.m_Index == part2.m_Index)
		{
			return 0;
		}
		return 0;
	}
}
