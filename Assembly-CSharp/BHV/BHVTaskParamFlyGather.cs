using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000183 RID: 387
	public sealed class BHVTaskParamFlyGather : BHVTaskParam
	{
		// Token: 0x060008B3 RID: 2227 RVA: 0x00008BB5 File Offset: 0x00006DB5
		public BHVTaskParamFlyGather()
		{
			base.m_Type = BHVTaskType.FlyGather;
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x00008BC5 File Offset: 0x00006DC5
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

		// Token: 0x0400081A RID: 2074
		public Vector3 vector3_0;
	}
}
