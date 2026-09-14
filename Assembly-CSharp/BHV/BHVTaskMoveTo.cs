using System;
using System.Text;

namespace BHV
{
	// Token: 0x0200018B RID: 395
	public class BHVTaskMoveTo : BHVTask
	{
		// Token: 0x060008D3 RID: 2259 RVA: 0x00008D5D File Offset: 0x00006F5D
		public BHVTaskMoveTo()
		{
			base.m_Type = BHVTaskType.MoveTo;
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x00008D6C File Offset: 0x00006F6C
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamMoveTo_0 = bhvtaskParam_0 as BHVTaskParamMoveTo;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x00008D81 File Offset: 0x00006F81
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamMoveTo_0;
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x0005CA5C File Offset: 0x0005AC5C
		public override void Start()
		{
			base.Start();
			this.animationMoveState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16(Utils.smethod_23(AnimationStateFSM.Move)) as AnimationMoveState;
			if (this.animationMoveState_0 != null)
			{
				this.animationMoveState_0.m_moveSpeed = this.bhvtaskManager_0.method_19(this.bhvtaskParamMoveTo_0.bhvmovementSpeed_0, this.bhvtaskParamMoveTo_0.bhvstressLevel_0);
				this.animationMoveState_0.m_destinationDistanceFactor = 1f;
				this.animationMoveState_0.m_isSprint = this.bhvtaskParamMoveTo_0.bhvmovementSpeed_0 == BHVMovementSpeed.SPRINT;
			}
			this.bhvtaskManager_0.m_animationManagerFSM.Boolean_1 = true;
			this.bhvtaskManager_0.m_animationManagerFSM.BHVStressLevel_0 = this.bhvtaskParamMoveTo_0.bhvstressLevel_0;
			this.bhvtaskManager_0.m_animationManagerFSM.Boolean_0 = false;
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.Move);
			this.bhvtaskManager_0.vmethod_0<BHVNavAgentSettings>().m_canUseFacingLogic = false;
			this.bhvtaskManager_0.m_animationManagerFSM.m_canUseFacingLogic = false;
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x00008C1B File Offset: 0x00006E1B
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			base.Update(deltaTime);
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x0005CB64 File Offset: 0x0005AD64
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
			if (!this.bhvtaskParamMoveTo_0.bool_1 && this.bhvtaskManager_0.m_animationManagerFSM != null)
			{
				NPCAnimationManagerFSM npcanimationManagerFSM = this.bhvtaskManager_0.m_animationManagerFSM as NPCAnimationManagerFSM;
				if (npcanimationManagerFSM != null)
				{
					npcanimationManagerFSM.method_23(false);
				}
			}
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x0005CBBC File Offset: 0x0005ADBC
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			if (this.bhvtaskParamMoveTo_0 != null)
			{
				stringBuilder.Append(string.Format("        StressLevel:{0} - MovementSpeed:{1} \n", this.bhvtaskParamMoveTo_0.bhvstressLevel_0, this.bhvtaskParamMoveTo_0.bhvmovementSpeed_0));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x04000839 RID: 2105
		private BHVTaskParamMoveTo bhvtaskParamMoveTo_0;

		// Token: 0x0400083A RID: 2106
		private AnimationMoveState animationMoveState_0;
	}
}
