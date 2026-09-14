using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200019D RID: 413
	public sealed class BHVTaskParamTurnTo : BHVTaskParam
	{
		// Token: 0x06000924 RID: 2340 RVA: 0x0000929B File Offset: 0x0000749B
		public BHVTaskParamTurnTo()
		{
			base.m_Type = BHVTaskType.TurnTo;
			base.m_Layer = BHVTaskLayer.FULLBODY;
			this.gameObject_0 = null;
			this.int_3 = -1;
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x000092BF File Offset: 0x000074BF
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x000092D2 File Offset: 0x000074D2
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x0005D500 File Offset: 0x0005B700
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_2 = this.int_3;
				data_0.vector3_0 = this.vector3_0;
			}
			else
			{
				this.int_3 = data_0.int_2;
				this.vector3_0 = data_0.vector3_0;
			}
		}

		// Token: 0x04000862 RID: 2146
		public GameObject gameObject_0;

		// Token: 0x04000863 RID: 2147
		public Vector3 vector3_0;

		// Token: 0x04000864 RID: 2148
		private int int_3;
	}
}
