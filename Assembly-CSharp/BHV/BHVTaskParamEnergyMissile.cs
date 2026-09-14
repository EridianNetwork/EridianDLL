using System;

namespace BHV
{
	// Token: 0x020001C4 RID: 452
	public sealed class BHVTaskParamEnergyMissile : BHVTaskParam
	{
		// Token: 0x060009B9 RID: 2489 RVA: 0x00009C0C File Offset: 0x00007E0C
		public BHVTaskParamEnergyMissile()
		{
			base.m_Type = BHVTaskType.EnergyMissile;
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x0005F084 File Offset: 0x0005D284
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.vector3_0.x = this.float_0;
				data_0.vector3_0.y = this.float_1;
				data_0.int_4 = this.int_3;
				data_0.int_1 = this.int_4;
			}
			else
			{
				this.float_0 = data_0.vector3_0.x;
				this.float_1 = data_0.vector3_0.y;
				this.int_3 = data_0.int_4;
				this.int_4 = data_0.int_1;
			}
		}

		// Token: 0x040008C7 RID: 2247
		public float float_0;

		// Token: 0x040008C8 RID: 2248
		public float float_1;

		// Token: 0x040008C9 RID: 2249
		public int int_3;

		// Token: 0x040008CA RID: 2250
		public int int_4;
	}
}
