using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009D4 RID: 2516
	public class LadderProgression
	{
		// Token: 0x17000614 RID: 1556
		// (get) Token: 0x06004593 RID: 17811 RVA: 0x0002DFF0 File Offset: 0x0002C1F0
		// (set) Token: 0x06004594 RID: 17812 RVA: 0x0002DFF8 File Offset: 0x0002C1F8
		[XmlArrayItem("m_ladder", IsNullable = false)]
		public LadderProgressionData[] m_progressionTable { get; set; }

		// Token: 0x04003140 RID: 12608
		private LadderProgressionData[] m_progressionTableField;
	}
}
