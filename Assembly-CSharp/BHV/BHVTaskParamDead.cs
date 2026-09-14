using System;

namespace BHV
{
	// Token: 0x02000179 RID: 377
	public sealed class BHVTaskParamDead : BHVTaskParam
	{
		// Token: 0x0600088E RID: 2190 RVA: 0x00008994 File Offset: 0x00006B94
		public BHVTaskParamDead()
		{
			base.m_Type = BHVTaskType.Dead;
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x000089AE File Offset: 0x00006BAE
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

		// Token: 0x04000808 RID: 2056
		public float float_0 = 1f;
	}
}
