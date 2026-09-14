using System;

namespace BHV
{
	// Token: 0x02000237 RID: 567
	public sealed class BHVTaskParamPlayerSkill : BHVTaskParam
	{
		// Token: 0x06000BA2 RID: 2978 RVA: 0x0000B643 File Offset: 0x00009843
		public BHVTaskParamPlayerSkill()
		{
			base.m_Type = BHVTaskType.PlayerSkill;
			this.eskillStatePhase_0 = ESkillStatePhase.First;
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x0000B65A File Offset: 0x0000985A
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_1 = (int)this.eskillStatePhase_0;
			}
			else
			{
				this.eskillStatePhase_0 = (ESkillStatePhase)data_0.int_1;
			}
		}

		// Token: 0x04000A86 RID: 2694
		public ESkillStatePhase eskillStatePhase_0;
	}
}
