using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001DF RID: 479
	public sealed class BHVTaskParamJetAttack : BHVTaskParam
	{
		// Token: 0x06000A3F RID: 2623 RVA: 0x0000A23C File Offset: 0x0000843C
		public BHVTaskParamJetAttack()
		{
			base.m_Type = BHVTaskType.JetAttack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
			this.float_0 = 10f;
		}

		// Token: 0x06000A40 RID: 2624 RVA: 0x0000A25E File Offset: 0x0000845E
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x06000A41 RID: 2625 RVA: 0x0000A271 File Offset: 0x00008471
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x00062740 File Offset: 0x00060940
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_2 = this.int_3;
				data_0.vector3_0.x = this.float_0;
				data_0.vector3_0.y = this.float_1;
				data_0.vector3_1 = this.vector3_0;
			}
			else
			{
				this.int_3 = data_0.int_2;
				this.float_0 = data_0.vector3_0.x;
				this.float_1 = data_0.vector3_0.y;
				this.vector3_0 = data_0.vector3_1;
			}
		}

		// Token: 0x0400096C RID: 2412
		public GameObject gameObject_0;

		// Token: 0x0400096D RID: 2413
		public float float_0;

		// Token: 0x0400096E RID: 2414
		public float float_1;

		// Token: 0x0400096F RID: 2415
		public Vector3 vector3_0;

		// Token: 0x04000970 RID: 2416
		private int int_3;
	}
}
