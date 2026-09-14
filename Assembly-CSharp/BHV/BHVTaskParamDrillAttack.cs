using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001BE RID: 446
	public sealed class BHVTaskParamDrillAttack : BHVTaskParam
	{
		// Token: 0x0600099D RID: 2461 RVA: 0x00009A25 File Offset: 0x00007C25
		public BHVTaskParamDrillAttack()
		{
			base.m_Type = BHVTaskType.DrillAttack;
			this.gameObject_0 = null;
			this.int_3 = -1;
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x00009A43 File Offset: 0x00007C43
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x00009A56 File Offset: 0x00007C56
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x00009A69 File Offset: 0x00007C69
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_2 = this.int_3;
			}
			else
			{
				this.int_3 = data_0.int_2;
			}
		}

		// Token: 0x040008AC RID: 2220
		public GameObject gameObject_0;

		// Token: 0x040008AD RID: 2221
		private int int_3;
	}
}
