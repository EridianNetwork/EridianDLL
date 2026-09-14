using System;
using System.Xml.Serialization;
using UnityEngine;

namespace XsdSettings
{
	// Token: 0x020008CC RID: 2252
	public class ExtraAttrSlotSetup
	{
		// Token: 0x06003E46 RID: 15942 RVA: 0x00128CA0 File Offset: 0x00126EA0
		public int method_0(ItemRarity itemRarity_0)
		{
			int num = 0;
			for (int i = 0; i < this.m_extraAttrSlotList.Length; i++)
			{
				if (this.m_extraAttrSlotList[i].m_rarity == itemRarity_0)
				{
					num += this.m_extraAttrSlotList[i].m_probability;
				}
			}
			int num2 = global::UnityEngine.Random.Range(0, num);
			int num3 = 0;
			for (int j = 0; j < this.m_extraAttrSlotList.Length; j++)
			{
				if (this.m_extraAttrSlotList[j].m_rarity == itemRarity_0)
				{
					if (num2 < num3 + this.m_extraAttrSlotList[j].m_probability && num2 >= num3)
					{
						return this.m_extraAttrSlotList[j].m_slotNum;
					}
					num3 += this.m_extraAttrSlotList[j].m_probability;
				}
			}
			return 0;
		}

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x06003E47 RID: 15943 RVA: 0x0002A0F7 File Offset: 0x000282F7
		// (set) Token: 0x06003E48 RID: 15944 RVA: 0x0002A0FF File Offset: 0x000282FF
		[XmlArrayItem("m_extraAttrSlot", IsNullable = false)]
		public ExtraAttrSlot[] m_extraAttrSlotList { get; set; }

		// Token: 0x04002BCB RID: 11211
		private ExtraAttrSlot[] m_extraAttrSlotListField;
	}
}
