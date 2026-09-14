using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000172 RID: 370
	public sealed class BHVTaskParamAimingTarget : BHVTaskParam
	{
		// Token: 0x06000875 RID: 2165 RVA: 0x000087B3 File Offset: 0x000069B3
		public BHVTaskParamAimingTarget()
		{
			base.m_Type = BHVTaskType.AimingTarget;
			base.m_Layer = BHVTaskLayer.ADDITIVE;
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x000087CA File Offset: 0x000069CA
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x000087DD File Offset: 0x000069DD
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x000087F0 File Offset: 0x000069F0
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

		// Token: 0x040007FC RID: 2044
		public GameObject gameObject_0;

		// Token: 0x040007FD RID: 2045
		private int int_3;
	}
}
