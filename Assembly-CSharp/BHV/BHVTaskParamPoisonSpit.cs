using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001F9 RID: 505
	public sealed class BHVTaskParamPoisonSpit : BHVTaskParam
	{
		// Token: 0x06000AA9 RID: 2729 RVA: 0x0000A857 File Offset: 0x00008A57
		public BHVTaskParamPoisonSpit()
		{
			base.m_Type = BHVTaskType.PoisonSpit;
			this.int_4 = -1;
		}

		// Token: 0x06000AAA RID: 2730 RVA: 0x0000A88C File Offset: 0x00008A8C
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_4);
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x0000A89F File Offset: 0x00008A9F
		public override void vmethod_1()
		{
			this.int_4 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000AAC RID: 2732 RVA: 0x00063D5C File Offset: 0x00061F5C
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.vector3_0.x = this.float_1;
				data_0.vector3_0.y = this.float_0;
				data_0.int_4 = this.int_3;
				data_0.int_3 = this.int_4;
			}
			else
			{
				this.float_1 = data_0.vector3_0.x;
				this.float_0 = data_0.vector3_0.y;
				this.int_3 = data_0.int_4;
				this.int_4 = data_0.int_3;
			}
		}

		// Token: 0x040009BD RID: 2493
		public float float_0 = 90f;

		// Token: 0x040009BE RID: 2494
		public float float_1 = 5f;

		// Token: 0x040009BF RID: 2495
		public int int_3 = 20;

		// Token: 0x040009C0 RID: 2496
		public GameObject gameObject_0;

		// Token: 0x040009C1 RID: 2497
		private int int_4;
	}
}
