using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x0200097F RID: 2431
	public class NPCLevelMultipliersSetup
	{
		// Token: 0x1700058A RID: 1418
		// (get) Token: 0x06004440 RID: 17472 RVA: 0x0002D52F File Offset: 0x0002B72F
		// (set) Token: 0x06004441 RID: 17473 RVA: 0x0002D537 File Offset: 0x0002B737
		[XmlArrayItem("m_NPCLevelMultipliers", IsNullable = false)]
		public NPCLevelMultipliers[] m_NPCLevelMultipliersList { get; set; }

		// Token: 0x04002F17 RID: 12055
		private NPCLevelMultipliers[] m_NPCLevelMultipliersListField;
	}
}
