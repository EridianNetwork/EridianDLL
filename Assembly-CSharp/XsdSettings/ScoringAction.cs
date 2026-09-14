using System;

namespace XsdSettings
{
	// Token: 0x02000A18 RID: 2584
	public class ScoringAction
	{
		// Token: 0x06004702 RID: 18178 RVA: 0x0002EBD7 File Offset: 0x0002CDD7
		public ScoringAction()
		{
			this.m_scoringActionType = ScoringActionType.BasicKill;
			this.m_value = 0;
			this.m_medalType = MedalType.None;
		}

		// Token: 0x170006B0 RID: 1712
		// (get) Token: 0x06004703 RID: 18179 RVA: 0x0002EBF4 File Offset: 0x0002CDF4
		// (set) Token: 0x06004704 RID: 18180 RVA: 0x0002EBFC File Offset: 0x0002CDFC
		public ScoringActionType m_scoringActionType { get; set; }

		// Token: 0x170006B1 RID: 1713
		// (get) Token: 0x06004705 RID: 18181 RVA: 0x0002EC05 File Offset: 0x0002CE05
		// (set) Token: 0x06004706 RID: 18182 RVA: 0x0002EC0D File Offset: 0x0002CE0D
		public int m_value { get; set; }

		// Token: 0x170006B2 RID: 1714
		// (get) Token: 0x06004707 RID: 18183 RVA: 0x0002EC16 File Offset: 0x0002CE16
		// (set) Token: 0x06004708 RID: 18184 RVA: 0x0002EC1E File Offset: 0x0002CE1E
		public MedalType m_medalType { get; set; }
	}
}
