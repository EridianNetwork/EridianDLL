using System;

namespace BHV
{
	// Token: 0x02000228 RID: 552
	public class BHVTaskCoverLookAround : BHVTaskAnimationState
	{
		// Token: 0x06000B69 RID: 2921 RVA: 0x0000B2EE File Offset: 0x000094EE
		public BHVTaskCoverLookAround()
		{
			base.m_Type = BHVTaskType.CoverLookAround;
		}

		// Token: 0x06000B6A RID: 2922 RVA: 0x0000B2FE File Offset: 0x000094FE
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamCoverLookAround_0 = bhvtaskParam_0 as BHVTaskParamCoverLookAround;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x0000B313 File Offset: 0x00009513
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamCoverLookAround_0;
		}

		// Token: 0x06000B6C RID: 2924 RVA: 0x0000B31B File Offset: 0x0000951B
		public override void Start()
		{
			base.Start();
			this.float_0 = this.bhvtaskParamCoverLookAround_0.float_0;
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x0000B334 File Offset: 0x00009534
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.CoverLookAround);
			this.float_0 -= deltaTime;
			if (this.float_0 <= 0f)
			{
				base.method_0();
			}
		}

		// Token: 0x04000A5A RID: 2650
		private BHVTaskParamCoverLookAround bhvtaskParamCoverLookAround_0;

		// Token: 0x04000A5B RID: 2651
		private float float_0;
	}
}
