using System;

namespace BHV
{
	// Token: 0x02000240 RID: 576
	public class BHVTaskAttachBomb : BHVTaskAnimationState
	{
		// Token: 0x06000BBE RID: 3006 RVA: 0x0000B77E File Offset: 0x0000997E
		public BHVTaskAttachBomb()
		{
			base.m_Type = BHVTaskType.AttachBomb;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		// Token: 0x06000BBF RID: 3007 RVA: 0x0000B795 File Offset: 0x00009995
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamAttachBomb_0 = bhvtaskParam_0 as BHVTaskParamAttachBomb;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000BC0 RID: 3008 RVA: 0x0000B7AA File Offset: 0x000099AA
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamAttachBomb_0;
		}

		// Token: 0x06000BC1 RID: 3009 RVA: 0x0000B7B2 File Offset: 0x000099B2
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.AttachBomb);
		}

		// Token: 0x04000A8C RID: 2700
		private BHVTaskParamAttachBomb bhvtaskParamAttachBomb_0;
	}
}
