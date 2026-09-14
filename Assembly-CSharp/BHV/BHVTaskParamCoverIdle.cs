using System;

namespace BHV
{
	// Token: 0x02000224 RID: 548
	public sealed class BHVTaskParamCoverIdle : BHVTaskParam
	{
		// Token: 0x06000B5F RID: 2911 RVA: 0x0000B267 File Offset: 0x00009467
		public BHVTaskParamCoverIdle()
		{
			base.m_Type = BHVTaskType.CoverIdle;
			this.coverHeight_0 = CoverSlot.CoverHeight.INVALID;
			this.float_0 = -1f;
		}

		// Token: 0x06000B60 RID: 2912 RVA: 0x00066500 File Offset: 0x00064700
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

		// Token: 0x04000A4F RID: 2639
		public CoverSlot.CoverHeight coverHeight_0;

		// Token: 0x04000A50 RID: 2640
		public float float_0;
	}
}
