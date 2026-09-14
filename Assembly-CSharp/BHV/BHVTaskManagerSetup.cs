using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace BHV
{
	// Token: 0x0200015D RID: 349
	public class BHVTaskManagerSetup
	{
		// Token: 0x06000815 RID: 2069 RVA: 0x0005A7AC File Offset: 0x000589AC
		public void method_0()
		{
			if (this.m_settings != null && this.m_settings.Length > 0)
			{
				for (int i = 0; i < this.m_settings.Length; i++)
				{
					this.dictionary_0.Add(this.m_settings[i].GetType(), this.m_settings[i]);
				}
				return;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000816 RID: 2070 RVA: 0x000083E8 File Offset: 0x000065E8
		// (set) Token: 0x06000817 RID: 2071 RVA: 0x000083F0 File Offset: 0x000065F0
		[XmlArrayItem("m_taskSettings", IsNullable = false)]
		public BHVTaskSettings[] m_settings { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000818 RID: 2072 RVA: 0x000083F9 File Offset: 0x000065F9
		// (set) Token: 0x06000819 RID: 2073 RVA: 0x00008401 File Offset: 0x00006601
		public string m_entityType { get; set; }

		// Token: 0x0400070F RID: 1807
		[XmlIgnore]
		public Dictionary<Type, BHVTaskSettings> dictionary_0 = new Dictionary<Type, BHVTaskSettings>();

		// Token: 0x04000710 RID: 1808
		private BHVTaskSettings[] bhvtaskSettings_0;

		// Token: 0x04000711 RID: 1809
		[CompilerGenerated]
		private BHVTaskSettings[] bhvtaskSettings_1;

		// Token: 0x04000712 RID: 1810
		[CompilerGenerated]
		private string string_0;
	}
}
