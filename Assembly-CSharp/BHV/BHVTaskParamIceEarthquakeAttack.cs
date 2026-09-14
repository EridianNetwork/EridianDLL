using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001D8 RID: 472
	public sealed class BHVTaskParamIceEarthquakeAttack : BHVTaskParam
	{
		// Token: 0x06000A1F RID: 2591 RVA: 0x00061B68 File Offset: 0x0005FD68
		public BHVTaskParamIceEarthquakeAttack()
		{
			base.m_Type = BHVTaskType.IceEarthquakeAttack;
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x0000A0DC File Offset: 0x000082DC
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_6);
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x0000A0EF File Offset: 0x000082EF
		public override void vmethod_1()
		{
			this.int_6 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x00061BBC File Offset: 0x0005FDBC
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_2 = this.int_6;
				data_0.int_1 = this.int_3;
				data_0.int_3 = this.int_5;
				data_0.vector3_0.x = this.float_1;
				data_0.vector3_0.y = this.float_2;
			}
			else
			{
				this.int_6 = data_0.int_2;
				this.int_3 = data_0.int_1;
				this.int_5 = data_0.int_3;
				this.float_1 = data_0.vector3_0.x;
				this.float_2 = data_0.vector3_0.y;
			}
		}

		// Token: 0x04000948 RID: 2376
		public int int_3 = 10;

		// Token: 0x04000949 RID: 2377
		public int int_4 = 30;

		// Token: 0x0400094A RID: 2378
		public int int_5 = 5;

		// Token: 0x0400094B RID: 2379
		public float float_0 = 1.5f;

		// Token: 0x0400094C RID: 2380
		public float float_1 = 0.5f;

		// Token: 0x0400094D RID: 2381
		public float float_2 = 1.5f;

		// Token: 0x0400094E RID: 2382
		public GameObject gameObject_0;

		// Token: 0x0400094F RID: 2383
		private int int_6;
	}
}
