using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A49 RID: 2633
	public class Skill
	{
		// Token: 0x17000705 RID: 1797
		// (get) Token: 0x060047D5 RID: 18389 RVA: 0x0002F258 File Offset: 0x0002D458
		// (set) Token: 0x060047D6 RID: 18390 RVA: 0x0002F260 File Offset: 0x0002D460
		public int m_id { get; set; }

		// Token: 0x17000706 RID: 1798
		// (get) Token: 0x060047D7 RID: 18391 RVA: 0x0002F269 File Offset: 0x0002D469
		// (set) Token: 0x060047D8 RID: 18392 RVA: 0x0002F271 File Offset: 0x0002D471
		public string m_icon { get; set; }

		// Token: 0x17000707 RID: 1799
		// (get) Token: 0x060047D9 RID: 18393 RVA: 0x0002F27A File Offset: 0x0002D47A
		// (set) Token: 0x060047DA RID: 18394 RVA: 0x0002F282 File Offset: 0x0002D482
		public string m_name { get; set; }

		// Token: 0x17000708 RID: 1800
		// (get) Token: 0x060047DB RID: 18395 RVA: 0x0002F28B File Offset: 0x0002D48B
		// (set) Token: 0x060047DC RID: 18396 RVA: 0x0002F293 File Offset: 0x0002D493
		public string m_description { get; set; }

		// Token: 0x17000709 RID: 1801
		// (get) Token: 0x060047DD RID: 18397 RVA: 0x0002F29C File Offset: 0x0002D49C
		// (set) Token: 0x060047DE RID: 18398 RVA: 0x0002F2A4 File Offset: 0x0002D4A4
		public int m_maxGrade { get; set; }

		// Token: 0x1700070A RID: 1802
		// (get) Token: 0x060047DF RID: 18399 RVA: 0x0002F2AD File Offset: 0x0002D4AD
		// (set) Token: 0x060047E0 RID: 18400 RVA: 0x0002F2B5 File Offset: 0x0002D4B5
		[XmlArrayItem("m_effect", IsNullable = false)]
		public Effect[] m_effectList { get; set; }

		// Token: 0x040033A3 RID: 13219
		private Effect[] m_effectListField;
	}
}
