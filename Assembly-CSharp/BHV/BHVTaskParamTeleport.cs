using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000215 RID: 533
	public sealed class BHVTaskParamTeleport : BHVTaskParam
	{
		// Token: 0x06000B1C RID: 2844 RVA: 0x0000AF31 File Offset: 0x00009131
		public BHVTaskParamTeleport()
		{
			base.m_Type = BHVTaskType.Teleport;
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x0006518C File Offset: 0x0006338C
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.vector3_0 = this.vector3_0;
				data_0.vector3_1 = this.vector3_1;
				data_0.vector3_2.x = this.float_0;
				data_0.vector3_2.y = this.float_1;
				data_0.vector3_2.z = this.float_2;
			}
			else
			{
				this.vector3_0 = data_0.vector3_0;
				this.vector3_1 = data_0.vector3_1;
				this.float_0 = data_0.vector3_2.x;
				this.float_1 = data_0.vector3_2.y;
				this.float_2 = data_0.vector3_2.z;
			}
		}

		// Token: 0x04000A0E RID: 2574
		public Vector3 vector3_0;

		// Token: 0x04000A0F RID: 2575
		public Vector3 vector3_1;

		// Token: 0x04000A10 RID: 2576
		public float float_0;

		// Token: 0x04000A11 RID: 2577
		public float float_1;

		// Token: 0x04000A12 RID: 2578
		public float float_2;
	}
}
