using System;

namespace BHV
{
	// Token: 0x0200022D RID: 557
	public sealed class BHVTaskParamCoverReload : BHVTaskParamAnimationState
	{
		// Token: 0x06000B7A RID: 2938 RVA: 0x0000B450 File Offset: 0x00009650
		public BHVTaskParamCoverReload()
		{
			base.m_Type = BHVTaskType.CoverReload;
			this.coverHeight_0 = CoverSlot.CoverHeight.INVALID;
		}

		// Token: 0x06000B7B RID: 2939 RVA: 0x0000B467 File Offset: 0x00009667
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

		// Token: 0x04000A60 RID: 2656
		public CoverSlot.CoverHeight coverHeight_0;
	}
}
