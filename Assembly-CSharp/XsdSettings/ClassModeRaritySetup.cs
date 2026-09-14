using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x0200099C RID: 2460
	public class ClassModeRaritySetup
	{
		// Token: 0x170005AA RID: 1450
		// (get) Token: 0x0600448C RID: 17548 RVA: 0x0002D788 File Offset: 0x0002B988
		// (set) Token: 0x0600448D RID: 17549 RVA: 0x0002D790 File Offset: 0x0002B990
		[XmlArrayItem("m_classModeRarity", IsNullable = false)]
		public ClassModeRarityConfig[] m_classModeRarities { get; set; }

		// Token: 0x04003003 RID: 12291
		private ClassModeRarityConfig[] m_classModeRaritiesField;
	}
}
