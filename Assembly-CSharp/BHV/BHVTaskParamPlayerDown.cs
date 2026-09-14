using System;

namespace BHV
{
	// Token: 0x02000233 RID: 563
	public sealed class BHVTaskParamPlayerDown : BHVTaskParam
	{
		// Token: 0x06000B92 RID: 2962 RVA: 0x0000B573 File Offset: 0x00009773
		public BHVTaskParamPlayerDown()
		{
			base.m_Type = BHVTaskType.PlayerDown;
			this.int_3 = 0;
		}

		// Token: 0x06000B93 RID: 2963 RVA: 0x00066F3C File Offset: 0x0006513C
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.float_0 = this.float_0;
				data_0.int_2 = this.int_3;
			}
			else
			{
				this.float_0 = data_0.float_0;
				this.int_3 = data_0.int_2;
			}
		}

		// Token: 0x04000A75 RID: 2677
		public float float_0 = 5f;

		// Token: 0x04000A76 RID: 2678
		public int int_3;
	}
}
