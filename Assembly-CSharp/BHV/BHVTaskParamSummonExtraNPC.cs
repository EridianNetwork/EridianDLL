using System;

namespace BHV
{
	// Token: 0x02000199 RID: 409
	public sealed class BHVTaskParamSummonExtraNPC : BHVTaskParamAnimationState
	{
		// Token: 0x06000913 RID: 2323 RVA: 0x0000918F File Offset: 0x0000738F
		public BHVTaskParamSummonExtraNPC()
		{
			base.m_Type = BHVTaskType.SummonExtraNPC;
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x0000919F File Offset: 0x0000739F
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
		}
	}
}
