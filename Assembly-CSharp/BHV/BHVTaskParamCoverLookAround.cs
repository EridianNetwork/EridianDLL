using System;

namespace BHV
{
	// Token: 0x02000227 RID: 551
	public sealed class BHVTaskParamCoverLookAround : BHVTaskParamAnimationState
	{
		// Token: 0x06000B67 RID: 2919 RVA: 0x0000B2CC File Offset: 0x000094CC
		public BHVTaskParamCoverLookAround()
		{
			base.m_Type = BHVTaskType.CoverLookAround;
			this.coverHeight_0 = CoverSlot.CoverHeight.INVALID;
			this.float_0 = 0f;
		}

		// Token: 0x06000B68 RID: 2920 RVA: 0x00066648 File Offset: 0x00064848
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.coverHeight_0 = this.coverHeight_0;
				data_0.float_0 = this.float_0;
			}
			else
			{
				this.coverHeight_0 = data_0.coverHeight_0;
				this.float_0 = data_0.float_0;
			}
		}

		// Token: 0x04000A58 RID: 2648
		public CoverSlot.CoverHeight coverHeight_0;

		// Token: 0x04000A59 RID: 2649
		public float float_0;
	}
}
