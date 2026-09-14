using System;

namespace BHV
{
	// Token: 0x020001BD RID: 445
	public class BHVTaskDestoryMissile : BHVTask
	{
		// Token: 0x06000998 RID: 2456 RVA: 0x000099E2 File Offset: 0x00007BE2
		public BHVTaskDestoryMissile()
		{
			base.m_Type = BHVTaskType.DestoryMissile;
			base.m_Layer = BHVTaskLayer.ADDITIVE;
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x000099F9 File Offset: 0x00007BF9
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamDestoryMissile_0 = bhvtaskParam_0 as BHVTaskParamDestoryMissile;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x00009A0E File Offset: 0x00007C0E
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamDestoryMissile_0;
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x00009A16 File Offset: 0x00007C16
		public override void Start()
		{
			base.Start();
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x0005E6DC File Offset: 0x0005C8DC
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			if ((float)this.bhvtaskParamDestoryMissile_0.int_4 <= 0f)
			{
				AIServiceUtility.AIServiceUtility_0.method_3(this.bhvtaskParamDestoryMissile_0.int_3);
			}
			else
			{
				AIServiceUtility.AIServiceUtility_0.method_4(this.bhvtaskParamDestoryMissile_0.int_3, this.bhvtaskParamDestoryMissile_0.int_4);
			}
			base.m_Status = BHVTaskStatus.SUCCESS;
		}

		// Token: 0x040008AB RID: 2219
		private BHVTaskParamDestoryMissile bhvtaskParamDestoryMissile_0;
	}
}
