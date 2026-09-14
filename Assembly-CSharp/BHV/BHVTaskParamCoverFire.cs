using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200021E RID: 542
	public sealed class BHVTaskParamCoverFire : BHVTaskParam
	{
		// Token: 0x06000B45 RID: 2885 RVA: 0x00065B90 File Offset: 0x00063D90
		public BHVTaskParamCoverFire()
		{
			base.m_Type = BHVTaskType.CoverFire;
			base.m_Layer = BHVTaskLayer.TOPBODY;
			this.bhvfireStyle_0 = BHVFireStyle.INVALID;
			this.coverHeight_0 = CoverSlot.CoverHeight.INVALID;
			this.int_3 = 1;
			this.gameObject_0 = null;
			this.vector3_0 = Vector3.zero;
			this.vector3_0.smethod_0();
			this.int_4 = -1;
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x0000B0CC File Offset: 0x000092CC
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_4);
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x0000B0DF File Offset: 0x000092DF
		public override void vmethod_1()
		{
			this.int_4 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x00065BEC File Offset: 0x00063DEC
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.coverHeight_0 = this.coverHeight_0;
				data_0.bhvfireStyle_0 = this.bhvfireStyle_0;
				data_0.int_1 = this.int_3;
				data_0.int_2 = this.int_4;
				data_0.vector3_0 = this.vector3_0;
			}
			else
			{
				this.coverHeight_0 = data_0.coverHeight_0;
				this.bhvfireStyle_0 = data_0.bhvfireStyle_0;
				this.int_3 = data_0.int_1;
				this.int_4 = data_0.int_2;
				this.vector3_0 = data_0.vector3_0;
			}
		}

		// Token: 0x04000A2F RID: 2607
		public BHVFireStyle bhvfireStyle_0;

		// Token: 0x04000A30 RID: 2608
		public int int_3;

		// Token: 0x04000A31 RID: 2609
		public CoverSlot.CoverHeight coverHeight_0;

		// Token: 0x04000A32 RID: 2610
		public GameObject gameObject_0;

		// Token: 0x04000A33 RID: 2611
		private int int_4;

		// Token: 0x04000A34 RID: 2612
		public Vector3 vector3_0;
	}
}
