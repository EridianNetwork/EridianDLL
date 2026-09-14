using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009AE RID: 2478
	public class EchoMessage
	{
		// Token: 0x060044C8 RID: 17608 RVA: 0x0002D90F File Offset: 0x0002BB0F
		public EchoMessage()
		{
			this.m_id = string.Empty;
			this.m_localizedText = "localized text";
			this.m_npcIcon = string.Empty;
		}

		// Token: 0x170005C1 RID: 1473
		// (get) Token: 0x060044C9 RID: 17609 RVA: 0x0002D938 File Offset: 0x0002BB38
		// (set) Token: 0x060044CA RID: 17610 RVA: 0x0002D940 File Offset: 0x0002BB40
		public string m_id { get; set; }

		// Token: 0x170005C2 RID: 1474
		// (get) Token: 0x060044CB RID: 17611 RVA: 0x0002D949 File Offset: 0x0002BB49
		// (set) Token: 0x060044CC RID: 17612 RVA: 0x0002D951 File Offset: 0x0002BB51
		[XmlArrayItem("m_target", IsNullable = false)]
		public DisplayTarget[] m_displayTargets { get; set; }

		// Token: 0x170005C3 RID: 1475
		// (get) Token: 0x060044CD RID: 17613 RVA: 0x0002D95A File Offset: 0x0002BB5A
		// (set) Token: 0x060044CE RID: 17614 RVA: 0x0002D962 File Offset: 0x0002BB62
		public string m_localizedText { get; set; }

		// Token: 0x170005C4 RID: 1476
		// (get) Token: 0x060044CF RID: 17615 RVA: 0x0002D96B File Offset: 0x0002BB6B
		// (set) Token: 0x060044D0 RID: 17616 RVA: 0x0002D973 File Offset: 0x0002BB73
		[DefaultValue("")]
		public string m_npcIcon { get; set; }

		// Token: 0x170005C5 RID: 1477
		// (get) Token: 0x060044D1 RID: 17617 RVA: 0x0002D97C File Offset: 0x0002BB7C
		// (set) Token: 0x060044D2 RID: 17618 RVA: 0x0002D984 File Offset: 0x0002BB84
		public string m_localizedKey { get; set; }

		// Token: 0x040030BA RID: 12474
		private DisplayTarget[] m_displayTargetsField;
	}
}
