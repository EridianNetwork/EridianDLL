using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020008ED RID: 2285
	public class StarExpUpgradeSetup
	{
		// Token: 0x06003EE2 RID: 16098 RVA: 0x0012B764 File Offset: 0x00129964
		public ConsumedMaterial[] method_0(WeaponType weaponType_0)
		{
			for (int i = 0; i < this.m_materialConsumeList.Length; i++)
			{
				if (this.m_materialConsumeList[i].m_weaponType == weaponType_0)
				{
					return this.m_materialConsumeList[i].m_consumedMaterialList;
				}
			}
			return null;
		}

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x06003EE3 RID: 16099 RVA: 0x0002A58B File Offset: 0x0002878B
		// (set) Token: 0x06003EE4 RID: 16100 RVA: 0x0002A593 File Offset: 0x00028793
		public int m_rewardValue { get; set; }

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x06003EE5 RID: 16101 RVA: 0x0002A59C File Offset: 0x0002879C
		// (set) Token: 0x06003EE6 RID: 16102 RVA: 0x0002A5A4 File Offset: 0x000287A4
		[XmlArrayItem("m_materialConsume", IsNullable = false)]
		public MaterialConsume[] m_materialConsumeList { get; set; }

		// Token: 0x04002C3E RID: 11326
		private MaterialConsume[] m_materialConsumeListField;
	}
}
