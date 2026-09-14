using System;
using ns0;

namespace BHV
{
	// Token: 0x02000236 RID: 566
	public class BHVTaskPlayerRevive : BHVTask
	{
		// Token: 0x06000B9D RID: 2973 RVA: 0x0000B616 File Offset: 0x00009816
		public BHVTaskPlayerRevive()
		{
			base.m_Type = BHVTaskType.PlayerRevive;
		}

		// Token: 0x06000B9E RID: 2974 RVA: 0x0000B626 File Offset: 0x00009826
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamPlayerRevive_0 = bhvtaskParam_0 as BHVTaskParamPlayerRevive;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000B9F RID: 2975 RVA: 0x0000B63B File Offset: 0x0000983B
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamPlayerRevive_0;
		}

		// Token: 0x06000BA0 RID: 2976 RVA: 0x00067374 File Offset: 0x00065574
		public override void Start()
		{
			base.Start();
			this.entityPlayer_0 = this.bhvtaskManager_0.m_entity as EntityPlayer;
			this.entityPlayer_0.OnSecondWindRevive(this.bhvtaskParamPlayerRevive_0.bool_1);
			if (this.entityPlayer_0.vmethod_26() && MonoSingleton<InputManager>.Instance)
			{
				MonoSingleton<InputManager>.Instance.method_2(true);
				if (MonoSingleton<GraphicsMgr>.Instance != null && MonoSingleton<GraphicsMgr>.Instance.method_18() != null)
				{
					MonoSingleton<GraphicsMgr>.Instance.method_18().method_6(false);
				}
			}
			UIMapDataManager.smethod_0().OnPlayerRevive(this.entityPlayer_0);
			this.entityPlayer_0.OnPlayerRespawn();
			base.m_Status = BHVTaskStatus.RUNNING;
			PlayerAnimationManagerFSM playerAnimationManagerFSM = this.bhvtaskManager_0.m_animationManagerFSM as PlayerAnimationManagerFSM;
			if (playerAnimationManagerFSM != null)
			{
				playerAnimationManagerFSM.method_22(PlayerAnimationManagerFSM.ESecondWindMode.Disabled);
			}
		}

		// Token: 0x06000BA1 RID: 2977 RVA: 0x00008E2F File Offset: 0x0000702F
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
		}

		// Token: 0x04000A84 RID: 2692
		private BHVTaskParamPlayerRevive bhvtaskParamPlayerRevive_0;

		// Token: 0x04000A85 RID: 2693
		private EntityPlayer entityPlayer_0;
	}
}
