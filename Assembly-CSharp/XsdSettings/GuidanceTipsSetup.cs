using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009BE RID: 2494
	public class GuidanceTipsSetup
	{
		// Token: 0x170005EA RID: 1514
		// (get) Token: 0x0600452A RID: 17706 RVA: 0x0002DC60 File Offset: 0x0002BE60
		// (set) Token: 0x0600452B RID: 17707 RVA: 0x0002DC68 File Offset: 0x0002BE68
		[XmlArrayItem("m_tip", IsNullable = false)]
		public GuidanceTip[] m_tips { get; set; }

		// Token: 0x040030FA RID: 12538
		private GuidanceTip[] m_tipsField;
	}
}
