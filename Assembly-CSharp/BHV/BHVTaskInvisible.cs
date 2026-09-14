using System;

namespace BHV
{
	// Token: 0x020001DE RID: 478
	public class BHVTaskInvisible : BHVTask
	{
		// Token: 0x06000A3A RID: 2618 RVA: 0x0000A1F2 File Offset: 0x000083F2
		public BHVTaskInvisible()
		{
			base.m_Type = BHVTaskType.Invisible;
			base.m_Layer = BHVTaskLayer.EFFECT;
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x0000A21F File Offset: 0x0000841F
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamInvisible_0 = bhvtaskParam_0 as BHVTaskParamInvisible;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x0000A234 File Offset: 0x00008434
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamInvisible_0;
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x000625DC File Offset: 0x000607DC
		public override void Start()
		{
			base.Start();
			this.float_0 = this.bhvtaskParamInvisible_0.float_0;
			(this.bhvtaskManager_0.m_animationManagerFSM as NPCAnimationManagerFSM).method_25(true, 1f, true, 10f, true);
			if (this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager != null)
			{
				this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager.method_7(ENPCParticleType.E_Invisible, this.bhvtaskManager_0.transform, true);
			}
			this.bool_1 = false;
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x0006266C File Offset: 0x0006086C
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			if (!this.bool_1)
			{
				this.float_0 -= deltaTime;
				if (this.float_0 < 0f)
				{
					this.float_1 = 1f;
					this.bool_1 = true;
					(this.bhvtaskManager_0.m_animationManagerFSM as NPCAnimationManagerFSM).method_26(true, this.float_1, true, 10f, true);
				}
			}
			else
			{
				this.float_1 -= deltaTime;
				if (this.float_1 < 0f)
				{
					if (this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager != null)
					{
						this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager.method_7(ENPCParticleType.E_Invisible, this.bhvtaskManager_0.transform, true);
					}
					base.m_Status = BHVTaskStatus.SUCCESS;
				}
			}
		}

		// Token: 0x04000968 RID: 2408
		private BHVTaskParamInvisible bhvtaskParamInvisible_0;

		// Token: 0x04000969 RID: 2409
		private float float_0 = 1f;

		// Token: 0x0400096A RID: 2410
		private float float_1 = 1f;

		// Token: 0x0400096B RID: 2411
		private bool bool_1;
	}
}
