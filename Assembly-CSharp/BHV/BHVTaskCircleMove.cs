using System;

namespace BHV
{
	// Token: 0x02000178 RID: 376
	public class BHVTaskCircleMove : BHVTask
	{
		// Token: 0x06000889 RID: 2185 RVA: 0x00008920 File Offset: 0x00006B20
		public BHVTaskCircleMove()
		{
			base.m_Type = BHVTaskType.CircleMove;
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x00008930 File Offset: 0x00006B30
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamCircleMove_0 = bhvtaskParam_0 as BHVTaskParamCircleMove;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x00008945 File Offset: 0x00006B45
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamCircleMove_0;
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x0000894D File Offset: 0x00006B4D
		public override void Start()
		{
			base.Start();
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bSpecialTeleporting", true);
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x00008970 File Offset: 0x00006B70
		public override void vmethod_3(bool bool_1)
		{
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bSpecialTeleporting", false);
			base.vmethod_3(bool_1);
		}

		// Token: 0x04000807 RID: 2055
		private BHVTaskParamCircleMove bhvtaskParamCircleMove_0;
	}
}
