using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001DA RID: 474
	public sealed class BHVTaskParamIceMeteorAttack : BHVTaskParam
	{
		// Token: 0x06000A2B RID: 2603 RVA: 0x0000A12F File Offset: 0x0000832F
		public BHVTaskParamIceMeteorAttack()
		{
			base.m_Type = BHVTaskType.IceMeteorAttack;
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x0000A13F File Offset: 0x0000833F
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_5);
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x0000A152 File Offset: 0x00008352
		public override void vmethod_1()
		{
			this.int_5 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x00062028 File Offset: 0x00060228
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_2 = this.int_5;
				data_0.int_3 = (int)this.eattackMode_0;
				data_0.int_1 = this.int_4;
				data_0.float_0 = this.float_1;
			}
			else
			{
				this.int_5 = data_0.int_2;
				this.eattackMode_0 = (BHVTaskParamIceMeteorAttack.EAttackMode)data_0.int_3;
				this.int_4 = data_0.int_1;
				this.float_1 = data_0.float_0;
			}
		}

		// Token: 0x04000957 RID: 2391
		public int int_3;

		// Token: 0x04000958 RID: 2392
		public int int_4;

		// Token: 0x04000959 RID: 2393
		public float float_0;

		// Token: 0x0400095A RID: 2394
		public float float_1;

		// Token: 0x0400095B RID: 2395
		public BHVTaskParamIceMeteorAttack.EAttackMode eattackMode_0;

		// Token: 0x0400095C RID: 2396
		public GameObject gameObject_0;

		// Token: 0x0400095D RID: 2397
		private int int_5;

		// Token: 0x020001DB RID: 475
		public enum EAttackMode
		{
			// Token: 0x0400095F RID: 2399
			const_0,
			// Token: 0x04000960 RID: 2400
			const_1
		}
	}
}
