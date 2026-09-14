using System;

namespace BHV
{
	// Token: 0x02000174 RID: 372
	public class BHVTaskParamAnimationState : BHVTaskParam
	{
		// Token: 0x0600087E RID: 2174 RVA: 0x00008856 File Offset: 0x00006A56
		public BHVTaskParamAnimationState()
		{
			base.m_Type = BHVTaskType.PlayAnimation;
			this.animationStateFSM_0 = AnimationStateFSM.Invalid;
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x0000886D File Offset: 0x00006A6D
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (base.m_Type == BHVTaskType.PlayAnimation)
			{
				if (bool_1)
				{
					data_0.animationStateFSM_0 = this.animationStateFSM_0;
				}
				else
				{
					this.animationStateFSM_0 = data_0.animationStateFSM_0;
				}
			}
		}

		// Token: 0x040007FF RID: 2047
		public AnimationStateFSM animationStateFSM_0;
	}
}
