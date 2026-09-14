using System;

namespace BHV
{
	// Token: 0x02000200 RID: 512
	public class BHVTaskReload : BHVTaskAnimationState
	{
		// Token: 0x06000AC7 RID: 2759 RVA: 0x0000AA08 File Offset: 0x00008C08
		public BHVTaskReload()
		{
			base.m_Type = BHVTaskType.Reload;
			base.m_Layer = BHVTaskLayer.TOPBODY;
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x0000AA1F File Offset: 0x00008C1F
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamReload_0 = bhvtaskParam_0 as BHVTaskParamReload;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x0000AA34 File Offset: 0x00008C34
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamReload_0;
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x000643C8 File Offset: 0x000625C8
		public override void Update(float deltaTime)
		{
			BHVTaskAnimationState.State state_ = this.state_0;
			base.Update(deltaTime, AnimationStateFSM.Reload);
			if (state_ != BHVTaskAnimationState.State.const_1 || this.state_0 == BHVTaskAnimationState.State.const_2)
			{
			}
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x000643F4 File Offset: 0x000625F4
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
			AnimationReloadState animationReloadState = this.bhvtaskManager_0.m_animationManagerFSM.method_16(Utils.smethod_23(AnimationStateFSM.Reload)) as AnimationReloadState;
			if (animationReloadState != null)
			{
				animationReloadState.vmethod_2();
			}
		}

		// Token: 0x040009D3 RID: 2515
		private BHVTaskParamReload bhvtaskParamReload_0;
	}
}
