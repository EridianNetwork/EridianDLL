using System;

namespace BHV
{
	// Token: 0x020001E9 RID: 489
	public class BHVTaskLaserSweep : BHVTask
	{
		// Token: 0x06000A65 RID: 2661 RVA: 0x0000A468 File Offset: 0x00008668
		public BHVTaskLaserSweep()
		{
			base.m_Type = BHVTaskType.LaserSweep;
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x0000A478 File Offset: 0x00008678
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamLaserSweep_0 = bhvtaskParam_0 as BHVTaskParamLaserSweep;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x0000A48D File Offset: 0x0000868D
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamLaserSweep_0;
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x00062E80 File Offset: 0x00061080
		public override void Start()
		{
			base.Start();
			this.animationLaserSweepState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("LaserSweep") as AnimationLaserSweepState;
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.LaserSweep);
			base.m_Status = BHVTaskStatus.RUNNING;
			CrimsonMechaKnoxxAnimationManagerFSM crimsonMechaKnoxxAnimationManagerFSM = this.bhvtaskManager_0.m_animationManagerFSM as CrimsonMechaKnoxxAnimationManagerFSM;
			if (crimsonMechaKnoxxAnimationManagerFSM != null)
			{
				crimsonMechaKnoxxAnimationManagerFSM.m_bLaserSweepStart = true;
			}
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x0000A495 File Offset: 0x00008695
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			base.Update(deltaTime);
			if (this.animationLaserSweepState_0.m_status == AnimationStatus.SUCCESS)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x00062EF0 File Offset: 0x000610F0
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
			CrimsonMechaKnoxxAnimationManagerFSM crimsonMechaKnoxxAnimationManagerFSM = this.bhvtaskManager_0.m_animationManagerFSM as CrimsonMechaKnoxxAnimationManagerFSM;
			if (crimsonMechaKnoxxAnimationManagerFSM != null)
			{
				crimsonMechaKnoxxAnimationManagerFSM.method_32();
				crimsonMechaKnoxxAnimationManagerFSM.method_34();
				crimsonMechaKnoxxAnimationManagerFSM.m_bLaserSweepStart = false;
			}
		}

		// Token: 0x04000987 RID: 2439
		private BHVTaskParamLaserSweep bhvtaskParamLaserSweep_0;

		// Token: 0x04000988 RID: 2440
		private AnimationLaserSweepState animationLaserSweepState_0;
	}
}
