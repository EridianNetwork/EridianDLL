using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001D0 RID: 464
	public sealed class BHVTaskParamFlyMeleeAttack : BHVTaskParam
	{
		// Token: 0x060009F4 RID: 2548 RVA: 0x00009E83 File Offset: 0x00008083
		public BHVTaskParamFlyMeleeAttack()
		{
			base.m_Type = BHVTaskType.FlyMeleeAttack;
			this.gameObject_0 = null;
			this.bool_1 = false;
			this.int_3 = -1;
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x00009EA8 File Offset: 0x000080A8
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x00009EBB File Offset: 0x000080BB
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x00060F6C File Offset: 0x0005F16C
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_2)
		{
			base.vmethod_2(ref data_0, bool_2);
			if (bool_2)
			{
				data_0.int_2 = this.int_3;
				data_0.bool_1 = this.bool_1;
			}
			else
			{
				this.int_3 = data_0.int_2;
				this.bool_1 = data_0.bool_1;
			}
		}

		// Token: 0x04000922 RID: 2338
		public GameObject gameObject_0;

		// Token: 0x04000923 RID: 2339
		public bool bool_1;

		// Token: 0x04000924 RID: 2340
		private int int_3;
	}
}
