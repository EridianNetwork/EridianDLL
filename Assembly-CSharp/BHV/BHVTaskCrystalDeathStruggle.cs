using System;

namespace BHV
{
	// Token: 0x020001B3 RID: 435
	public class BHVTaskCrystalDeathStruggle : BHVTask
	{
		// Token: 0x0600096C RID: 2412 RVA: 0x00009704 File Offset: 0x00007904
		public BHVTaskCrystalDeathStruggle()
		{
			base.m_Type = BHVTaskType.CrystalDeathStruggle;
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x00009714 File Offset: 0x00007914
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamCrystalDeathStruggle_0 = bhvtaskParam_0 as BHVTaskParamCrystalDeathStruggle;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x00009729 File Offset: 0x00007929
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamCrystalDeathStruggle_0;
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x0005DE10 File Offset: 0x0005C010
		public override void Start()
		{
			base.Start();
			this.float_0 = this.bhvtaskParamCrystalDeathStruggle_0.float_0;
			this.bool_1 = false;
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bDeathStruggle", true);
			(this.bhvtaskManager_0.m_animationManagerFSM as TheInsaneCrystalAnimationManagerFSM).method_32(true);
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x0005DE6C File Offset: 0x0005C06C
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			base.Update(deltaTime);
			if (!this.bool_1)
			{
				this.float_0 -= deltaTime;
				if (this.float_0 > 0f)
				{
					return;
				}
				this.bool_1 = true;
				(this.bhvtaskManager_0.m_animationManagerFSM as TheInsaneCrystalAnimationManagerFSM).method_32(false);
			}
			base.m_Status = BHVTaskStatus.SUCCESS;
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x00009731 File Offset: 0x00007931
		public override void vmethod_3(bool bool_2)
		{
			base.vmethod_3(bool_2);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bDeathStruggle", false);
			(this.bhvtaskManager_0.m_animationManagerFSM as TheInsaneCrystalAnimationManagerFSM).method_32(false);
		}

		// Token: 0x04000890 RID: 2192
		private BHVTaskParamCrystalDeathStruggle bhvtaskParamCrystalDeathStruggle_0;

		// Token: 0x04000891 RID: 2193
		private float float_0;

		// Token: 0x04000892 RID: 2194
		private bool bool_1;
	}
}
