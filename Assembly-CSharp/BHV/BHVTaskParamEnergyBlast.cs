using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001C2 RID: 450
	public sealed class BHVTaskParamEnergyBlast : BHVTaskParam
	{
		// Token: 0x060009AF RID: 2479 RVA: 0x00009B57 File Offset: 0x00007D57
		public BHVTaskParamEnergyBlast()
		{
			base.m_Type = BHVTaskType.EnergyBlast;
			this.gameObject_0 = null;
			this.int_3 = -1;
			this.float_0 = 0f;
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x00009B8B File Offset: 0x00007D8B
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x00009B9E File Offset: 0x00007D9E
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x0005ED80 File Offset: 0x0005CF80
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_2 = this.int_3;
				data_0.vector3_0.x = this.float_0;
				data_0.vector3_0.y = this.float_1;
			}
			else
			{
				this.int_3 = data_0.int_2;
				this.float_0 = data_0.vector3_0.x;
				this.float_1 = data_0.vector3_0.y;
			}
		}

		// Token: 0x040008BF RID: 2239
		public GameObject gameObject_0;

		// Token: 0x040008C0 RID: 2240
		public float float_0;

		// Token: 0x040008C1 RID: 2241
		public float float_1 = 1f;

		// Token: 0x040008C2 RID: 2242
		private int int_3;
	}
}
