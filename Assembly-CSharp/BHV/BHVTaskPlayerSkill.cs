using System;
using ns0;

namespace BHV
{
	// Token: 0x02000238 RID: 568
	public class BHVTaskPlayerSkill : BHVTask
	{
		// Token: 0x06000BA4 RID: 2980 RVA: 0x0000B683 File Offset: 0x00009883
		public BHVTaskPlayerSkill()
		{
			base.m_Type = BHVTaskType.PlayerSkill;
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x0000B693 File Offset: 0x00009893
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamPlayerSkill_0 = bhvtaskParam_0 as BHVTaskParamPlayerSkill;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x0000B6A8 File Offset: 0x000098A8
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamPlayerSkill_0;
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x0000872C File Offset: 0x0000692C
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			base.m_Status = BHVTaskStatus.SUCCESS;
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x00067444 File Offset: 0x00065644
		public override void Start()
		{
			base.Start();
			base.m_Status = BHVTaskStatus.RUNNING;
			EntityPlayer entityPlayer = this.bhvtaskManager_0.m_entity as EntityPlayer;
			if (this.bhvtaskParamPlayerSkill_0.eskillStatePhase_0 == ESkillStatePhase.First)
			{
				ServiceWrapperBase<QuestServiceWrapper>.Instance.method_13();
			}
			entityPlayer.PlayerSkillManage_0.OnSkillTask(this.bhvtaskParamPlayerSkill_0.eskillStatePhase_0);
			entityPlayer.method_134();
		}

		// Token: 0x04000A87 RID: 2695
		private BHVTaskParamPlayerSkill bhvtaskParamPlayerSkill_0;
	}
}
