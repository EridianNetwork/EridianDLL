using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200020A RID: 522
	public class BHVTaskSpacing : BHVTask
	{
		// Token: 0x06000AEF RID: 2799 RVA: 0x0000ACAF File Offset: 0x00008EAF
		public BHVTaskSpacing()
		{
			base.m_Type = BHVTaskType.Spacing;
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x0000ACC6 File Offset: 0x00008EC6
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamSpacing_0 = bhvtaskParam_0 as BHVTaskParamSpacing;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x0000ACDB File Offset: 0x00008EDB
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamSpacing_0;
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x000647CC File Offset: 0x000629CC
		public override void Start()
		{
			base.Start();
			this.spacingState_0 = BHVTaskSpacing.SpacingState.const_1;
			this.animationSpacingState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("Spacing") as AnimationSpacingState;
			this.animationSpacingState_0.method_4(this.bhvtaskParamSpacing_0.bool_1);
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x0006481C File Offset: 0x00062A1C
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			switch (this.spacingState_0)
			{
			case BHVTaskSpacing.SpacingState.const_1:
				this.bhvtaskManager_0.m_animationManagerFSM.BHVStressLevel_0 = BHVStressLevel.COMBAT;
				this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.Spacing);
				base.m_Status = BHVTaskStatus.RUNNING;
				this.spacingState_0 = BHVTaskSpacing.SpacingState.const_2;
				break;
			case BHVTaskSpacing.SpacingState.const_2:
				this.bhvtaskManager_0.vmethod_0<BHVNavAgentSettings>().m_canUseFacingLogic = true;
				break;
			}
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x00064890 File Offset: 0x00062A90
		private void method_0()
		{
			if (this.bhvtaskParamSpacing_0.gameObject_0 == null)
			{
				return;
			}
			Vector3 normalized = (this.bhvtaskParamSpacing_0.gameObject_0.transform.position - this.bhvtaskManager_0.transform.position).normalized;
			normalized.y = 0f;
			this.bhvtaskManager_0.m_entity.transform.forward = Vector3.Slerp(this.bhvtaskManager_0.m_entity.transform.forward, normalized, Time.deltaTime * 2f);
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x00008E2F File Offset: 0x0000702F
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
		}

		// Token: 0x040009E8 RID: 2536
		private BHVTaskParamSpacing bhvtaskParamSpacing_0;

		// Token: 0x040009E9 RID: 2537
		private BHVTaskSpacing.SpacingState spacingState_0 = BHVTaskSpacing.SpacingState.const_0;

		// Token: 0x040009EA RID: 2538
		private AnimationSpacingState animationSpacingState_0;

		// Token: 0x0200020B RID: 523
		private enum SpacingState
		{
			// Token: 0x040009EC RID: 2540
			const_0 = -1,
			// Token: 0x040009ED RID: 2541
			const_1,
			// Token: 0x040009EE RID: 2542
			const_2,
			// Token: 0x040009EF RID: 2543
			const_3,
			// Token: 0x040009F0 RID: 2544
			const_4
		}
	}
}
