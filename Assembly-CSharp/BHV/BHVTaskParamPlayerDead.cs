using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000231 RID: 561
	public sealed class BHVTaskParamPlayerDead : BHVTaskParam
	{
		// Token: 0x06000B88 RID: 2952 RVA: 0x00066A6C File Offset: 0x00064C6C
		public BHVTaskParamPlayerDead()
		{
			this.int_4 = 0;
			base.m_Type = BHVTaskType.PlayerDead;
			this.bool_1 = true;
			this.float_0 = 0f;
			this.vector3_0 = Vector3.zero;
			this.int_3 = 0;
			this.float_1 = -1f;
		}

		// Token: 0x06000B89 RID: 2953 RVA: 0x00066AC0 File Offset: 0x00064CC0
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_2)
		{
			base.vmethod_2(ref data_0, bool_2);
			if (bool_2)
			{
				data_0.int_2 = this.int_4;
				data_0.bool_1 = this.bool_1;
				data_0.int_1 = this.int_3;
				data_0.float_0 = this.float_0;
				data_0.vector3_0 = this.vector3_0;
				data_0.int_4 = (int)(this.float_1 * 1000f);
			}
			else
			{
				this.int_4 = data_0.int_2;
				this.bool_1 = data_0.bool_1;
				this.int_3 = data_0.int_1;
				this.float_0 = data_0.float_0;
				this.vector3_0 = data_0.vector3_0;
				this.float_1 = (float)data_0.int_4 / 1000f;
			}
		}

		// Token: 0x04000A6A RID: 2666
		public bool bool_1;

		// Token: 0x04000A6B RID: 2667
		public float float_0;

		// Token: 0x04000A6C RID: 2668
		public Vector3 vector3_0;

		// Token: 0x04000A6D RID: 2669
		public int int_3;

		// Token: 0x04000A6E RID: 2670
		public int int_4;

		// Token: 0x04000A6F RID: 2671
		public float float_1;
	}
}
