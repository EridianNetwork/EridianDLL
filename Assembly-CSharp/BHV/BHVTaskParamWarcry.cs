using System;

namespace BHV
{
	// Token: 0x0200021A RID: 538
	public sealed class BHVTaskParamWarcry : BHVTaskParamAnimationState
	{
		// Token: 0x06000B34 RID: 2868 RVA: 0x0000AFED File Offset: 0x000091ED
		public BHVTaskParamWarcry()
		{
			base.m_Type = BHVTaskType.Warcry;
			this.bool_1 = false;
			this.int_3 = 0;
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x00065958 File Offset: 0x00063B58
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_2)
		{
			base.vmethod_2(ref data_0, bool_2);
			if (bool_2)
			{
				data_0.bool_1 = this.bool_1;
				data_0.int_1 = this.int_3;
			}
			else
			{
				this.bool_1 = data_0.bool_1;
				this.int_3 = data_0.int_1;
			}
		}

		// Token: 0x04000A26 RID: 2598
		public bool bool_1;

		// Token: 0x04000A27 RID: 2599
		public int int_3;
	}
}
