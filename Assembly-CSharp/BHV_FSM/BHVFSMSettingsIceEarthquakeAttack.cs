using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000953 RID: 2387
	public class BHVFSMSettingsIceEarthquakeAttack : BHVPropertySettingsAttackBase
	{
		// Token: 0x06004250 RID: 16976 RVA: 0x0002C2E5 File Offset: 0x0002A4E5
		public BHVFSMSettingsIceEarthquakeAttack()
		{
			this.m_shardAmount = 10;
			this.m_shardDamage = 30;
			this.m_shardFollowNumber = 5;
			this.m_shardDamageRadius = 1.5f;
			this.m_shardTimeInterval = 0.5f;
			this.m_shardDistanceInterval = 1.5f;
		}

		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x06004251 RID: 16977 RVA: 0x0002C325 File Offset: 0x0002A525
		// (set) Token: 0x06004252 RID: 16978 RVA: 0x0002C32D File Offset: 0x0002A52D
		[DefaultValue(10)]
		public int m_shardAmount { get; set; }

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x06004253 RID: 16979 RVA: 0x0002C336 File Offset: 0x0002A536
		// (set) Token: 0x06004254 RID: 16980 RVA: 0x0002C33E File Offset: 0x0002A53E
		[DefaultValue(30)]
		public int m_shardDamage { get; set; }

		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x06004255 RID: 16981 RVA: 0x0002C347 File Offset: 0x0002A547
		// (set) Token: 0x06004256 RID: 16982 RVA: 0x0002C34F File Offset: 0x0002A54F
		[DefaultValue(5)]
		public int m_shardFollowNumber { get; set; }

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x06004257 RID: 16983 RVA: 0x0002C358 File Offset: 0x0002A558
		// (set) Token: 0x06004258 RID: 16984 RVA: 0x0002C360 File Offset: 0x0002A560
		[DefaultValue(typeof(float), "1.5")]
		public float m_shardDamageRadius { get; set; }

		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x06004259 RID: 16985 RVA: 0x0002C369 File Offset: 0x0002A569
		// (set) Token: 0x0600425A RID: 16986 RVA: 0x0002C371 File Offset: 0x0002A571
		[DefaultValue(typeof(float), "0.5")]
		public float m_shardTimeInterval { get; set; }

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x0600425B RID: 16987 RVA: 0x0002C37A File Offset: 0x0002A57A
		// (set) Token: 0x0600425C RID: 16988 RVA: 0x0002C382 File Offset: 0x0002A582
		[DefaultValue(typeof(float), "1.5")]
		public float m_shardDistanceInterval { get; set; }

		// Token: 0x04002E2B RID: 11819
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002E2C RID: 11820
		[CompilerGenerated]
		private int int_1;

		// Token: 0x04002E2D RID: 11821
		[CompilerGenerated]
		private int int_2;

		// Token: 0x04002E2E RID: 11822
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002E2F RID: 11823
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002E30 RID: 11824
		[CompilerGenerated]
		private float float_5;
	}
}
