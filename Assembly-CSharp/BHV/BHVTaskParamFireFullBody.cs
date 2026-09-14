using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001CD RID: 461
	public sealed class BHVTaskParamFireFullBody : BHVTaskParam
	{
		// Token: 0x060009E6 RID: 2534 RVA: 0x0006071C File Offset: 0x0005E91C
		public BHVTaskParamFireFullBody()
		{
			base.m_Type = BHVTaskType.FireFullBody;
			base.m_Layer = BHVTaskLayer.FULLBODY;
			this.bhvfireStyle_0 = BHVFireStyle.INVALID;
			this.int_3 = 1;
			this.gameObject_0 = null;
			this.vector3_0 = Vector3.zero;
			this.vector3_0.smethod_0();
			this.int_4 = -1;
			this.float_0 = 100f;
			this.bhvstance_0 = BHVStance.STAND;
			this.bool_1 = false;
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x0006078C File Offset: 0x0005E98C
		public BHVTaskParamFireFullBody(BHVTaskParamFire bhvtaskParamFire_0)
		{
			base.m_Type = BHVTaskType.FireFullBody;
			base.m_Layer = BHVTaskLayer.FULLBODY;
			this.bhvfireStyle_0 = bhvtaskParamFire_0.bhvfireStyle_0;
			this.int_3 = bhvtaskParamFire_0.int_3;
			this.gameObject_0 = bhvtaskParamFire_0.gameObject_0;
			this.vector3_0 = bhvtaskParamFire_0.vector3_0;
			this.int_4 = BHVTaskParam.smethod_1(bhvtaskParamFire_0.gameObject_0);
			this.float_0 = bhvtaskParamFire_0.float_0;
			this.bhvstance_0 = bhvtaskParamFire_0.bhvstance_0;
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x00009DE3 File Offset: 0x00007FE3
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_4);
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x00009DF6 File Offset: 0x00007FF6
		public override void vmethod_1()
		{
			this.int_4 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x00060808 File Offset: 0x0005EA08
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_2)
		{
			base.vmethod_2(ref data_0, bool_2);
			if (bool_2)
			{
				data_0.bhvfireStyle_0 = this.bhvfireStyle_0;
				data_0.int_1 = this.int_3;
				data_0.int_2 = this.int_4;
				data_0.vector3_0 = this.vector3_0;
				data_0.bhvstance_0 = this.bhvstance_0;
				data_0.vector3_0.x = this.float_0;
				data_0.bool_1 = this.bool_1;
			}
			else
			{
				this.bhvfireStyle_0 = data_0.bhvfireStyle_0;
				this.int_3 = data_0.int_1;
				this.int_4 = data_0.int_2;
				this.vector3_0 = data_0.vector3_0;
				this.bhvstance_0 = data_0.bhvstance_0;
				this.float_0 = data_0.vector3_0.x;
				this.bool_1 = data_0.bool_1;
			}
		}

		// Token: 0x0400090B RID: 2315
		public BHVFireStyle bhvfireStyle_0;

		// Token: 0x0400090C RID: 2316
		public int int_3;

		// Token: 0x0400090D RID: 2317
		public BHVStance bhvstance_0;

		// Token: 0x0400090E RID: 2318
		public GameObject gameObject_0;

		// Token: 0x0400090F RID: 2319
		public Vector3 vector3_0;

		// Token: 0x04000910 RID: 2320
		public float float_0;

		// Token: 0x04000911 RID: 2321
		private int int_4;

		// Token: 0x04000912 RID: 2322
		public bool bool_1;
	}
}
