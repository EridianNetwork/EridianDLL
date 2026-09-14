using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001C6 RID: 454
	public sealed class BHVTaskParamEyeLaser : BHVTaskParam
	{
		// Token: 0x060009C2 RID: 2498 RVA: 0x0005F3A0 File Offset: 0x0005D5A0
		public BHVTaskParamEyeLaser()
		{
			base.m_Type = BHVTaskType.EyeLaser;
			this.gameObject_0 = null;
			this.int_4 = -1;
			this.float_0 = 0f;
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x00009C97 File Offset: 0x00007E97
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_4);
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x00009CAA File Offset: 0x00007EAA
		public override void vmethod_1()
		{
			this.int_4 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x0005F3F4 File Offset: 0x0005D5F4
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
				this.float_2 = data_0.vector3_0.z;
				this.int_3 = data_0.int_4;
			}
		}

		// Token: 0x040008D6 RID: 2262
		public GameObject gameObject_0;

		// Token: 0x040008D7 RID: 2263
		public float float_0;

		// Token: 0x040008D8 RID: 2264
		public float float_1 = 1f;

		// Token: 0x040008D9 RID: 2265
		public float float_2 = 1f;

		// Token: 0x040008DA RID: 2266
		public int int_3 = 1;

		// Token: 0x040008DB RID: 2267
		private int int_4;
	}
}
