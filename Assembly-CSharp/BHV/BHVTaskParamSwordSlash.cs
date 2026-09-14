using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000213 RID: 531
	public sealed class BHVTaskParamSwordSlash : BHVTaskParam
	{
		// Token: 0x06000B11 RID: 2833 RVA: 0x0000AE72 File Offset: 0x00009072
		public BHVTaskParamSwordSlash()
		{
			base.m_Type = BHVTaskType.SwordSlash;
			this.gameObject_0 = null;
			this.int_5 = -1;
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x0000AE98 File Offset: 0x00009098
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_5);
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x0000AEAB File Offset: 0x000090AB
		public override void vmethod_1()
		{
			this.int_5 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x00064F84 File Offset: 0x00063184
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_2 = this.int_5;
				data_0.int_1 = this.int_3;
				data_0.int_4 = this.int_4;
			}
			else
			{
				this.int_5 = data_0.int_2;
				this.int_3 = data_0.int_1;
				this.int_4 = data_0.int_4;
			}
		}

		// Token: 0x04000A07 RID: 2567
		public GameObject gameObject_0;

		// Token: 0x04000A08 RID: 2568
		public int int_3;

		// Token: 0x04000A09 RID: 2569
		public int int_4 = 10;

		// Token: 0x04000A0A RID: 2570
		private int int_5;
	}
}
