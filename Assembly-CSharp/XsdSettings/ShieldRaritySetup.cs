using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A35 RID: 2613
	public class ShieldRaritySetup
	{
		// Token: 0x170006E6 RID: 1766
		// (get) Token: 0x06004784 RID: 18308 RVA: 0x0002EFBF File Offset: 0x0002D1BF
		// (set) Token: 0x06004785 RID: 18309 RVA: 0x0002EFC7 File Offset: 0x0002D1C7
		[XmlArrayItem("m_shieldRarity", IsNullable = false)]
		public ShieldRarityConfig[] m_shieldRarities { get; set; }

		// Token: 0x04003369 RID: 13161
		private ShieldRarityConfig[] m_shieldRaritiesField;
	}
}
