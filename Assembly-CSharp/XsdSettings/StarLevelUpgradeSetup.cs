using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020008EC RID: 2284
	public class StarLevelUpgradeSetup
	{
		// Token: 0x06003EDB RID: 16091 RVA: 0x0012B630 File Offset: 0x00129830
		public int method_0(WeaponType weaponType_0, int int_0, int int_1, WeaponRarity weaponRarity_0)
		{
			int num = 0;
			for (int i = 0; i < this.m_rarityDefaultValueList.Length; i++)
			{
				if (this.m_rarityDefaultValueList[i].m_weaponRarity == weaponRarity_0)
				{
					num = this.m_rarityDefaultValueList[i].m_adjustValue;
				}
			}
			for (int j = 0; j < this.m_starLevelUpgrade.Length; j++)
			{
				if (this.m_starLevelUpgrade[j].m_weaponType == weaponType_0)
				{
					for (int k = 0; k < this.m_starLevelUpgrade[j].m_starLevelConfigList.Length; k++)
					{
						if (this.m_starLevelUpgrade[j].m_starLevelConfigList[k].m_starLevel == int_0)
						{
							return this.m_starLevelUpgrade[j].m_starLevelConfigList[k].m_basicStarExp + int_1 * (int_0 + 1) * num;
						}
					}
				}
			}
			return 0;
		}

		// Token: 0x06003EDC RID: 16092 RVA: 0x0012B6E8 File Offset: 0x001298E8
		public ItemConsume method_1(WeaponType weaponType_0, int int_0)
		{
			for (int i = 0; i < this.m_starLevelUpgrade.Length; i++)
			{
				if (this.m_starLevelUpgrade[i].m_weaponType == weaponType_0)
				{
					for (int j = 0; j < this.m_starLevelUpgrade[i].m_starLevelConfigList.Length; j++)
					{
						if (this.m_starLevelUpgrade[i].m_starLevelConfigList[j].m_starLevel == int_0)
						{
							return this.m_starLevelUpgrade[i].m_starLevelConfigList[j].m_itemConsume;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x06003EDD RID: 16093 RVA: 0x0002A569 File Offset: 0x00028769
		// (set) Token: 0x06003EDE RID: 16094 RVA: 0x0002A571 File Offset: 0x00028771
		[XmlArrayItem("m_rarityDefault", IsNullable = false)]
		public RarityDefaultValue[] m_rarityDefaultValueList { get; set; }

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x06003EDF RID: 16095 RVA: 0x0002A57A File Offset: 0x0002877A
		// (set) Token: 0x06003EE0 RID: 16096 RVA: 0x0002A582 File Offset: 0x00028782
		[XmlArrayItem("m_starLevelUpgrade", IsNullable = false)]
		public StarLevelUpgrade[] m_starLevelUpgrade { get; set; }

		// Token: 0x04002C3A RID: 11322
		private RarityDefaultValue[] m_rarityDefaultValueListField;

		// Token: 0x04002C3B RID: 11323
		private StarLevelUpgrade[] m_starLevelUpgradeField;
	}
}
