using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A38 RID: 2616
	public class ShieldSubpartsInRarity
	{
		// Token: 0x170006E9 RID: 1769
		// (get) Token: 0x0600478C RID: 18316 RVA: 0x0002EFF2 File Offset: 0x0002D1F2
		// (set) Token: 0x0600478D RID: 18317 RVA: 0x0002EFFA File Offset: 0x0002D1FA
		public ShieldSubPart m_shieldSubpart { get; set; }

		// Token: 0x170006EA RID: 1770
		// (get) Token: 0x0600478E RID: 18318 RVA: 0x0002F003 File Offset: 0x0002D203
		// (set) Token: 0x0600478F RID: 18319 RVA: 0x0002F00B File Offset: 0x0002D20B
		[XmlArrayItem("m_subpartChoice", IsNullable = false)]
		public ShieldSubpartChoice[] m_subpartChoices { get; set; }

		// Token: 0x04003377 RID: 13175
		private ShieldSubPart m_shieldSubpartField;

		// Token: 0x04003378 RID: 13176
		private ShieldSubpartChoice[] m_subpartChoicesField;
	}
}
