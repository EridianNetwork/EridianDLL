using System;

namespace BHV
{
	// Token: 0x020001B2 RID: 434
	public sealed class BHVTaskParamCrystalDeathStruggle : BHVTaskParam
	{
		// Token: 0x0600096A RID: 2410 RVA: 0x000096E1 File Offset: 0x000078E1
		public BHVTaskParamCrystalDeathStruggle()
		{
			base.m_Type = BHVTaskType.CrystalDeathStruggle;
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x0005DDB8 File Offset: 0x0005BFB8
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

		// Token: 0x0400088E RID: 2190
		public float float_0 = 1f;

		// Token: 0x0400088F RID: 2191
		public int int_3 = 30;
	}
}
