using System;

namespace BHV
{
	// Token: 0x020001D7 RID: 471
	public class BHVTaskHurt : BHVTaskAnimationState
	{
		// Token: 0x06000A1A RID: 2586 RVA: 0x0000A0A4 File Offset: 0x000082A4
		public BHVTaskHurt()
		{
			base.m_Type = BHVTaskType.Hurt;
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x0000A0B4 File Offset: 0x000082B4
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamHurt_0 = bhvtaskParam_0 as BHVTaskParamHurt;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x0000A0C9 File Offset: 0x000082C9
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamHurt_0;
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x00061AF4 File Offset: 0x0005FCF4
		public override void Start()
		{
			base.Start();
			if (this.animationHurtState_0 == null)
			{
				this.animationHurtState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16(Utils.smethod_23(AnimationStateFSM.Hurt)) as AnimationHurtState;
			}
			if (this.animationHurtState_0 != null)
			{
				this.animationHurtState_0.m_damageType = this.bhvtaskParamHurt_0.edamageType_0;
				this.animationHurtState_0.m_heavyHurtAnimIndex = this.bhvtaskParamHurt_0.int_3;
			}
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x0000A0D1 File Offset: 0x000082D1
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.Hurt);
		}

		// Token: 0x04000946 RID: 2374
		private BHVTaskParamHurt bhvtaskParamHurt_0;

		// Token: 0x04000947 RID: 2375
		private AnimationHurtState animationHurtState_0;
	}
}
