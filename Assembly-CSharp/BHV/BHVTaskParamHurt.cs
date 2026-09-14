using System;

namespace BHV
{
	// Token: 0x020001D6 RID: 470
	public sealed class BHVTaskParamHurt : BHVTaskParamAnimationState
	{
		// Token: 0x06000A18 RID: 2584 RVA: 0x0000A086 File Offset: 0x00008286
		public BHVTaskParamHurt()
		{
			base.m_Type = BHVTaskType.Hurt;
			this.edamageType_0 = EDamageType.DT_None;
			this.int_3 = 0;
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x00061AA4 File Offset: 0x0005FCA4
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_1 = (int)this.edamageType_0;
				data_0.int_2 = this.int_3;
			}
			else
			{
				this.edamageType_0 = (EDamageType)data_0.int_1;
				this.int_3 = data_0.int_2;
			}
		}

		// Token: 0x04000944 RID: 2372
		public EDamageType edamageType_0;

		// Token: 0x04000945 RID: 2373
		public int int_3;
	}
}
