using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

namespace XsdSettings
{
	// Token: 0x020008CE RID: 2254
	public class ExtraAttrEffectSetup
	{
		// Token: 0x06003E4F RID: 15951 RVA: 0x00128F20 File Offset: 0x00127120
		private int method_0(ItemRarity itemRarity_0, EffectType effectType_0, int int_0)
		{
			int num = 0;
			for (int i = 0; i < this.m_extraAttrEffectList.Length; i++)
			{
				if (this.m_extraAttrEffectList[i].m_rarity == itemRarity_0 && this.m_extraAttrEffectList[i].m_effect == effectType_0 && int_0 >= this.m_extraAttrEffectList[i].m_minLevel && int_0 <= this.m_extraAttrEffectList[i].m_maxLevel)
				{
					num += this.m_extraAttrEffectList[i].m_probability;
				}
			}
			int num2 = global::UnityEngine.Random.Range(0, num);
			int num3 = 0;
			for (int j = 0; j < this.m_extraAttrEffectList.Length; j++)
			{
				if (this.m_extraAttrEffectList[j].m_rarity == itemRarity_0 && this.m_extraAttrEffectList[j].m_effect == effectType_0 && int_0 >= this.m_extraAttrEffectList[j].m_minLevel && int_0 <= this.m_extraAttrEffectList[j].m_maxLevel)
				{
					if (num2 < num3 + this.m_extraAttrEffectList[j].m_probability && num2 >= num3)
					{
						return (int)this.m_extraAttrEffectList[j].m_index;
					}
					num3 += this.m_extraAttrEffectList[j].m_probability;
				}
			}
			return int.MaxValue;
		}

		// Token: 0x06003E50 RID: 15952 RVA: 0x00129034 File Offset: 0x00127234
		public int[] method_1(ItemRarity itemRarity_0, int[] int_0, int int_1)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < int_0.Length; i++)
			{
				list.Add(this.method_0(itemRarity_0, (EffectType)int_0[i], int_1));
			}
			int[] array = new int[ItemDNA.m_extraEffectNums];
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = 0;
			}
			for (int k = 0; k < list.Count; k++)
			{
				array[k] = list[k];
			}
			return array;
		}

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x06003E51 RID: 15953 RVA: 0x0002A119 File Offset: 0x00028319
		// (set) Token: 0x06003E52 RID: 15954 RVA: 0x0002A121 File Offset: 0x00028321
		[XmlArrayItem("m_extraAttrEffect", IsNullable = false)]
		public ExtraAttrEffect[] m_extraAttrEffectList { get; set; }

		// Token: 0x04002BCF RID: 11215
		private ExtraAttrEffect[] m_extraAttrEffectListField;
	}
}
