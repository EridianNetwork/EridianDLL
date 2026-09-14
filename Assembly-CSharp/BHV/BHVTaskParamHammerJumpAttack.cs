using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001D4 RID: 468
	public sealed class BHVTaskParamHammerJumpAttack : BHVTaskParam
	{
		// Token: 0x06000A0D RID: 2573 RVA: 0x00009FD2 File Offset: 0x000081D2
		public BHVTaskParamHammerJumpAttack()
		{
			base.m_Type = BHVTaskType.HammerJumpAttack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
			this.gameObject_0 = null;
			this.ecurveType_0 = AIServiceCurve.ECurveType.EJumpCurve;
			this.int_3 = -1;
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x00009FFE File Offset: 0x000081FE
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x0000A011 File Offset: 0x00008211
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x00061780 File Offset: 0x0005F980
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_2 = this.int_3;
				data_0.vector3_0 = this.vector3_0;
			}
			else
			{
				this.int_3 = data_0.int_2;
				this.vector3_0 = data_0.vector3_0;
			}
		}

		// Token: 0x04000939 RID: 2361
		public GameObject gameObject_0;

		// Token: 0x0400093A RID: 2362
		public Vector3 vector3_0;

		// Token: 0x0400093B RID: 2363
		public AIServiceCurve.ECurveType ecurveType_0;

		// Token: 0x0400093C RID: 2364
		private int int_3;
	}
}
