using System;
using ns0;

namespace BHV
{
	// Token: 0x0200023E RID: 574
	public class BHVTaskPlayerTransfer : BHVTask
	{
		// Token: 0x06000BB8 RID: 3000 RVA: 0x0000B73A File Offset: 0x0000993A
		public BHVTaskPlayerTransfer()
		{
			base.m_Type = BHVTaskType.PlayerTransfer;
		}

		// Token: 0x06000BB9 RID: 3001 RVA: 0x0000B74A File Offset: 0x0000994A
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamPlayerTransfer_0 = bhvtaskParam_0 as BHVTaskParamPlayerTransfer;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000BBA RID: 3002 RVA: 0x0000B75F File Offset: 0x0000995F
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamPlayerTransfer_0;
		}

		// Token: 0x06000BBB RID: 3003 RVA: 0x00067874 File Offset: 0x00065A74
		public override void Start()
		{
			base.Start();
			Entity entity = this.bhvtaskManager_0.m_entity;
			if (entity.vmethod_26())
			{
				MonoSingleton<InputManager>.Instance.method_1(false);
				MonoSingleton<AppManager>.Instance.method_0().vmethod_19(false);
				MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_3(FrontEndStepManager.StepState.none, null);
				MonoSingleton<AppManager>.Instance.method_0().vmethod_6<LoadingInGameView>().method_3(MonoSingleton<AppManager>.Instance.m_playlistId);
			}
			else
			{
				this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.PlayerIdle);
			}
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		// Token: 0x06000BBC RID: 3004 RVA: 0x00067904 File Offset: 0x00065B04
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
			Entity entity = this.bhvtaskManager_0.m_entity;
			if (entity.vmethod_26())
			{
				MonoSingleton<GameFlowManager>.Instance.method_18();
			}
		}

		// Token: 0x04000A8B RID: 2699
		private BHVTaskParamPlayerTransfer bhvtaskParamPlayerTransfer_0;
	}
}
