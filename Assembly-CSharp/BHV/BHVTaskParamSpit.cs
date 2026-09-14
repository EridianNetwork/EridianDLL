using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200020C RID: 524
	public sealed class BHVTaskParamSpit : BHVTaskParam
	{
		// Token: 0x06000AF6 RID: 2806 RVA: 0x0000ACE3 File Offset: 0x00008EE3
		public BHVTaskParamSpit()
		{
			base.m_Type = BHVTaskType.Spit;
			this.int_3 = 0;
			this.gameObject_0 = null;
			this.int_4 = -1;
			this.vector3_0 = Vector3.zero;
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x0000AD13 File Offset: 0x00008F13
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_4);
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x0000AD26 File Offset: 0x00008F26
		public override void vmethod_1()
		{
			this.int_4 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x0006492C File Offset: 0x00062B2C
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_1 = this.int_3;
				data_0.int_2 = this.int_4;
				data_0.vector3_0 = this.vector3_0;
			}
			else
			{
				this.int_3 = data_0.int_1;
				this.int_4 = data_0.int_2;
				this.vector3_0 = data_0.vector3_0;
			}
		}

		// Token: 0x040009F1 RID: 2545
		public int int_3;

		// Token: 0x040009F2 RID: 2546
		public GameObject gameObject_0;

		// Token: 0x040009F3 RID: 2547
		public Vector3 vector3_0;

		// Token: 0x040009F4 RID: 2548
		private int int_4;
	}
}
