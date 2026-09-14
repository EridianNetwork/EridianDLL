using System;

namespace BHV
{
	// Token: 0x02000210 RID: 528
	public sealed class BHVTaskParamSuicide : BHVTaskParam
	{
		// Token: 0x06000B08 RID: 2824 RVA: 0x0000ADDC File Offset: 0x00008FDC
		public BHVTaskParamSuicide()
		{
			base.m_Type = BHVTaskType.Suicide;
			this.float_0 = 2f;
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x0000ADF7 File Offset: 0x00008FF7
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.float_0 = this.float_0;
			}
			else
			{
				this.float_0 = data_0.float_0;
			}
		}

		// Token: 0x040009FC RID: 2556
		public float float_0;
	}
}
