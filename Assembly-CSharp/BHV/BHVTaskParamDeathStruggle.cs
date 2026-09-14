using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001B8 RID: 440
	public sealed class BHVTaskParamDeathStruggle : BHVTaskParam
	{
		// Token: 0x06000984 RID: 2436 RVA: 0x00009877 File Offset: 0x00007A77
		public BHVTaskParamDeathStruggle()
		{
			base.m_Type = BHVTaskType.DeathStruggle;
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x00009887 File Offset: 0x00007A87
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.vector3_0 = this.vector3_0;
			}
			else
			{
				this.vector3_0 = data_0.vector3_0;
			}
		}

		// Token: 0x040008A1 RID: 2209
		public Vector3 vector3_0;
	}
}
