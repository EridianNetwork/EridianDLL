using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200018C RID: 396
	public sealed class BHVTaskParamMoveWithFacing : BHVTaskParam
	{
		// Token: 0x060008DA RID: 2266 RVA: 0x0005CC14 File Offset: 0x0005AE14
		public BHVTaskParamMoveWithFacing()
		{
			base.m_Type = BHVTaskType.MoveWithFacing;
			this.vector3_0 = Vector3.zero;
			this.gameObject_0 = null;
			this.gameObject_1 = null;
			this.bhvstressLevel_0 = BHVStressLevel.RELAX;
			this.bhvmovementSpeed_0 = BHVMovementSpeed.INVALID;
			this.int_3 = -1;
			this.int_4 = -1;
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x00008D89 File Offset: 0x00006F89
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
			this.gameObject_1 = BHVTaskParam.smethod_0(this.int_4);
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x00008DAD File Offset: 0x00006FAD
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
			this.int_4 = BHVTaskParam.smethod_1(this.gameObject_1);
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x0005CC64 File Offset: 0x0005AE64
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.vector3_0 = this.vector3_0;
				data_0.bhvstressLevel_0 = this.bhvstressLevel_0;
				data_0.bhvmovementSpeed_0 = this.bhvmovementSpeed_0;
				data_0.int_2 = this.int_3;
				data_0.int_3 = this.int_4;
			}
			else
			{
				this.vector3_0 = data_0.vector3_0;
				this.bhvstressLevel_0 = data_0.bhvstressLevel_0;
				this.bhvmovementSpeed_0 = data_0.bhvmovementSpeed_0;
				this.int_3 = data_0.int_2;
				this.int_4 = data_0.int_3;
			}
		}

		// Token: 0x0400083B RID: 2107
		private int int_3;

		// Token: 0x0400083C RID: 2108
		private int int_4;

		// Token: 0x0400083D RID: 2109
		public Vector3 vector3_0;

		// Token: 0x0400083E RID: 2110
		public GameObject gameObject_0;

		// Token: 0x0400083F RID: 2111
		public GameObject gameObject_1;

		// Token: 0x04000840 RID: 2112
		public BHVStressLevel bhvstressLevel_0;

		// Token: 0x04000841 RID: 2113
		public BHVMovementSpeed bhvmovementSpeed_0;
	}
}
