using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace BHV_FSM
{
	// Token: 0x02000921 RID: 2337
	[XmlInclude(typeof(BHVFSMSettingsArchAngel))]
	[XmlInclude(typeof(BHVFSMSettingsTheInsane))]
	[XmlInclude(typeof(BHVFSMSettingSpitterQueen))]
	[XmlInclude(typeof(BHVFSMSettingsSpiderantTalos))]
	[XmlInclude(typeof(BHVFSMSettingsSpiderantWidowmaker))]
	[XmlInclude(typeof(BHVFSMSettingsApollyon))]
	[XmlInclude(typeof(BHVFSMSettingsCrimsonMechaKnoxx))]
	public class BHVPropertySettingsPhase : BHVPropertySettings
	{
		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x0600405A RID: 16474 RVA: 0x0002B05B File Offset: 0x0002925B
		// (set) Token: 0x0600405B RID: 16475 RVA: 0x0002B063 File Offset: 0x00029263
		public int m_phaseId { get; set; }

		// Token: 0x04002D24 RID: 11556
		[CompilerGenerated]
		private int int_0;
	}
}
