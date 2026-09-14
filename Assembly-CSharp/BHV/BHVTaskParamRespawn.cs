using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000190 RID: 400
	public sealed class BHVTaskParamRespawn : BHVTaskParam
	{
		// Token: 0x060008F2 RID: 2290 RVA: 0x00008EF5 File Offset: 0x000070F5
		public BHVTaskParamRespawn()
		{
			base.m_Type = BHVTaskType.Respawn;
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x00008F05 File Offset: 0x00007105
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

		// Token: 0x04000848 RID: 2120
		public Vector3 vector3_0;
	}
}
