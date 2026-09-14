using System;

namespace BHV
{
	// Token: 0x0200021B RID: 539
	public class BHVTaskWarcry : BHVTaskAnimationState
	{
		// Token: 0x06000B36 RID: 2870 RVA: 0x0000B00B File Offset: 0x0000920B
		public BHVTaskWarcry()
		{
			base.m_Type = BHVTaskType.Warcry;
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x0000B01B File Offset: 0x0000921B
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamWarcry_0 = bhvtaskParam_0 as BHVTaskParamWarcry;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x0000B030 File Offset: 0x00009230
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamWarcry_0;
		}

		// Token: 0x06000B39 RID: 2873 RVA: 0x000659A8 File Offset: 0x00063BA8
		public override void Start()
		{
			base.Start();
			this.animationWarcryState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16(Utils.smethod_23(AnimationStateFSM.Warcry)) as AnimationWarcryState;
			if (this.animationWarcryState_0 != null)
			{
				this.animationWarcryState_0.m_WarcryPhase = this.bhvtaskParamWarcry_0.int_3 - 1;
			}
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x0000B038 File Offset: 0x00009238
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.Warcry);
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x00065A00 File Offset: 0x00063C00
		private void method_1()
		{
			ZillaFuryEffect componentInChildren = this.bhvtaskManager_0.m_entity.GetComponentInChildren<ZillaFuryEffect>();
			if (componentInChildren != null)
			{
				componentInChildren.method_0();
			}
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x0000B043 File Offset: 0x00009243
		public override void vmethod_3(bool bool_1)
		{
			if (this.bhvtaskParamWarcry_0.bool_1)
			{
				this.method_1();
			}
		}

		// Token: 0x04000A28 RID: 2600
		private BHVTaskParamWarcry bhvtaskParamWarcry_0;

		// Token: 0x04000A29 RID: 2601
		private AnimationWarcryState animationWarcryState_0;
	}
}
