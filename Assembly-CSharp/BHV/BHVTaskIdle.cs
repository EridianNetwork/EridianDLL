using System;
using System.Text;

namespace BHV
{
	// Token: 0x02000188 RID: 392
	public class BHVTaskIdle : BHVTask
	{
		// Token: 0x060008C9 RID: 2249 RVA: 0x00008CCE File Offset: 0x00006ECE
		public BHVTaskIdle()
		{
			base.m_Type = BHVTaskType.Idle;
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x00008CE4 File Offset: 0x00006EE4
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamIdle_0 = bhvtaskParam_0 as BHVTaskParamIdle;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x00008CF9 File Offset: 0x00006EF9
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamIdle_0;
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x0005C828 File Offset: 0x0005AA28
		public override void Start()
		{
			base.Start();
			if (this.animationIdleState_0 == null)
			{
				this.animationIdleState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16(Utils.smethod_23(AnimationStateFSM.Idle)) as AnimationIdleState;
			}
			if (this.animationIdleState_0 != null)
			{
				this.animationIdleState_0.m_stressLevel = this.bhvtaskParamIdle_0.bhvstressLevel_0;
			}
			this.idleState_0 = BHVTaskIdle.IdleState.const_1;
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x0005C88C File Offset: 0x0005AA8C
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			BHVTaskIdle.IdleState idleState = this.idleState_0;
			switch (idleState + 1)
			{
			case BHVTaskIdle.IdleState.const_1:
				base.m_Status = BHVTaskStatus.FAILED;
				return;
			case BHVTaskIdle.IdleState.const_2:
				if (!(this.bhvtaskManager_0.m_animationManagerFSM == null))
				{
					this.bhvtaskManager_0.m_animationManagerFSM.Boolean_1 = false;
					this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.Idle);
					base.m_Status = BHVTaskStatus.RUNNING;
					this.idleState_0 = BHVTaskIdle.IdleState.const_2;
					return;
				}
				base.m_Status = BHVTaskStatus.FAILED;
				this.idleState_0 = BHVTaskIdle.IdleState.const_3;
				break;
			case BHVTaskIdle.IdleState.const_3:
			{
				AnimationStatus animationStatus = this.bhvtaskManager_0.m_animationManagerFSM.method_0(AnimationStateFSM.Idle);
				switch (animationStatus + 1)
				{
				case AnimationStatus.FAILED:
				case AnimationStatus.RUNNING:
					base.m_Status = BHVTaskStatus.FAILED;
					this.idleState_0 = BHVTaskIdle.IdleState.const_3;
					break;
				case AnimationStatus.SUCCESS:
					base.m_Status = BHVTaskStatus.RUNNING;
					break;
				case AnimationStatus.PREPARE:
					this.idleState_0 = BHVTaskIdle.IdleState.const_3;
					base.m_Status = BHVTaskStatus.SUCCESS;
					break;
				}
				return;
			}
			case (BHVTaskIdle.IdleState)3:
				return;
			}
			base.m_Status = BHVTaskStatus.SUCCESS;
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x0005C978 File Offset: 0x0005AB78
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			stringBuilder.Append(string.Format("        State:{0} - StressLevel:{1}\n", this.idleState_0, (this.bhvtaskParamIdle_0 == null) ? "Unkown" : this.bhvtaskParamIdle_0.bhvstressLevel_0.ToString()));
			return stringBuilder.ToString();
		}

		// Token: 0x0400082B RID: 2091
		private BHVTaskParamIdle bhvtaskParamIdle_0;

		// Token: 0x0400082C RID: 2092
		private BHVTaskIdle.IdleState idleState_0 = BHVTaskIdle.IdleState.const_0;

		// Token: 0x0400082D RID: 2093
		private AnimationIdleState animationIdleState_0;

		// Token: 0x02000189 RID: 393
		private enum IdleState
		{
			// Token: 0x0400082F RID: 2095
			const_0 = -1,
			// Token: 0x04000830 RID: 2096
			const_1,
			// Token: 0x04000831 RID: 2097
			const_2,
			// Token: 0x04000832 RID: 2098
			const_3
		}
	}
}
