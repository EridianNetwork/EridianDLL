using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001A0 RID: 416
	public class BHVTaskUndergroundIdle : BHVTask
	{
		// Token: 0x0600092E RID: 2350 RVA: 0x00009342 File Offset: 0x00007542
		public BHVTaskUndergroundIdle()
		{
			base.m_Type = BHVTaskType.UndergroundIdle;
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x00009352 File Offset: 0x00007552
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamUndergroundIdle_0 = bhvtaskParam_0 as BHVTaskParamUndergroundIdle;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x00009367 File Offset: 0x00007567
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamUndergroundIdle_0;
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x0005D668 File Offset: 0x0005B868
		public override void Start()
		{
			base.Start();
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("IsAlert", false);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetInteger("DrillAttackStep", 0);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bIntoGround", true);
			this.method_0(false);
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x00008C1B File Offset: 0x00006E1B
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			base.Update(deltaTime);
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x0005D6D4 File Offset: 0x0005B8D4
		private void method_0(bool bool_1)
		{
			if (this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager != null)
			{
				this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager.method_8(ENPCParticleType.E_MoveDust, null, this.bhvtaskManager_0.transform.position, Quaternion.identity, true);
			}
			(this.bhvtaskManager_0.m_animationManagerFSM as CrabwormAnimationManagerFSM).method_31(bool_1);
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x0005D740 File Offset: 0x0005B940
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bIntoGround", false);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("IsAlert", true);
			this.method_0(true);
		}

		// Token: 0x04000866 RID: 2150
		private BHVTaskParamUndergroundIdle bhvtaskParamUndergroundIdle_0;
	}
}
