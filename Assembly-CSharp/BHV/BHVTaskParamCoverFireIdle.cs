using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000221 RID: 545
	public sealed class BHVTaskParamCoverFireIdle : BHVTaskParam
	{
		// Token: 0x06000B52 RID: 2898 RVA: 0x00066164 File Offset: 0x00064364
		public BHVTaskParamCoverFireIdle()
		{
			base.m_Type = BHVTaskType.CoverFireIdle;
			base.m_Layer = BHVTaskLayer.TOPBODY;
			this.coverHeight_0 = CoverSlot.CoverHeight.INVALID;
			this.float_0 = 0f;
			this.gameObject_0 = null;
			this.vector3_0 = Vector3.zero;
			this.vector3_0.smethod_0();
			this.int_3 = -1;
		}

		// Token: 0x06000B53 RID: 2899 RVA: 0x0000B18D File Offset: 0x0000938D
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x06000B54 RID: 2900 RVA: 0x0000B1A0 File Offset: 0x000093A0
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000B55 RID: 2901 RVA: 0x000661BC File Offset: 0x000643BC
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.float_0 = this.float_0;
				data_0.coverHeight_0 = this.coverHeight_0;
				data_0.int_2 = this.int_3;
				data_0.vector3_0 = this.vector3_0;
			}
			else
			{
				this.float_0 = data_0.float_0;
				this.coverHeight_0 = data_0.coverHeight_0;
				this.int_3 = data_0.int_2;
				this.vector3_0 = data_0.vector3_0;
			}
		}

		// Token: 0x04000A41 RID: 2625
		public CoverSlot.CoverHeight coverHeight_0;

		// Token: 0x04000A42 RID: 2626
		public GameObject gameObject_0;

		// Token: 0x04000A43 RID: 2627
		public float float_0;

		// Token: 0x04000A44 RID: 2628
		private int int_3;

		// Token: 0x04000A45 RID: 2629
		public Vector3 vector3_0;
	}
}
