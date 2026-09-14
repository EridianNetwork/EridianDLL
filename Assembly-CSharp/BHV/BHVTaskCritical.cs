using System;

namespace BHV
{
	// Token: 0x020001B1 RID: 433
	public class BHVTaskCritical : BHVTask
	{
		// Token: 0x06000964 RID: 2404 RVA: 0x0000969F File Offset: 0x0000789F
		public BHVTaskCritical()
		{
			base.m_Type = BHVTaskType.Critical;
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x000096AF File Offset: 0x000078AF
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamCritical_0 = bhvtaskParam_0 as BHVTaskParamCritical;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x000096C4 File Offset: 0x000078C4
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamCritical_0;
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x0005DCF0 File Offset: 0x0005BEF0
		public override void Start()
		{
			base.Start();
			this.float_0 = 0f;
			this.bool_1 = false;
			this.animationCriticalState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("Critical") as AnimationCriticalState;
			base.m_Status = BHVTaskStatus.RUNNING;
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.Critical);
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x0005DD50 File Offset: 0x0005BF50
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (!this.bool_1)
			{
				this.float_0 += deltaTime;
				if (this.float_0 > this.bhvtaskParamCritical_0.float_0)
				{
					this.animationCriticalState_0.method_4(true);
					this.bool_1 = true;
				}
			}
			else if (this.animationCriticalState_0.m_bStruggleEnd)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x000096CC File Offset: 0x000078CC
		public override void vmethod_3(bool bool_2)
		{
			base.vmethod_3(bool_2);
			this.animationCriticalState_0.method_5(false);
		}

		// Token: 0x0400088A RID: 2186
		private BHVTaskParamCritical bhvtaskParamCritical_0;

		// Token: 0x0400088B RID: 2187
		private float float_0;

		// Token: 0x0400088C RID: 2188
		private bool bool_1;

		// Token: 0x0400088D RID: 2189
		private AnimationCriticalState animationCriticalState_0;
	}
}
