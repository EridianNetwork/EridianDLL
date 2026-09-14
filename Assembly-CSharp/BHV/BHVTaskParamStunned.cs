using System;

namespace BHV
{
	// Token: 0x0200020E RID: 526
	public sealed class BHVTaskParamStunned : BHVTaskParamAnimationState
	{
		// Token: 0x06000B02 RID: 2818 RVA: 0x0000AD94 File Offset: 0x00008F94
		public BHVTaskParamStunned()
		{
			base.m_Type = BHVTaskType.Stunned;
		}

		// Token: 0x06000B03 RID: 2819 RVA: 0x0000919F File Offset: 0x0000739F
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
		}
	}
}
