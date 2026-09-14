using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001FD RID: 509
	public sealed class BHVTaskParamRailgunAttack : BHVTaskParam
	{
		// Token: 0x06000ABB RID: 2747 RVA: 0x00064014 File Offset: 0x00062214
		public BHVTaskParamRailgunAttack()
		{
			base.m_Type = BHVTaskType.RailgunAttack;
			this.gameObject_0 = null;
			this.float_0 = 0.2f;
			this.float_1 = 20f;
			this.float_2 = 1.5f;
			this.float_3 = 2f;
			this.int_3 = -1;
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x0000A99E File Offset: 0x00008B9E
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x0000A9B1 File Offset: 0x00008BB1
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x0006406C File Offset: 0x0006226C
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_2 = this.int_3;
				data_0.float_0 = this.float_0;
				data_0.vector3_0.x = this.float_1;
				data_0.vector3_0.y = this.float_2;
				data_0.vector3_0.z = this.float_3;
			}
			else
			{
				this.int_3 = data_0.int_2;
				this.float_0 = data_0.float_0;
				this.float_1 = data_0.vector3_0.x;
				this.float_2 = data_0.vector3_0.y;
				this.float_3 = data_0.vector3_0.z;
			}
		}

		// Token: 0x040009C9 RID: 2505
		public GameObject gameObject_0;

		// Token: 0x040009CA RID: 2506
		public float float_0;

		// Token: 0x040009CB RID: 2507
		public float float_1;

		// Token: 0x040009CC RID: 2508
		public float float_2;

		// Token: 0x040009CD RID: 2509
		public float float_3;

		// Token: 0x040009CE RID: 2510
		private int int_3;
	}
}
