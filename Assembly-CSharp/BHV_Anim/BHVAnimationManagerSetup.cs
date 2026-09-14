using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace BHV_Anim
{
	// Token: 0x02000917 RID: 2327
	public class BHVAnimationManagerSetup
	{
		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x0600400C RID: 16396 RVA: 0x0002ADE0 File Offset: 0x00028FE0
		// (set) Token: 0x0600400D RID: 16397 RVA: 0x0002ADE8 File Offset: 0x00028FE8
		public BHVAnimationManagerSettings m_settings { get; set; }

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x0600400E RID: 16398 RVA: 0x0002ADF1 File Offset: 0x00028FF1
		// (set) Token: 0x0600400F RID: 16399 RVA: 0x0002ADF9 File Offset: 0x00028FF9
		[XmlArrayItem("m_stateName", IsNullable = false)]
		public string[] m_animationStateList { get; set; }

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06004010 RID: 16400 RVA: 0x0002AE02 File Offset: 0x00029002
		// (set) Token: 0x06004011 RID: 16401 RVA: 0x0002AE0A File Offset: 0x0002900A
		[XmlArrayItem("m_stateName", IsNullable = false)]
		public string[] m_animationUpperBodyStateList { get; set; }

		// Token: 0x04002CFF RID: 11519
		private BHVAnimationManagerSettings bhvanimationManagerSettings_0;

		// Token: 0x04002D00 RID: 11520
		[CompilerGenerated]
		private BHVAnimationManagerSettings bhvanimationManagerSettings_1;

		// Token: 0x04002D01 RID: 11521
		[CompilerGenerated]
		private string[] string_0;

		// Token: 0x04002D02 RID: 11522
		[CompilerGenerated]
		private string[] string_1;
	}
}
