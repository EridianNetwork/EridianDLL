using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200017F RID: 383
	public sealed class BHVTaskParamDie : BHVTaskParamAnimationState
	{
		// Token: 0x060008A4 RID: 2212 RVA: 0x00008B0B File Offset: 0x00006D0B
		public BHVTaskParamDie()
		{
			base.m_Type = BHVTaskType.Die;
			this.bool_1 = true;
			this.float_0 = 0f;
			this.vector3_0 = Vector3.zero;
			this.int_3 = 0;
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x0005BE40 File Offset: 0x0005A040
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_2)
		{
			base.vmethod_2(ref data_0, bool_2);
			if (bool_2)
			{
				data_0.bool_1 = this.bool_1;
				data_0.int_1 = this.int_3;
				data_0.float_0 = this.float_0;
				data_0.vector3_0 = this.vector3_0;
			}
			else
			{
				this.bool_1 = data_0.bool_1;
				this.int_3 = data_0.int_1;
				this.float_0 = data_0.float_0;
				this.vector3_0 = data_0.vector3_0;
			}
		}

		// Token: 0x04000811 RID: 2065
		public bool bool_1;

		// Token: 0x04000812 RID: 2066
		public float float_0;

		// Token: 0x04000813 RID: 2067
		public Vector3 vector3_0;

		// Token: 0x04000814 RID: 2068
		public int int_3;
	}
}
