using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000957 RID: 2391
	public class BHVFSMSettingsRoundMeleeAttack : BHVPropertySettingsAttackBase
	{
		// Token: 0x0600426C RID: 17004 RVA: 0x0012EF38 File Offset: 0x0012D138
		public BHVFSMSettingsRoundMeleeAttack()
		{
			this.m_meleeAttackCountMin = 2;
			this.m_meleeAttackCountMax = 4;
			this.m_meleeAttackDistanceMin = 0f;
			this.m_meleeAttackDistanceMax = 0f;
			this.m_meleeAttackAngle = 0f;
			this.m_meleeAttackIdleTime = 0f;
			this.m_moveBackDistanceMin = 5f;
			this.m_moveBackDistanceMax = 10f;
			this.m_moveBackChance = 0.5f;
		}

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x0600426D RID: 17005 RVA: 0x0002C44B File Offset: 0x0002A64B
		// (set) Token: 0x0600426E RID: 17006 RVA: 0x0002C453 File Offset: 0x0002A653
		[DefaultValue(2)]
		public int m_meleeAttackCountMin { get; set; }

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x0600426F RID: 17007 RVA: 0x0002C45C File Offset: 0x0002A65C
		// (set) Token: 0x06004270 RID: 17008 RVA: 0x0002C464 File Offset: 0x0002A664
		[DefaultValue(4)]
		public int m_meleeAttackCountMax { get; set; }

		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x06004271 RID: 17009 RVA: 0x0002C46D File Offset: 0x0002A66D
		// (set) Token: 0x06004272 RID: 17010 RVA: 0x0002C475 File Offset: 0x0002A675
		[DefaultValue(typeof(float), "0")]
		public float m_meleeAttackDistanceMin { get; set; }

		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x06004273 RID: 17011 RVA: 0x0002C47E File Offset: 0x0002A67E
		// (set) Token: 0x06004274 RID: 17012 RVA: 0x0002C486 File Offset: 0x0002A686
		[DefaultValue(typeof(float), "0")]
		public float m_meleeAttackDistanceMax { get; set; }

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x06004275 RID: 17013 RVA: 0x0002C48F File Offset: 0x0002A68F
		// (set) Token: 0x06004276 RID: 17014 RVA: 0x0002C497 File Offset: 0x0002A697
		[DefaultValue(typeof(float), "0")]
		public float m_meleeAttackAngle { get; set; }

		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x06004277 RID: 17015 RVA: 0x0002C4A0 File Offset: 0x0002A6A0
		// (set) Token: 0x06004278 RID: 17016 RVA: 0x0002C4A8 File Offset: 0x0002A6A8
		[DefaultValue(typeof(float), "0")]
		public float m_meleeAttackIdleTime { get; set; }

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x06004279 RID: 17017 RVA: 0x0002C4B1 File Offset: 0x0002A6B1
		// (set) Token: 0x0600427A RID: 17018 RVA: 0x0002C4B9 File Offset: 0x0002A6B9
		[DefaultValue(typeof(float), "5")]
		public float m_moveBackDistanceMin { get; set; }

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x0600427B RID: 17019 RVA: 0x0002C4C2 File Offset: 0x0002A6C2
		// (set) Token: 0x0600427C RID: 17020 RVA: 0x0002C4CA File Offset: 0x0002A6CA
		[DefaultValue(typeof(float), "10")]
		public float m_moveBackDistanceMax { get; set; }

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x0600427D RID: 17021 RVA: 0x0002C4D3 File Offset: 0x0002A6D3
		// (set) Token: 0x0600427E RID: 17022 RVA: 0x0002C4DB File Offset: 0x0002A6DB
		[DefaultValue(typeof(float), "0.5")]
		public float m_moveBackChance { get; set; }

		// Token: 0x04002E37 RID: 11831
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002E38 RID: 11832
		[CompilerGenerated]
		private int int_1;

		// Token: 0x04002E39 RID: 11833
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002E3A RID: 11834
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002E3B RID: 11835
		[CompilerGenerated]
		private float float_5;

		// Token: 0x04002E3C RID: 11836
		[CompilerGenerated]
		private float float_6;

		// Token: 0x04002E3D RID: 11837
		[CompilerGenerated]
		private float float_7;

		// Token: 0x04002E3E RID: 11838
		[CompilerGenerated]
		private float float_8;

		// Token: 0x04002E3F RID: 11839
		[CompilerGenerated]
		private float float_9;
	}
}
