using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A70 RID: 2672
	public class TownNpcSetup
	{
		// Token: 0x17000746 RID: 1862
		// (get) Token: 0x0600487A RID: 18554 RVA: 0x0002F6B8 File Offset: 0x0002D8B8
		// (set) Token: 0x0600487B RID: 18555 RVA: 0x0002F6C0 File Offset: 0x0002D8C0
		[XmlArrayItem("m_npc", IsNullable = false)]
		public TownNpc[] m_npcs { get; set; }

		// Token: 0x04003529 RID: 13609
		private TownNpc[] m_npcsField;
	}
}
