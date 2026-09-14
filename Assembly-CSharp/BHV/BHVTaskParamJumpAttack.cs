using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001E1 RID: 481
	public sealed class BHVTaskParamJumpAttack : BHVTaskParam
	{
		// Token: 0x06000A4B RID: 2635 RVA: 0x0000A2DF File Offset: 0x000084DF
		public BHVTaskParamJumpAttack()
		{
			base.m_Type = BHVTaskType.JumpAttack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
			this.gameObject_0 = null;
			this.ecurveType_0 = AIServiceCurve.ECurveType.EJumpCurve;
			this.int_3 = -1;
			this.jumpAttackStep_0 = BHVTaskParamJumpAttack.JumpAttackStep.const_0;
		}

		// Token: 0x06000A4C RID: 2636 RVA: 0x0000A312 File Offset: 0x00008512
		public override void vmethod_0()
		{
			this.gameObject_0 = BHVTaskParam.smethod_0(this.int_3);
		}

		// Token: 0x06000A4D RID: 2637 RVA: 0x0000A325 File Offset: 0x00008525
		public override void vmethod_1()
		{
			this.int_3 = BHVTaskParam.smethod_1(this.gameObject_0);
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x00062970 File Offset: 0x00060B70
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_2 = this.int_3;
				data_0.int_1 = (int)this.ecurveType_0;
				data_0.int_4 = (int)this.jumpAttackStep_0;
			}
			else
			{
				this.int_3 = data_0.int_2;
				this.ecurveType_0 = (AIServiceCurve.ECurveType)data_0.int_1;
				this.jumpAttackStep_0 = (BHVTaskParamJumpAttack.JumpAttackStep)data_0.int_4;
			}
		}

		// Token: 0x04000975 RID: 2421
		public GameObject gameObject_0;

		// Token: 0x04000976 RID: 2422
		public AIServiceCurve.ECurveType ecurveType_0;

		// Token: 0x04000977 RID: 2423
		public BHVTaskParamJumpAttack.JumpAttackStep jumpAttackStep_0;

		// Token: 0x04000978 RID: 2424
		private int int_3;

		// Token: 0x020001E2 RID: 482
		public enum JumpAttackStep
		{
			// Token: 0x0400097A RID: 2426
			const_0,
			// Token: 0x0400097B RID: 2427
			const_1,
			// Token: 0x0400097C RID: 2428
			const_2,
			// Token: 0x0400097D RID: 2429
			const_3
		}
	}
}
