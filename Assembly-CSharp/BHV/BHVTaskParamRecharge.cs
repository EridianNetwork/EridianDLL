using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200018E RID: 398
	public sealed class BHVTaskParamRecharge : BHVTaskParam
	{
		// Token: 0x060008E8 RID: 2280 RVA: 0x00008E38 File Offset: 0x00007038
		public BHVTaskParamRecharge()
		{
			base.m_Type = BHVTaskType.Recharge;
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x00008E48 File Offset: 0x00007048
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x00008E5B File Offset: 0x0000705B
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x00008E6E File Offset: 0x0000706E
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

		// Token: 0x04000844 RID: 2116
		public GameObject gameObject_0;

		// Token: 0x04000845 RID: 2117
		private int int_3;
	}
}
