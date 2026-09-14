using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001A8 RID: 424
	public sealed class BHVTaskParamBurrowAttack : BHVTaskParamAnimationState
	{
		// Token: 0x0600094C RID: 2380 RVA: 0x000094BD File Offset: 0x000076BD
		public BHVTaskParamBurrowAttack()
		{
			base.m_Type = BHVTaskType.BurrowAttack;
			this.float_0 = 2f;
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x0005DA2C File Offset: 0x0005BC2C
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.vector3_0.x = this.float_0;
				data_0.vector3_1 = this.vector3_0;
			}
			else
			{
				this.float_0 = data_0.vector3_0.x;
				this.vector3_0 = data_0.vector3_1;
			}
		}

		// Token: 0x04000875 RID: 2165
		public float float_0;

		// Token: 0x04000876 RID: 2166
		public Vector3 vector3_0;
	}
}
