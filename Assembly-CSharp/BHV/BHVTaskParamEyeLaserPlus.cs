using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001C8 RID: 456
	public sealed class BHVTaskParamEyeLaserPlus : BHVTaskParam
	{
		// Token: 0x060009CC RID: 2508 RVA: 0x0005F760 File Offset: 0x0005D960
		public BHVTaskParamEyeLaserPlus()
		{
			base.m_Type = BHVTaskType.EyeLaserPlus;
			this.gameObject_0 = null;
			this.int_4 = -1;
			this.float_0 = 0f;
		}

		// Token: 0x060009CD RID: 2509 RVA: 0x00009D00 File Offset: 0x00007F00
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_4);
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x00009D13 File Offset: 0x00007F13
		public override void vmethod_1()
		{
			this.int_4 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x0005F7B4 File Offset: 0x0005D9B4
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_2 = this.int_4;
				data_0.vector3_0.x = this.float_0;
				data_0.vector3_0.y = this.float_1;
				data_0.vector3_0.z = this.float_2;
				data_0.int_4 = this.int_3;
			}
			else
			{
				this.int_4 = data_0.int_2;
				this.float_0 = data_0.vector3_0.x;
				this.float_1 = data_0.vector3_0.y;
				this.int_3 = data_0.int_4;
				this.float_2 = data_0.vector3_0.z;
			}
		}

		// Token: 0x040008E4 RID: 2276
		public GameObject gameObject_0;

		// Token: 0x040008E5 RID: 2277
		public float float_0;

		// Token: 0x040008E6 RID: 2278
		public float float_1 = 1f;

		// Token: 0x040008E7 RID: 2279
		public float float_2 = 10f;

		// Token: 0x040008E8 RID: 2280
		public int int_3 = 1;

		// Token: 0x040008E9 RID: 2281
		private int int_4;
	}
}
