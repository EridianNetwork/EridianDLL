using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200018A RID: 394
	public sealed class BHVTaskParamMoveTo : BHVTaskParam
	{
		// Token: 0x060008CF RID: 2255 RVA: 0x00008D01 File Offset: 0x00006F01
		public BHVTaskParamMoveTo()
		{
			base.m_Type = BHVTaskType.MoveTo;
			this.vector3_0 = Vector3.zero;
			this.bhvstressLevel_0 = BHVStressLevel.RELAX;
			this.bhvmovementSpeed_0 = BHVMovementSpeed.INVALID;
			this.int_3 = -1;
			this.bool_1 = true;
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x00008D37 File Offset: 0x00006F37
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x00008D4A File Offset: 0x00006F4A
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x0005C9D8 File Offset: 0x0005ABD8
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_2)
		{
			base.vmethod_2(ref data_0, bool_2);
			if (bool_2)
			{
				data_0.vector3_0 = this.vector3_0;
				data_0.bhvstressLevel_0 = this.bhvstressLevel_0;
				data_0.bhvmovementSpeed_0 = this.bhvmovementSpeed_0;
				data_0.int_3 = this.int_3;
			}
			else
			{
				this.vector3_0 = data_0.vector3_0;
				this.bhvstressLevel_0 = data_0.bhvstressLevel_0;
				this.bhvmovementSpeed_0 = data_0.bhvmovementSpeed_0;
				this.int_3 = data_0.int_3;
			}
		}

		// Token: 0x04000833 RID: 2099
		public BHVStressLevel bhvstressLevel_0;

		// Token: 0x04000834 RID: 2100
		public BHVMovementSpeed bhvmovementSpeed_0;

		// Token: 0x04000835 RID: 2101
		public Vector3 vector3_0;

		// Token: 0x04000836 RID: 2102
		public GameObject gameObject_0;

		// Token: 0x04000837 RID: 2103
		public bool bool_1;

		// Token: 0x04000838 RID: 2104
		private int int_3;
	}
}
