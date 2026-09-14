using System;

namespace XsdSettings
{
	// Token: 0x02000A14 RID: 2580
	public class KillScoreType
	{
		// Token: 0x060046EA RID: 18154 RVA: 0x0002EB0B File Offset: 0x0002CD0B
		public KillScoreType()
		{
			this.m_score = 0;
		}

		// Token: 0x170006A6 RID: 1702
		// (get) Token: 0x060046EB RID: 18155 RVA: 0x0002EB1A File Offset: 0x0002CD1A
		// (set) Token: 0x060046EC RID: 18156 RVA: 0x0002EB22 File Offset: 0x0002CD22
		public string m_enemyRank { get; set; }

		// Token: 0x170006A7 RID: 1703
		// (get) Token: 0x060046ED RID: 18157 RVA: 0x0002EB2B File Offset: 0x0002CD2B
		// (set) Token: 0x060046EE RID: 18158 RVA: 0x0002EB33 File Offset: 0x0002CD33
		public int m_score { get; set; }
	}
}
