using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000209 RID: 521
	public sealed class BHVTaskParamSpacing : BHVTaskParam
	{
		// Token: 0x06000AEB RID: 2795 RVA: 0x0000AC59 File Offset: 0x00008E59
		public BHVTaskParamSpacing()
		{
			base.m_Type = BHVTaskType.Spacing;
			this.vector3_0 = Vector3.zero;
			this.gameObject_0 = null;
			this.bool_1 = false;
			this.int_3 = -1;
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x0000AC89 File Offset: 0x00008E89
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x0000AC9C File Offset: 0x00008E9C
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x00064764 File Offset: 0x00062964
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_2)
		{
			base.vmethod_2(ref data_0, bool_2);
			if (bool_2)
			{
				data_0.vector3_0 = this.vector3_0;
				data_0.int_2 = this.int_3;
				data_0.bool_1 = this.bool_1;
			}
			else
			{
				this.vector3_0 = data_0.vector3_0;
				this.int_3 = data_0.int_2;
				this.bool_1 = data_0.bool_1;
			}
		}

		// Token: 0x040009E4 RID: 2532
		public Vector3 vector3_0;

		// Token: 0x040009E5 RID: 2533
		public GameObject gameObject_0;

		// Token: 0x040009E6 RID: 2534
		public bool bool_1;

		// Token: 0x040009E7 RID: 2535
		private int int_3;
	}
}
