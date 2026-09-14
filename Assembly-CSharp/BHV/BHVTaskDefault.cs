using System;

namespace BHV
{
	// Token: 0x0200017C RID: 380
	public class BHVTaskDefault : BHVTask
	{
		// Token: 0x06000897 RID: 2199 RVA: 0x00008A1E File Offset: 0x00006C1E
		public BHVTaskDefault()
		{
			base.m_Type = BHVTaskType.Default;
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x00008A2E File Offset: 0x00006C2E
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamDefault_0 = bhvtaskParam_0 as BHVTaskParamDefault;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x00008A43 File Offset: 0x00006C43
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamDefault_0;
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x0000872C File Offset: 0x0000692C
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			base.m_Status = BHVTaskStatus.SUCCESS;
		}

		// Token: 0x0400080B RID: 2059
		private BHVTaskParamDefault bhvtaskParamDefault_0;
	}
}
