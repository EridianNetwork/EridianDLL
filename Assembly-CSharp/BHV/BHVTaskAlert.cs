using System;

namespace BHV
{
	// Token: 0x020001A4 RID: 420
	public class BHVTaskAlert : BHVTaskAnimationState
	{
		// Token: 0x06000940 RID: 2368 RVA: 0x0000942A File Offset: 0x0000762A
		public BHVTaskAlert()
		{
			base.m_Type = BHVTaskType.Alert;
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x0000943A File Offset: 0x0000763A
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamAlert_0 = bhvtaskParam_0 as BHVTaskParamAlert;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x0000944F File Offset: 0x0000764F
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamAlert_0;
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x0005D880 File Offset: 0x0005BA80
		public override void Start()
		{
			base.Start();
			if (this.animationAlertState_0 == null)
			{
				this.animationAlertState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16(Utils.smethod_23(AnimationStateFSM.Alert)) as AnimationAlertState;
			}
			if (this.animationAlertState_0 != null)
			{
				this.animationAlertState_0.m_isWarning = this.bhvtaskParamAlert_0.bool_1;
			}
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x00009457 File Offset: 0x00007657
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.Alert);
		}

		// Token: 0x0400086C RID: 2156
		private BHVTaskParamAlert bhvtaskParamAlert_0;

		// Token: 0x0400086D RID: 2157
		private AnimationAlertState animationAlertState_0;
	}
}
