using System;

namespace BHV
{
	// Token: 0x02000193 RID: 403
	public class BHVTaskRollBack : BHVTask
	{
		// Token: 0x060008FC RID: 2300 RVA: 0x00008F9B File Offset: 0x0000719B
		public BHVTaskRollBack()
		{
			base.m_Type = BHVTaskType.RollBack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x00008FB2 File Offset: 0x000071B2
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamRollBack_0 = bhvtaskParam_0 as BHVTaskParamRollBack;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x00008FC7 File Offset: 0x000071C7
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamRollBack_0;
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x00008FCF File Offset: 0x000071CF
		public override void Start()
		{
			base.Start();
			this.bhvtaskManager_0.m_animationManagerFSM.Boolean_1 = true;
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bRollBack", true);
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x0000900A File Offset: 0x0000720A
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x00009016 File Offset: 0x00007216
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
			this.bhvtaskManager_0.m_animationManagerFSM.Boolean_1 = false;
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bRollBack", false);
		}

		// Token: 0x0400084C RID: 2124
		private BHVTaskParamRollBack bhvtaskParamRollBack_0;
	}
}
