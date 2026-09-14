using System;

namespace BHV
{
	// Token: 0x020001BC RID: 444
	public sealed class BHVTaskParamDestoryMissile : BHVTaskParam
	{
		// Token: 0x06000996 RID: 2454 RVA: 0x000099BD File Offset: 0x00007BBD
		public BHVTaskParamDestoryMissile()
		{
			base.m_Type = BHVTaskType.DestoryMissile;
			base.m_Layer = BHVTaskLayer.ADDITIVE;
			this.int_3 = 0;
			this.int_4 = 0;
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x0005E68C File Offset: 0x0005C88C
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_1 = this.int_3;
				data_0.int_4 = this.int_4;
			}
			else
			{
				this.int_3 = data_0.int_1;
				this.int_4 = data_0.int_4;
			}
		}

		// Token: 0x040008A9 RID: 2217
		public int int_3;

		// Token: 0x040008AA RID: 2218
		public int int_4;
	}
}
