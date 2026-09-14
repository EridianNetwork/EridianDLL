using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009FF RID: 2559
	public class QuestSetup
	{
		// Token: 0x17000673 RID: 1651
		// (get) Token: 0x06004676 RID: 18038 RVA: 0x0002E76E File Offset: 0x0002C96E
		// (set) Token: 0x06004677 RID: 18039 RVA: 0x0002E776 File Offset: 0x0002C976
		[XmlArrayItem("mQuest", IsNullable = false)]
		public Quest[] mQuests { get; set; }

		// Token: 0x04003212 RID: 12818
		private Quest[] mQuestsField;
	}
}
