using System;

namespace BHV
{
	// Token: 0x0200019A RID: 410
	public class BHVTaskSummonExtraNPC : BHVTaskAnimationState
	{
		// Token: 0x06000915 RID: 2325 RVA: 0x000091A9 File Offset: 0x000073A9
		public BHVTaskSummonExtraNPC()
		{
			base.m_Type = BHVTaskType.SummonExtraNPC;
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x000091B9 File Offset: 0x000073B9
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamSummonExtraNPC_0 = bhvtaskParam_0 as BHVTaskParamSummonExtraNPC;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x000091CE File Offset: 0x000073CE
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamSummonExtraNPC_0;
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x000091D6 File Offset: 0x000073D6
		public override void Start()
		{
			base.Start();
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x000091DE File Offset: 0x000073DE
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.SummonExtraNPC);
		}

		// Token: 0x0400085D RID: 2141
		private BHVTaskParamSummonExtraNPC bhvtaskParamSummonExtraNPC_0;
	}
}
