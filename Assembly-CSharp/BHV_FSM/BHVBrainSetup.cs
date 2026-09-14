using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace BHV_FSM
{
	// Token: 0x0200091B RID: 2331
	public class BHVBrainSetup
	{
		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x0600402C RID: 16428 RVA: 0x0002AECE File Offset: 0x000290CE
		// (set) Token: 0x0600402D RID: 16429 RVA: 0x0002AED6 File Offset: 0x000290D6
		public string m_fsmType { get; set; }

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x0600402E RID: 16430 RVA: 0x0002AEDF File Offset: 0x000290DF
		// (set) Token: 0x0600402F RID: 16431 RVA: 0x0002AEE7 File Offset: 0x000290E7
		[XmlArrayItem("m_BHVPropertySettings", IsNullable = false)]
		public BHVPropertySettings[] m_BHVPropertySettingsList { get; set; }

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06004030 RID: 16432 RVA: 0x0002AEF0 File Offset: 0x000290F0
		// (set) Token: 0x06004031 RID: 16433 RVA: 0x0002AEF8 File Offset: 0x000290F8
		[XmlArrayItem("m_BHVPropertySettingsPhase", IsNullable = false)]
		public BHVPropertySettingsPhase[] m_BHVPropertySettingsPhaseList { get; set; }

		// Token: 0x04002D0E RID: 11534
		private BHVPropertySettings[] bhvpropertySettings_0;

		// Token: 0x04002D0F RID: 11535
		private BHVPropertySettingsPhase[] bhvpropertySettingsPhase_0;

		// Token: 0x04002D10 RID: 11536
		[CompilerGenerated]
		private string string_0;

		// Token: 0x04002D11 RID: 11537
		[CompilerGenerated]
		private BHVPropertySettings[] bhvpropertySettings_1;

		// Token: 0x04002D12 RID: 11538
		[CompilerGenerated]
		private BHVPropertySettingsPhase[] bhvpropertySettingsPhase_1;
	}
}
