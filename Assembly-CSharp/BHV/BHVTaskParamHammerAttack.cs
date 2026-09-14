using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001D2 RID: 466
	public sealed class BHVTaskParamHammerAttack : BHVTaskParam
	{
		// Token: 0x06000A03 RID: 2563 RVA: 0x00009F31 File Offset: 0x00008131
		public BHVTaskParamHammerAttack()
		{
			base.m_Type = BHVTaskType.HammerAttack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
			this.gameObject_0 = null;
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x00009F4F File Offset: 0x0000814F
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x00009F62 File Offset: 0x00008162
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x00009F75 File Offset: 0x00008175
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

		// Token: 0x04000933 RID: 2355
		public GameObject gameObject_0;

		// Token: 0x04000934 RID: 2356
		private int int_3;
	}
}
