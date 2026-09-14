using System;

namespace BHV
{
	// Token: 0x020001B4 RID: 436
	public sealed class BHVTaskParamCrystalEnergyBlast : BHVTaskParam
	{
		// Token: 0x06000972 RID: 2418 RVA: 0x0000976B File Offset: 0x0000796B
		public BHVTaskParamCrystalEnergyBlast()
		{
			base.m_Type = BHVTaskType.CrystalEnergyBlast;
			this.float_0 = 1f;
			this.float_1 = 3f;
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x0005DED4 File Offset: 0x0005C0D4
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

		// Token: 0x04000893 RID: 2195
		public float float_0;

		// Token: 0x04000894 RID: 2196
		public float float_1;
	}
}
