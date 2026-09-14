using System;

namespace BHV
{
	// Token: 0x02000195 RID: 405
	public class BHVTaskSlideMoveTo : BHVTask
	{
		// Token: 0x06000906 RID: 2310 RVA: 0x000090AB File Offset: 0x000072AB
		public BHVTaskSlideMoveTo()
		{
			base.m_Type = BHVTaskType.SlideMoveTo;
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x000090C1 File Offset: 0x000072C1
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamSlideMoveTo_0 = bhvtaskParam_0 as BHVTaskParamSlideMoveTo;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x000090D6 File Offset: 0x000072D6
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamSlideMoveTo_0;
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x000090DE File Offset: 0x000072DE
		public override void Start()
		{
			base.Start();
			this.state_0 = BHVTaskSlideMoveTo.State.const_1;
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x0005D2A8 File Offset: 0x0005B4A8
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			BHVTaskSlideMoveTo.State state = this.state_0;
			switch (state + 1)
			{
			case BHVTaskSlideMoveTo.State.const_1:
				base.m_Status = BHVTaskStatus.FAILED;
				return;
			case BHVTaskSlideMoveTo.State.const_2:
				this.bhvtaskManager_0.vmethod_0<BHVNavAgentSettings>().m_canUseFacingLogic = true;
				this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.SlideMove);
				this.bhvtaskManager_0.m_animationManagerFSM.vmethod_11(this.bhvtaskParamSlideMoveTo_0.bool_1);
				this.state_0 = BHVTaskSlideMoveTo.State.const_2;
				return;
			case BHVTaskSlideMoveTo.State.const_3:
				return;
			case BHVTaskSlideMoveTo.State.const_4:
				return;
			default:
				return;
			}
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x00008E2F File Offset: 0x0000702F
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
		}

		// Token: 0x04000853 RID: 2131
		private BHVTaskParamSlideMoveTo bhvtaskParamSlideMoveTo_0;

		// Token: 0x04000854 RID: 2132
		private BHVTaskSlideMoveTo.State state_0 = BHVTaskSlideMoveTo.State.const_0;

		// Token: 0x02000196 RID: 406
		private enum State
		{
			// Token: 0x04000856 RID: 2134
			const_0 = -1,
			// Token: 0x04000857 RID: 2135
			const_1,
			// Token: 0x04000858 RID: 2136
			const_2,
			// Token: 0x04000859 RID: 2137
			const_3,
			// Token: 0x0400085A RID: 2138
			const_4
		}
	}
}
