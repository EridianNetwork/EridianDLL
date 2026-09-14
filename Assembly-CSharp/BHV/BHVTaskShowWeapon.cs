using System;

namespace BHV
{
	// Token: 0x02000206 RID: 518
	public class BHVTaskShowWeapon : BHVTaskAnimationState
	{
		// Token: 0x06000ADF RID: 2783 RVA: 0x0000AB8C File Offset: 0x00008D8C
		public BHVTaskShowWeapon()
		{
			base.m_Type = BHVTaskType.ShowWeapon;
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x0000AB9C File Offset: 0x00008D9C
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamShowWeapon_0 = bhvtaskParam_0 as BHVTaskParamShowWeapon;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x0000ABB1 File Offset: 0x00008DB1
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamShowWeapon_0;
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x0000ABB9 File Offset: 0x00008DB9
		public override void Start()
		{
			base.Start();
			if (this.bhvtaskManager_0.m_animationManagerFSM.vmethod_12())
			{
				this.state_0 = BHVTaskAnimationState.State.const_3;
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x0000ABE1 File Offset: 0x00008DE1
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.ShowWeapon);
		}

		// Token: 0x040009E0 RID: 2528
		private BHVTaskParamShowWeapon bhvtaskParamShowWeapon_0;
	}
}
