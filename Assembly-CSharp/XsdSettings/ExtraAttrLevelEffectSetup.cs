using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

namespace XsdSettings
{
	// Token: 0x020008CD RID: 2253
	public class ExtraAttrLevelEffectSetup
	{
		// Token: 0x06003E4A RID: 15946 RVA: 0x00128D4C File Offset: 0x00126F4C
	public int[] method_0(ItemRarity itemRarity_0, int int_0, int int_1, List<EffectType> list_0 = null)
	{
		List<ExtraAttrLevelEffect> list = new List<ExtraAttrLevelEffect>();
		for (int i = 0; i < m_extraAttrLevelEffectList.Length; i++)
		{
			if (m_extraAttrLevelEffectList[i].m_rarity != itemRarity_0 || int_0 < m_extraAttrLevelEffectList[i].m_minLevel || int_0 > m_extraAttrLevelEffectList[i].m_maxLevel)
			{
				continue;
			}
			bool flag = false;
			if (list_0 != null)
			{
				for (int j = 0; j < list_0.Count; j++)
				{
					if (list_0[j] == m_extraAttrLevelEffectList[i].m_effectType)
					{
						flag = true;
					}
				}
			}
			if (!flag)
			{
				list.Add(m_extraAttrLevelEffectList[i]);
			}
		}
		List<int> list2 = new List<int>();
		while (int_1 > 0)
		{
			int num = 0;
			for (int k = 0; k < list.Count; k++)
			{
				num += list[k].m_probability;
			}
			int num2 = UnityEngine.Random.Range(0, num);
			int num3 = 0;
			for (int l = 0; l < list.Count; l++)
			{
				if (num2 >= num3 + list[l].m_probability || num2 < num3)
				{
					num3 += list[l].m_probability;
					continue;
				}
				list2.Add((int)list[l].m_effectType);
				list.RemoveAt(l);
				break;
			}
			int_1--;
		}
		int[] array = new int[ItemDNA.m_extraEffectNums];
		for (int m = 0; m < array.Length; m++)
		{
			array[m] = 0;
		}
		for (int n = 0; n < list2.Count; n++)
		{
			array[n] = list2[n];
		}
		return array;
	}
		// Token: 0x06003E4B RID: 15947 RVA: 0x00128EE4 File Offset: 0x001270E4
		public List<EffectType> method_1(ulong ulong_0)
		{
			List<EffectType> list = new List<EffectType>();
			for (int i = 0; i < 8; i++)
			{
				list.Add((EffectType)(ulong_0 & 255UL));
				ulong_0 >>= 8;
			}
			return list;
		}

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x06003E4C RID: 15948 RVA: 0x0002A108 File Offset: 0x00028308
		// (set) Token: 0x06003E4D RID: 15949 RVA: 0x0002A110 File Offset: 0x00028310
		[XmlArrayItem("m_extraAttrLevelEffect", IsNullable = false)]
		public ExtraAttrLevelEffect[] m_extraAttrLevelEffectList { get; set; }

		// Token: 0x04002BCD RID: 11213
		private ExtraAttrLevelEffect[] m_extraAttrLevelEffectListField;
	}
}
