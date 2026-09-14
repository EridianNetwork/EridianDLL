using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000194 RID: 404
	public sealed class BHVTaskParamSlideMoveTo : BHVTaskParam
	{
		// Token: 0x06000902 RID: 2306 RVA: 0x0000904B File Offset: 0x0000724B
		public BHVTaskParamSlideMoveTo()
		{
			base.m_Type = BHVTaskType.SlideMoveTo;
			this.vector3_0 = Vector3.zero;
			this.gameObject_0 = null;
			this.float_0 = 0f;
			this.bool_1 = false;
			this.int_3 = -1;
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x00009085 File Offset: 0x00007285
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x00009098 File Offset: 0x00007298
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x0005D240 File Offset: 0x0005B440
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

		// Token: 0x0400084D RID: 2125
		public Vector3 vector3_0;

		// Token: 0x0400084E RID: 2126
		public GameObject gameObject_0;

		// Token: 0x0400084F RID: 2127
		public float float_0;

		// Token: 0x04000850 RID: 2128
		public float float_1;

		// Token: 0x04000851 RID: 2129
		public bool bool_1;

		// Token: 0x04000852 RID: 2130
		private int int_3;
	}
}
