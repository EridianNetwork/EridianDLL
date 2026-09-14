using System;

namespace BHV
{
	// Token: 0x0200022B RID: 555
	public sealed class BHVTaskParamCoverPeakOut : BHVTaskParamAnimationState
	{
		// Token: 0x06000B74 RID: 2932 RVA: 0x0000B3D8 File Offset: 0x000095D8
		public BHVTaskParamCoverPeakOut()
		{
			base.m_Type = BHVTaskType.CoverPeakOut;
			this.coverHeight_0 = CoverSlot.CoverHeight.INVALID;
		}

		// Token: 0x06000B75 RID: 2933 RVA: 0x0000B3EF File Offset: 0x000095EF
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.coverHeight_0 = this.coverHeight_0;
			}
			else
			{
				this.coverHeight_0 = data_0.coverHeight_0;
			}
		}

		// Token: 0x04000A5E RID: 2654
		public CoverSlot.CoverHeight coverHeight_0;
	}
}
