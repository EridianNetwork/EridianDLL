using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000936 RID: 2358
	public class BHVFSMSettingsDetection : BHVPropertySettings
	{
		// Token: 0x0600416A RID: 16746 RVA: 0x0002BA5B File Offset: 0x00029C5B
		public BHVFSMSettingsDetection()
		{
			this.m_visualDetectionRange = 0f;
			this.m_visualDetectionAngle = 0f;
			this.m_auditionDetectionRange = 0f;
			this.m_shootAtAngle = 0.9f;
			this.m_shootDistance = 30f;
		}

		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x0600416B RID: 16747 RVA: 0x0002BA9A File Offset: 0x00029C9A
		// (set) Token: 0x0600416C RID: 16748 RVA: 0x0002BAA2 File Offset: 0x00029CA2
		[DefaultValue(typeof(float), "0")]
		public float m_visualDetectionRange { get; set; }

		// Token: 0x17000444 RID: 1092
		// (get) Token: 0x0600416D RID: 16749 RVA: 0x0002BAAB File Offset: 0x00029CAB
		// (set) Token: 0x0600416E RID: 16750 RVA: 0x0002BAB3 File Offset: 0x00029CB3
		[DefaultValue(typeof(float), "0")]
		public float m_visualDetectionAngle { get; set; }

		// Token: 0x17000445 RID: 1093
		// (get) Token: 0x0600416F RID: 16751 RVA: 0x0002BABC File Offset: 0x00029CBC
		// (set) Token: 0x06004170 RID: 16752 RVA: 0x0002BAC4 File Offset: 0x00029CC4
		[DefaultValue(typeof(float), "0")]
		public float m_auditionDetectionRange { get; set; }

		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x06004171 RID: 16753 RVA: 0x0002BACD File Offset: 0x00029CCD
		// (set) Token: 0x06004172 RID: 16754 RVA: 0x0002BAD5 File Offset: 0x00029CD5
		[DefaultValue(typeof(float), "0.9")]
		public float m_shootAtAngle { get; set; }

		// Token: 0x17000447 RID: 1095
		// (get) Token: 0x06004173 RID: 16755 RVA: 0x0002BADE File Offset: 0x00029CDE
		// (set) Token: 0x06004174 RID: 16756 RVA: 0x0002BAE6 File Offset: 0x00029CE6
		[DefaultValue(typeof(float), "30")]
		public float m_shootDistance { get; set; }

		// Token: 0x04002DA2 RID: 11682
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002DA3 RID: 11683
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002DA4 RID: 11684
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002DA5 RID: 11685
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002DA6 RID: 11686
		[CompilerGenerated]
		private float float_4;
	}
}
