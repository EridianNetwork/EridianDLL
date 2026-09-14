using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001C0 RID: 448
	public sealed class BHVTaskParamEarthPikeAttack : BHVTaskParam
	{
		// Token: 0x060009A7 RID: 2471 RVA: 0x00009B00 File Offset: 0x00007D00
		public BHVTaskParamEarthPikeAttack()
		{
			base.m_Type = BHVTaskType.EarthPikeAttack;
			this.int_3 = 0;
			this.int_4 = 0;
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x0005E8C8 File Offset: 0x0005CAC8
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_4 = this.int_3;
				data_0.int_1 = this.int_4;
				data_0.vector3_0 = this.vector3_0[0];
				data_0.vector3_1 = this.vector3_0[1];
				data_0.vector3_2 = this.vector3_0[2];
				data_0.vector3_3 = this.vector3_0[3];
			}
			else
			{
				this.int_3 = data_0.int_4;
				this.int_4 = data_0.int_1;
				this.vector3_0[0] = data_0.vector3_0;
				this.vector3_0[1] = data_0.vector3_1;
				this.vector3_0[2] = data_0.vector3_2;
				this.vector3_0[3] = data_0.vector3_3;
			}
		}

		// Token: 0x040008B4 RID: 2228
		public int int_3;

		// Token: 0x040008B5 RID: 2229
		public int int_4;

		// Token: 0x040008B6 RID: 2230
		public Vector3[] vector3_0 = new Vector3[4];
	}
}
