using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001EE RID: 494
	public sealed class BHVTaskParamMeleeAttack : BHVTaskParam
	{
		// Token: 0x06000A7A RID: 2682 RVA: 0x0000A5E8 File Offset: 0x000087E8
		public BHVTaskParamMeleeAttack()
		{
			base.m_Type = BHVTaskType.MeleeAttack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
			this.gameObject_0 = null;
			this.int_3 = -1;
			this.float_0 = -1f;
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x0000A618 File Offset: 0x00008818
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x0000A62B File Offset: 0x0000882B
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x000630C8 File Offset: 0x000612C8
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_2 = this.int_3;
				data_0.vector3_0.x = this.float_0;
			}
			else
			{
				this.int_3 = data_0.int_2;
				this.float_0 = data_0.vector3_0.x;
			}
		}

		// Token: 0x04000991 RID: 2449
		public GameObject gameObject_0;

		// Token: 0x04000992 RID: 2450
		public float float_0;

		// Token: 0x04000993 RID: 2451
		private int int_3;
	}
}
