using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000185 RID: 389
	public sealed class BHVTaskParamHoverPatrol : BHVTaskParam
	{
		// Token: 0x060008BC RID: 2236 RVA: 0x00008C2E File Offset: 0x00006E2E
		public BHVTaskParamHoverPatrol()
		{
			base.m_Type = BHVTaskType.HoverPatrol;
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x00008C3E File Offset: 0x00006E3E
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

		// Token: 0x04000822 RID: 2082
		public Vector3 vector3_0;
	}
}
