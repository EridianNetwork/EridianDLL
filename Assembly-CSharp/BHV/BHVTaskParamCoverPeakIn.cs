using System;

namespace BHV
{
	// Token: 0x02000229 RID: 553
	public sealed class BHVTaskParamCoverPeakIn : BHVTaskParamAnimationState
	{
		// Token: 0x06000B6E RID: 2926 RVA: 0x0000B360 File Offset: 0x00009560
		public BHVTaskParamCoverPeakIn()
		{
			base.m_Type = BHVTaskType.CoverPeakIn;
			this.coverHeight_0 = CoverSlot.CoverHeight.INVALID;
		}

		// Token: 0x06000B6F RID: 2927 RVA: 0x0000B377 File Offset: 0x00009577
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

		// Token: 0x04000A5C RID: 2652
		public CoverSlot.CoverHeight coverHeight_0;
	}
}
