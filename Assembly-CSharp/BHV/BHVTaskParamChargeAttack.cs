using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001AB RID: 427
	public sealed class BHVTaskParamChargeAttack : BHVTaskParam
	{
		// Token: 0x06000954 RID: 2388 RVA: 0x0000955B File Offset: 0x0000775B
		public BHVTaskParamChargeAttack()
		{
			base.m_Type = BHVTaskType.ChargeAttack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
			this.vector3_0 = Vector3.zero;
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x0000957D File Offset: 0x0000777D
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

		// Token: 0x0400087F RID: 2175
		public Vector3 vector3_0;
	}
}
