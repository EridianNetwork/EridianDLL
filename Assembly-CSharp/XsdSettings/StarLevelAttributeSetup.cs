using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020008EB RID: 2283
	public class StarLevelAttributeSetup
	{
		// Token: 0x06003ED6 RID: 16086 RVA: 0x0012B4D8 File Offset: 0x001296D8
		public List<SingleWeaponAttribute> method_0(WeaponType weaponType_0, int int_0)
		{
			List<SingleWeaponAttribute> list = new List<SingleWeaponAttribute>();
			for (int i = 0; i < this.m_starLevelAttributeList.Length; i++)
			{
				if (this.m_starLevelAttributeList[i].m_weaponType == weaponType_0)
				{
					for (int j = 0; j < this.m_starLevelAttributeList[i].m_levelAttributeList.Length; j++)
					{
						if (this.m_starLevelAttributeList[i].m_levelAttributeList[j].m_starLevel < int_0)
						{
							for (int k = 0; k < this.m_starLevelAttributeList[i].m_levelAttributeList[j].m_weaponAttributeList.Length; k++)
							{
								list.Add(this.m_starLevelAttributeList[i].m_levelAttributeList[j].m_weaponAttributeList[k]);
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x06003ED7 RID: 16087 RVA: 0x0012B584 File Offset: 0x00129784
		public List<SingleWeaponAttribute> method_1(WeaponType weaponType_0, int int_0)
		{
			List<SingleWeaponAttribute> list = new List<SingleWeaponAttribute>();
			for (int i = 0; i < this.m_starLevelAttributeList.Length; i++)
			{
				if (this.m_starLevelAttributeList[i].m_weaponType == weaponType_0)
				{
					for (int j = 0; j < this.m_starLevelAttributeList[i].m_levelAttributeList.Length; j++)
					{
						if (this.m_starLevelAttributeList[i].m_levelAttributeList[j].m_starLevel == int_0)
						{
							for (int k = 0; k < this.m_starLevelAttributeList[i].m_levelAttributeList[j].m_weaponAttributeList.Length; k++)
							{
								list.Add(this.m_starLevelAttributeList[i].m_levelAttributeList[j].m_weaponAttributeList[k]);
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x06003ED8 RID: 16088 RVA: 0x0002A558 File Offset: 0x00028758
		// (set) Token: 0x06003ED9 RID: 16089 RVA: 0x0002A560 File Offset: 0x00028760
		[XmlArrayItem("m_starLevelAttribute", IsNullable = false)]
		public StarLevelAttribute[] m_starLevelAttributeList { get; set; }

		// Token: 0x04002C38 RID: 11320
		private StarLevelAttribute[] m_starLevelAttributeListField;
	}
}
