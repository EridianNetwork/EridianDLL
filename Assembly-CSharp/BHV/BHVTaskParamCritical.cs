using System;

namespace BHV
{
	// Token: 0x020001B0 RID: 432
	public sealed class BHVTaskParamCritical : BHVTaskParam
	{
		// Token: 0x06000962 RID: 2402 RVA: 0x00009679 File Offset: 0x00007879
		public BHVTaskParamCritical()
		{
			base.m_Type = BHVTaskType.Critical;
			this.float_0 = 1f;
			this.float_1 = 1f;
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x0005DC8C File Offset: 0x0005BE8C
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.vector3_0.x = this.float_0;
				data_0.vector3_0.y = this.float_1;
			}
			else
			{
				this.float_0 = data_0.vector3_0.x;
				this.float_1 = data_0.vector3_0.y;
			}
		}

		// Token: 0x04000888 RID: 2184
		public float float_0;

		// Token: 0x04000889 RID: 2185
		public float float_1;
	}
}
