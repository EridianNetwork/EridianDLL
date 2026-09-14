using System;

namespace BHV
{
	// Token: 0x020001ED RID: 493
	public class BHVTaskLightHurt : BHVTask
	{
		// Token: 0x06000A75 RID: 2677 RVA: 0x0000A59D File Offset: 0x0000879D
		public BHVTaskLightHurt()
		{
			base.m_Type = BHVTaskType.LightHurt;
			base.m_Layer = BHVTaskLayer.ADDITIVE;
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x0000A5B4 File Offset: 0x000087B4
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamLightHurt_0 = bhvtaskParam_0 as BHVTaskParamLightHurt;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x0000A5C9 File Offset: 0x000087C9
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamLightHurt_0;
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x0006305C File Offset: 0x0006125C
		public override void Start()
		{
			base.Start();
			this.animationLightHurtState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("LightHurt") as AnimationLightHurtState;
			if (this.animationLightHurtState_0 != null)
			{
				this.animationLightHurtState_0.m_damageType = this.bhvtaskParamLightHurt_0.edamageType_0;
			}
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.LightHurt);
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x0000A5D1 File Offset: 0x000087D1
		public override void Update(float deltaTime)
		{
			if (this.animationLightHurtState_0.m_status == AnimationStatus.SUCCESS)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
		}

		// Token: 0x0400098F RID: 2447
		private BHVTaskParamLightHurt bhvtaskParamLightHurt_0;

		// Token: 0x04000990 RID: 2448
		private AnimationLightHurtState animationLightHurtState_0;
	}
}
