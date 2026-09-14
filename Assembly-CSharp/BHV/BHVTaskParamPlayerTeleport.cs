using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001F3 RID: 499
	public sealed class BHVTaskParamPlayerTeleport : BHVTaskParam
	{
		// Token: 0x06000A8E RID: 2702 RVA: 0x0000A6C9 File Offset: 0x000088C9
		public BHVTaskParamPlayerTeleport()
		{
			base.m_Type = BHVTaskType.PlayerTeleport;
			this.int_3 = -1;
		}

		// Token: 0x06000A8F RID: 2703 RVA: 0x0000A701 File Offset: 0x00008901
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x0000A714 File Offset: 0x00008914
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x000635F0 File Offset: 0x000617F0
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_2 = this.int_3;
				data_0.vector3_0.x = this.float_0;
				data_0.vector3_0.y = this.float_1;
				data_0.vector3_0.z = this.float_2;
			}
			else
			{
				this.int_3 = data_0.int_2;
				this.float_0 = data_0.vector3_0.x;
				this.float_1 = data_0.vector3_0.y;
				this.float_2 = data_0.vector3_0.z;
			}
		}

		// Token: 0x040009A6 RID: 2470
		public GameObject gameObject_0;

		// Token: 0x040009A7 RID: 2471
		public float float_0 = 5f;

		// Token: 0x040009A8 RID: 2472
		public float float_1 = 4f;

		// Token: 0x040009A9 RID: 2473
		public float float_2 = 0.5f;

		// Token: 0x040009AA RID: 2474
		private int int_3;
	}
}
