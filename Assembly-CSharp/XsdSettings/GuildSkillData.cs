using System;

namespace XsdSettings
{
	// Token: 0x020009CD RID: 2509
	public class GuildSkillData
	{
		// Token: 0x06004577 RID: 17783 RVA: 0x0002DF1A File Offset: 0x0002C11A
		public GuildSkillData()
		{
			this.m_id = 0;
			this.m_unlockLevel = 1;
			this.m_type = "scale";
			this.m_value = 0f;
		}

		// Token: 0x1700060A RID: 1546
		// (get) Token: 0x06004578 RID: 17784 RVA: 0x0002DF46 File Offset: 0x0002C146
		// (set) Token: 0x06004579 RID: 17785 RVA: 0x0002DF4E File Offset: 0x0002C14E
		public int m_id { get; set; }

		// Token: 0x1700060B RID: 1547
		// (get) Token: 0x0600457A RID: 17786 RVA: 0x0002DF57 File Offset: 0x0002C157
		// (set) Token: 0x0600457B RID: 17787 RVA: 0x0002DF5F File Offset: 0x0002C15F
		public int m_unlockLevel { get; set; }

		// Token: 0x1700060C RID: 1548
		// (get) Token: 0x0600457C RID: 17788 RVA: 0x0002DF68 File Offset: 0x0002C168
		// (set) Token: 0x0600457D RID: 17789 RVA: 0x0002DF70 File Offset: 0x0002C170
		public string m_type { get; set; }

		// Token: 0x1700060D RID: 1549
		// (get) Token: 0x0600457E RID: 17790 RVA: 0x0002DF79 File Offset: 0x0002C179
		// (set) Token: 0x0600457F RID: 17791 RVA: 0x0002DF81 File Offset: 0x0002C181
		public float m_value { get; set; }
	}
}
