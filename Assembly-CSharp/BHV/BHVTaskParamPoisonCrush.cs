using System;

namespace BHV
{
	// Token: 0x020001F5 RID: 501
	public sealed class BHVTaskParamPoisonCrush : BHVTaskParam
	{
		// Token: 0x06000A99 RID: 2713 RVA: 0x0000A76A File Offset: 0x0000896A
		public BHVTaskParamPoisonCrush()
		{
			base.m_Type = BHVTaskType.PoisonCrush;
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x00063A40 File Offset: 0x00061C40
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.vector3_0.x = this.float_0;
				data_0.int_4 = this.int_3;
			}
			else
			{
				this.float_0 = data_0.vector3_0.x;
				this.int_3 = data_0.int_4;
			}
		}

		// Token: 0x040009B4 RID: 2484
		public float float_0 = 5f;

		// Token: 0x040009B5 RID: 2485
		public int int_3 = 20;
	}
}
